using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Magic
{

    public class MageMagic : DrawMagic
    {
        private int row;
        private int currentFrame;
        private Texture2D magicType;

        public MageMagic(int x, int y, Texture2D magicType)
            : base(x, y)
        {
            this.magicType = magicType;
        }

        public MageMagic(Texture2D magicType)
        {
            this.magicType = magicType;
        }

        public override void LoadContent(ContentManager content)
        {
            // magicType = content.Load<Texture2D>("TextureAtlases/Fire");
        }

        public override void Update(GameTime gametime)
        {
            Y += 3;
        }
        public void UnloadContent(ContentManager content)
        {
            content.Unload();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            int width = 64;
            int height = 64;
            int column = currentFrame % 4;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(this.X, this.Y, width, height);
            spriteBatch.Draw(this.magicType, destinationRectangle, sourceRectangle, Color.White);
        }
=======

namespace Dungen.Magic
{
    class MageMagic
    {
>>>>>>> origin/master
    }
}
