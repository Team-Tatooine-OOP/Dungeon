using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen
{
    class GUIElements
    {
        private Texture2D GuiTexture;
        private ContentManager content;
        private Rectangle rectangle;
        private Vector2 position;
        private string name;

        public GUIElements(string name, Texture2D guiTexture, ContentManager content, Vector2 position, int width, int height)
        {
            GuiTexture1 = guiTexture;
            this.Content = content;
            this.Position = position;
            Rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.Name = name;
        }

        public void LoadContent(ContentManager content)
        {
            content.Load<Texture2D>(Name);
        }
        public Texture2D GuiTexture1
        {
            get
            {
                return GuiTexture;
            }

            set
            {
                GuiTexture = value;
            }
        }

        public ContentManager Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }

            set
            {
                rectangle = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
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
                name = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GuiTexture, rectangle, Color.White);
        }

    }
}
