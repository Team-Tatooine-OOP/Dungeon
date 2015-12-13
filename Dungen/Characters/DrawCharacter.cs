namespace Dungen.Characters
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using IDrawable = OopProject.Interfaces.IDrawable;

    public abstract class DrawCharacter : IDrawable
    {
        private string name;

        protected DrawCharacter(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name is empty");
                }

                this.name = value;
            }
        }

        public abstract void UnloadContent();

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);
        
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
