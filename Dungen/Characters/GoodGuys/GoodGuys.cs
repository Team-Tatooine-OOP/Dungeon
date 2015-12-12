using System;
using System.Collections.Generic;
using Dungen.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OopProject.Interfaces;

namespace OopProject.Characters.GoodGuys
{
    public abstract class GoodGuys : DrawCharacter, IMovable
    {

        private int row;
        private int endCol;
        private int currentFrame;
        private Vector2 movingVector2;

        public int Health { get; set; }

        public int Mana { get; set; }
        protected Texture2D currentCharacter;
        public int X { get; set; }
        public int Y { get; set; }

        public override void Update(GameTime gameTime)
        {
            Moving();
        }
        protected GoodGuys(string name)
            : base(name)
        {

        }

        public void Moving()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Left))
            {
                movingVector2.X -= 3;
            }
            else if (newState.IsKeyDown(Keys.Right))
            {
                movingVector2.X += 3;
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                movingVector2.Y -= 3;
            }
            else if (newState.IsKeyDown(Keys.Down))
            {
                movingVector2.Y += 3;
            }
        }

        public override void UnloadContent()
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int width = 64;
            int height = 64;
            int column = currentFrame % 4;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)movingVector2.X, (int)movingVector2.Y, width, height);
            spriteBatch.Draw(currentCharacter, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
