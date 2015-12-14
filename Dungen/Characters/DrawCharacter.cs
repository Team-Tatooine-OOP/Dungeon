<<<<<<< HEAD
﻿using System;
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
        
=======
﻿namespace Dungen.Characters
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

>>>>>>> origin/master
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
<<<<<<< HEAD
        
        protected DrawCharacter(string name)
        {
            this.name = name;
        }
=======

        public abstract void UnloadContent();
>>>>>>> origin/master

        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);
        
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
