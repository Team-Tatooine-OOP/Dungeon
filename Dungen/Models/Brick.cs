using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Models
{
    public class Brick
    {
        private int x;
        private int y;
        private Texture2D texture2D;
        public Brick(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void LoadContent(ContentManager content)
        {
            texture2D = content.Load<Texture2D>("TextureAtlases/Brick");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture2D, new Vector2((float)this.X, (float)this.Y), Color.White);
        }

        public int X
        {

            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
