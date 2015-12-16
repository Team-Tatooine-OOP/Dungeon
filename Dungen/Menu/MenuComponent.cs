using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dungen.Menu
{
    public class MenuComponent : DrawableGameComponent
    {
        private bool isPlayed = false;
        private string[] menuItems;
        private int selectedIndexContent;
        private int selectedIndexCharacter;
        private Texture2D menuBackground;
        private Texture2D[] charactersInTheMenu = new Texture2D[3];
        private Texture2D[] rightButtons = new Texture2D[2];
        private Texture2D[] leftButtons = new Texture2D[2];

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
            menuBackground = content.Load<Texture2D>("TextureAtlases/BackroundMenu");
            charactersInTheMenu[0] = content.Load<Texture2D>("MenuCharacters/hero1");
            charactersInTheMenu[1] = content.Load<Texture2D>("MenuCharacters/hero2");
            charactersInTheMenu[2] = content.Load<Texture2D>("MenuCharacters/hero3");
            rightButtons[0] = content.Load<Texture2D>("Buttons/rigt1");
            rightButtons[1] = content.Load<Texture2D>("Buttons/right2");
            leftButtons[0] = content.Load<Texture2D>("Buttons/left1");
            leftButtons[1] = content.Load<Texture2D>("Buttons/left2");
            MeasureMenu();
        }

        public int SelectedIndexCharacter { get { return this.selectedIndexCharacter; } }
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
                selectedIndexContent++;
                if (selectedIndexContent == menuItems.Length)
                {
                    selectedIndexContent = 0;
                }
            }
            if (CheckKey(Keys.Up))
            {
                selectedIndexContent--;
                if (selectedIndexContent < 0)
                {
                    selectedIndexContent = menuItems.Length - 1;
                }
            }
            if (CheckKey(Keys.Right))
            {
                selectedIndexCharacter++;
                if (selectedIndexCharacter == charactersInTheMenu.Length)
                {
                    selectedIndexCharacter = 0;
                }
            }
            if (CheckKey(Keys.Left))
            {
                selectedIndexCharacter--;
                if (selectedIndexCharacter < 0)
                {
                    selectedIndexCharacter = charactersInTheMenu.Length - 1;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                switch (selectedIndexContent)
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
                if (i == selectedIndexContent)
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
            spriteBatch.Draw(charactersInTheMenu[selectedIndexCharacter], new Rectangle(480, 100, 150, 300), Color.White);
            spriteBatch.Draw(leftButtons[0], new Rectangle(420, 230, 40, 40), Color.White);
            spriteBatch.Draw(rightButtons[0], new Rectangle(650, 230, 40, 40), Color.White);
            spriteBatch.End();
        }
    }
}