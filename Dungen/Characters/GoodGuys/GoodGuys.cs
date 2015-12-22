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

        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                row = value;
            }
        }

        public int EndCol
        {
            get
            {
                return endCol;
            }

            set
            {
                endCol = value;
            }
        }

        public int CurrentFrame
        {
            get
            {
                return currentFrame;
            }

            set
            {
                currentFrame = value;
            }
        }

        private int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + 25;
        private int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 + 45;
        internal Rectangle destinationRectangle;
        internal Rectangle sourceRectangle;
        public KeyboardState newState;
        protected GoodGuys(string name)
            : base(name)
        {
            movingVector2 = new Vector2(100, 200);
        }
        public override void Update(GameTime gameTime)
        {
            Moving();
        }


        public void Moving()
        {
            newState = Keyboard.GetState();
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
            int column = CurrentFrame % 4;
            sourceRectangle = new Rectangle(width * column, height * Row, width, height);
            destinationRectangle = new Rectangle((int)movingVector2.X, (int)movingVector2.Y, width, height);
            spriteBatch.Draw(currentCharacter, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
