using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestMenu
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameState CurrentState = GameState.MainMenu;

        private int screenWidth = 800, screenHeight = 600;
        private cButton btnPlay;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            btnPlay = new cButton(Content.Load<Texture2D>("button"), graphics.GraphicsDevice);
            btnPlay.SetPosition(new Vector2(10, 10));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            MouseState mouse = Mouse.GetState();
            switch (CurrentState)
            {
                    case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        CurrentState = GameState.Playing;
                        btnPlay.Update(mouse);
                    }
                    break;
                    case  GameState.Playing:
                    break;
                    
            }

            base.Update(gameTime);
        }

       protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("background"), new Rectangle(0,0,screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    break;
                case GameState.Playing:
                    break;

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
