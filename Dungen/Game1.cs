using System;
using System.Collections.Generic;
using Dungen.Characters.GoodGuys;
using Dungen.Interfaces;
using Dungen.Magic;
using Dungen.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OopProject.Characters.GoodGuys;

namespace Dungen
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D magicType;
        private MenuComponent menuComponent;
        private SpriteFont font;
        //private Texture2D bot;
        //private Texture2D villian; // Initialize field for villian image
        //private Texture2D warrior; // Initialize field for warrior image
        private Texture2D background; // Initialize field for warrior image
        private GoodGuys myMage;
        private List<IDrawMagic> magics;
        private DrawMagic myMagic;
        private float timeSinceLastChange = 0f; //for counting the seconds
        private Texture2D menuBackground;
        private KeyboardState mprevious;
        private int counter = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
            string[] menuItems = { "Start Game", "High Scores", "End Game" };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font/font");
            menuComponent = new MenuComponent(this,spriteBatch, font, menuItems, Content);
            Components.Add(menuComponent);
            magics = new List<IDrawMagic>();
            myMage = new Mage("Misho");
            magicType = Content.Load<Texture2D>("TextureAtlases/Fire");
            myMage.LoadContent(Content);
            background = Content.Load<Texture2D>("TextureAtlases/amarati");
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            myMagic = new MageMagic(magicType);
            myMagic.LoadContent(Content);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                 || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            myMage.Update(gameTime);
            KeyboardState fireState = Keyboard.GetState();

            foreach (var drawMagic in magics)
            {
                drawMagic.Update(gameTime);
            }
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
            if (fireState.IsKeyDown(Keys.Space) && mprevious.IsKeyDown(Keys.Space) == false)
            {
                myMagic = new MageMagic((int)myMage.movingVector2.X, (int)myMage.movingVector2.Y, magicType);
                magics.Add(myMagic);
            }
            mprevious = fireState;

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (menuComponent.IsPlayed == true)
            {
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White); //IMPORTANT! First draw background
            if (magics.Count > 0)
            {
                for (int i = 0; i < counter; i++)
                {

                    magics[i].Draw(spriteBatch);

                }
                counter++;
                counter = Math.Min(counter, magics.Count);
            }

            myMage.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }

    }
}
