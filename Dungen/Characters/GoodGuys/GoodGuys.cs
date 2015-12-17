using System.Collections.Generic;
using Dungen.Interfaces;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OopProject.Characters.GoodGuys
{
    public abstract class GoodGuys : DrawCharacter, IMovable
    {
        private int row;
        private int endCol;
        private int currentFrame;
        public Vector2 movingVector2;
        public Texture2D currentCharacter;
        protected Texture2D magicType;
        public int Health { get; set; }
        public int Mana { get; set; }
        private int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + 25;
        private int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 + 45;


        protected GoodGuys(string name)
            : base(name)
        {
        }
        public override void Update(GameTime gameTime)
        {
            Moving();
        }


        public void Moving()
        {
            KeyboardState newState = Keyboard.GetState();
            int prevPosY = (int)movingVector2.Y;
            int prevPosX = (int)movingVector2.X;
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

            CheckOutOFScreen(prevPosY, prevPosX);
        }

        private void CheckOutOFScreen(int prevPosY, int prevPosX)
        {
            if (movingVector2.X < 0 || movingVector2.X > width)
            {
                movingVector2.X = prevPosX;
            }
            if (movingVector2.Y > height || movingVector2.Y < 0)
            {
                movingVector2.Y = prevPosY;
            }
        }

        //   public abstract void Attack(MageMagic magic);

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
