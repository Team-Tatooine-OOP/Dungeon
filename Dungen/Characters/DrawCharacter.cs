using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using OopProject;
using OopProject.Interfaces;

namespace OopProject.Characters
{
    public abstract class DrawCharacter : ICharacter
    {
        private string name;
        
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name is empty");
                }
                name = value;
            }
        }
        
        protected DrawCharacter(string name)
        {
            this.name = name;
        }

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);
        
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
