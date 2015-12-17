using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Interfaces
{
    public interface IDrawable2
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void LoadContent(ContentManager content);

    }

}
