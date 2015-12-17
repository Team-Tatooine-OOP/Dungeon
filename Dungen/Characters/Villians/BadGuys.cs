using System;
using System.Collections.Generic;
using Dungen.Interfaces;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Timers;

namespace OopProject.Characters.Villians
{
    public abstract class BadGuys : DrawCharacter
    {
        private int row;
        private int endCol;
        private int currentFrame;
        private int totalFrames; //
        public Vector2 movingVector2;
        public Texture2D currentCharacter;
        protected Texture2D magicType;
        public int Health { get; set; }
        public int Mana { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        private int speed = 2;

        public Texture2D Texture { get; set; }//
        protected BadGuys(string name)
            : base(name)
        {
        }



        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                {
                    speed = 0;
                }
                else
                {
                    speed = value;
                }

            }
        }




        public int Rows
        {
            get { return row; }
            set { row = value; }
        }

        public int Columns
        {
            get { return endCol; }
            set { endCol = value; }
        }
        public override void Update(GameTime gameTime)
        {
            MonsterMove();
            if (DateTime.Now.Second % 2 == 0)
            {
                //Timer
                RandomMovement();
            }


        }


        int direction = 0; //direction of moving +1 right, -1 left, 0 hold
        public void MonsterMove()
        {
            if (X <= 600 && this.direction >= 0)
            {
                X += speed;
                direction = 1;
            }

            if (X >= 600)
            {
                direction = -1;
            }

            if (direction == -1)
            {
                X -= speed;
            }
            if (X <= 0)
            {
                direction = +1;

            }
        }



        private void RandomMovement()
        {

            Random random = new Random();
            int output = random.Next(2, 6);
            Speed = output;
            if (output > 4)
            {
                this.Y -= 3;
            }
            else
            {
                this.Y += 3;
            }

        }
        //  public void Moving()
        //  {
        //      KeyboardState newState = Keyboard.GetState();
        //      if (newState.IsKeyDown(Keys.Left))
        //      {
        //          movingVector2.X -= 3;
        //      }
        //      else if (newState.IsKeyDown(Keys.Right))
        //      {
        //          movingVector2.X += 3;
        //      }
        //      else if (newState.IsKeyDown(Keys.Up))
        //      {
        //          movingVector2.Y -= 3;
        //      }
        //      else if (newState.IsKeyDown(Keys.Down))
        //      {
        //          movingVector2.Y += 3;
        //      }
        //  }

        //   public abstract void Attack(MageMagic magic);

        //public AnimatedSprite(Texture2D texture, int rows, int columns)
        //{
        //    Texture = texture;
        //    Rows = rows;
        //    Columns = columns;
        //    currentFrame = 0;
        //    totalFrames = Rows * Columns;
        //}

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
