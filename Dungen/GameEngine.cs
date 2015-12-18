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
    using Dungen.Intro;

    public class GameEngine : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D magicType;
        private SpriteFont font;
        //private Texture2D bot;
        //private Texture2D villian; // Initialize field for villian image
        //private Texture2D warrior; // Initialize field for warrior image
        private Texture2D background;
        private GoodGuys mainCharacter;
        private List<IDrawMagic> magics;
        private DrawMagic myMagic;
        private float timeSinceLastChange = 0f; //for counting the seconds
        private Texture2D menuBackground;
        private KeyboardState mprevious;
        private float lastX;
        private float lastY;
        private GameTime _gameTime;
        private string equalsState = "Down";
        private string state;
        private int charState = 2;
        private int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + 25;
        private int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 + 45;
        

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            mainCharacter = new Mage("Misho");
            mainCharacter.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font/font");
            magics = new List<IDrawMagic>();
            magicType = Content.Load<Texture2D>("TextureAtlases/Fire");
            background = Content.Load<Texture2D>("TextureAtlases/Backround3");
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastX = mainCharacter.movingVector2.X;
            lastY = mainCharacter.movingVector2.Y;
            mainCharacter.Update(gameTime);
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
            string lastState = CharacterState(mainCharacter.movingVector2.X, mainCharacter.movingVector2.Y);
            UpdateBullet(gameTime, lastState);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //if (menuComponent.IsPlayed == true)

            this.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            //IMPORTANT! First draw background

            foreach (var drawMagic in magics)
            {
                drawMagic.Draw(spriteBatch);
            }

            mainCharacter.Draw(spriteBatch);

            base.Draw(gameTime);
            spriteBatch.End();
        }

        private void MainCharacter(int characterNum)
        {
            switch (characterNum)
            {
                case 0:
                    mainCharacter = new Mage("Misho");

                    break;
                case 1:
                    mainCharacter = new Tank("Simeon");
                    break;
                case 2:
                    mainCharacter = new Warrior("Pavleta");
                    break;
                default:
                    throw new NotImplementedException("No such a character");
            }
            mainCharacter.LoadContent(Content);
        }


        private string CharacterState(float x, float y)
        {

            if (x == lastX && y == lastY)
            {
                state = equalsState;
            }
            if (x != lastX)
            {
                if (x > lastX)
                {
                    state = "Right";
                }
                else
                {
                    state = "Left";
                }
            }
            if (y != lastY)
            {
                if (y > lastY)
                {
                    state = "Up";
                }
                else
                {
                    state = "Down";

                }
            }
            equalsState = state;
            return state;
        }

        public void UpdateBullet(GameTime gameTime, string state)
        {
            KeyboardState fireState = Keyboard.GetState();
            foreach (var drawMagic in magics)
            {
                drawMagic.Update(gameTime);

            }

            if (fireState.IsKeyDown(Keys.Space) && mprevious.IsKeyDown(Keys.Space) == false)
            {
                myMagic = new MageMagic((int)mainCharacter.movingVector2.X, (int)mainCharacter.movingVector2.Y,
                    magicType, state);
                magics.Add(myMagic);
            }
            mprevious = fireState;
        }

        private bool CheckOutOFScreen(int currX, int currY)
        {
            bool isOut = false;

            if (currX < 0 || currX > width)
            {
                isOut = true;
            }
            if (currY > height || currY < 0)
            {
                isOut = true;
            }
            return isOut;
        }
    }
}
