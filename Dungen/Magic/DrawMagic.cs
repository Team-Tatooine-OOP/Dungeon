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
        private int x;
        private int y;
        private int currentFrame;
        protected string StatePosition;


        protected DrawMagic()
        {
        }

        protected DrawMagic(int x, int y, string statePosition)
        {
            this.X = x;
            this.Y = y;
            this.StatePosition = statePosition;

        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

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

            }
            else if (state == "Up")
            {
                this.Y += 5;
            }
            else if (state == "Right")
            {
                this.X += 5;
            }
            else if (state == "Left")
            {
                this.X -= 5;
            }

        }
    }
}
