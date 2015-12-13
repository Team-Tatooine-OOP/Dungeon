using Dungen.Characters.GoodGuys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using IDrawable = OopProject.Interfaces.IDrawable;

namespace Dungen
{
    using Dungen.Characters.Villians;

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D bot;
        private Texture2D villian; // Initialize field for villian image
        private Texture2D warrior; // Initialize field for warrior image
        private Texture2D background; // Initialize field for warrior image
        private IDrawable myMage;
        private Vallian[] vallians = new Vallian[3]; //init 3 vallians
        private float timeSinceLastChange = 0f; //for counting the seconds

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            myMage = new Mage("Misho");
            myMage.LoadContent(Content);
            background = Content.Load<Texture2D>("TextureAtlases/amarati");
            vallians[0] = new Vallian("First", villian, 50, 50);
            vallians[1] = new Vallian("Second", villian, 150, 50);
            vallians[2] = new Vallian("Thirt", villian, 250, 50);
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // UnloadContent will be called once per game and is the place to unload game-specific content.
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                 || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            myMage.LoadContent(Content);
            myMage.Update(gameTime);
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White); //IMPORTANT! First draw background
            myMage.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
