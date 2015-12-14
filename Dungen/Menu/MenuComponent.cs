using Dungen.Enumerations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungen.Menu
{
    public class MenuComponent : DrawableGameComponent
    {
        private MenuOptions option;
        private bool isPlayed = false;
        private string[] menuItems;
        private int selectedIndex;
        private Texture2D menuBackground;

        private Color normal = Color.White;
        private Color hilite = Color.OrangeRed;

        private KeyboardState keyboardState;
        private KeyboardState oldKeyboardState;

        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private Vector2 position;
        private float width = 0f;
        private float height = 0f;

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, string[] menuItems,ContentManager content) 
            : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.menuItems = menuItems;
            menuBackground = content.Load<Texture2D>("TextureAtlases/MenuBackground");
            MeasureMenu();
        }

        public int SelectedIndex
        {
            get { return this.selectedIndex; }
            set
            {
                if (selectedIndex < 0)
                {
                    selectedIndex = 0;
                }
                if (selectedIndex >= menuItems.Length)
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }
        }

        public bool IsPlayed
        {
            get { return this.isPlayed; }
            set { this.isPlayed = value; }
        }
        private void MeasureMenu()
        {
            height = 0;
            width = 0;
            foreach (string item in menuItems)
            {
                Vector2 size = spriteFont.MeasureString(item);
                if (size.X > width)
                {
                    width = size.X;
                }
                height += spriteFont.LineSpacing + 5;
            }
            position = new Vector2(
                40,
                (Game.Window.ClientBounds.Height - height) / 2);
        }

        private bool CheckKey(Keys theKey)
        {
            return keyboardState.IsKeyUp(theKey) && oldKeyboardState.IsKeyDown(theKey); ;
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (CheckKey(Keys.Down) )
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Length)
                {
                    selectedIndex = 0;
                }
            }
            if (CheckKey(Keys.Up))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = menuItems.Length - 1;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                switch (selectedIndex)
                {
                    case 0:
                        IsPlayed = true;
                        break;
                }
            }
            base.Update(gameTime);
            oldKeyboardState = keyboardState;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 location = position;
            Color tint;
            spriteBatch.Begin();

            spriteBatch.Draw(menuBackground, new Rectangle(0, 0, 800, 480), Color.White);
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == selectedIndex)
                {
                    tint = hilite;
                }
                else
                {
                    tint = normal;
                }
                spriteBatch.DrawString(spriteFont,menuItems[i],location,tint);
                location.Y += spriteFont.LineSpacing;
            }
            spriteBatch.End();
        }
    }
}