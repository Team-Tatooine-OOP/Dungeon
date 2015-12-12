using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using OopProject;

using IDrawable = OopProject.Interfaces.IDrawable;

namespace OopProject.Characters
{
    public abstract class DrawCharacter : IDrawable
    {
        private ContentManager Content;
        private int row;
        private int endCol;
        private int currentFrame;
        private Vector2 movingVector2;
        private Texture2D CurrentCharacter;
        private string name;

        public Texture2D CurrentCharacter1
        {
            get
            {
                return CurrentCharacter;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Empty Character");
                }
                CurrentCharacter = value;
            }
        }

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

        public abstract void UnloadContent();

        protected DrawCharacter(string name)
        {
           
            this.name = name;
        }
        public void LoadContent()
        {

            this.CurrentCharacter = Content.Load<Texture2D>("GoodGuy");
        }

        public void Update(GameTime gameTime)
        {
            Moving(movingVector2);
        }

        protected void Moving(Vector2 vector2)
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Left))
            {
                movingVector2.X -= 3;
            }
            else if (newState.IsKeyDown(Keys.Right))
            {
                movingVector2.X += 3;
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                movingVector2.Y -= 3;
            }
            else if (newState.IsKeyDown(Keys.Down))
            {
                movingVector2.Y += 3;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 64;
            int height = 64;
            int column = currentFrame % 4;
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)movingVector2.X, (int)movingVector2.Y, width, height);
            spriteBatch.Draw(CurrentCharacter, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
