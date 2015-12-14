using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
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


        protected DrawMagic()
        {
        }

        protected DrawMagic(int x, int y)
        {
            this.X = x;
            this.Y = y;
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

        public abstract void Update(GameTime gametime);

        public abstract void Draw(SpriteBatch spriteBatch);
=======
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = OopProject.Interfaces.IDrawable;
namespace Dungen.Magic
{
    abstract class DrawMagic:IDrawable
    {
        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gametime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
>>>>>>> origin/master
    }
}
