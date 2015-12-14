using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Interfaces
{
    public interface IDrawMagic
    {
        void LoadContent(ContentManager content);

        void Update(GameTime gametime);

        void Draw(SpriteBatch spriteBatch);
    }
}
