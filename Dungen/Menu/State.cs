using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dungen.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Menu
{
    public abstract class State : IDrawable2
    {
        private Vector2 vector2;

        public State(Vector2 vector2)
        {
            this.Vector2 = vector2;
        }

        public Vector2 Vector2
        {
            get
            {
                return vector2;
            }

            set
            {
                vector2 = value;
            }
        }

        public abstract void LoadContent();

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public abstract void LoadContent(ContentManager content);
    }
}

