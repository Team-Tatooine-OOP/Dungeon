using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungen.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Interfaces;

namespace Dungen.Magic
{
    public abstract class DrawMagic : IDrawMagic
    {
        private int currentFrame;
        protected string StatePosition;
        protected int column;// = 3;
        protected int row;// = 2;


        protected DrawMagic()
        {
        }

        protected DrawMagic(int x, int y, string statePosition)
        {
            this.X = x;
            this.Y = y;
            this.StatePosition = statePosition;

        }

        public int X { get; set; }

        public int Y { get; set; }

        public abstract void LoadContent(ContentManager content);

        public virtual void Update(GameTime gametime)
        {
            SwitchState(this.StatePosition);
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        protected void SwitchState(string state)
        {

            if (state == "Down")
            {
                this.Y -= 5;
                column = 2;
                row = 3;
            }
            else if (state == "Up")
            {
                this.Y += 5;

            }
            else if (state == "Right")
            {
                this.X += 5;
                column = 2;
                row = 2;
            }
            else if (state == "Left")
            {
                this.X -= 5;
                column = 1;
                row = 1;
            }

        }
    }
}
