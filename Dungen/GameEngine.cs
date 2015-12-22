using System;
using System.Collections.Generic;
using System.Globalization;
using Dungen.Characters.GoodGuys;
using Dungen.Characters.Villians;
using Dungen.Interfaces;
using Dungen.Magic;
using Dungen.Menu;
using Dungen.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OopProject.Characters.GoodGuys;
using OopProject.Characters.Villians;

namespace Dungen
{
    // using Dungen.Intro;

    public class GameEngine : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D magicType;
        private SpriteFont font;
        private MenuComponent menuComponent;
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
        private string[] menuItems;
        private int charState = 2;
        private int height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + 25;
        private int width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 + 45;
        private Brick[,] bricks;
        private int currIndex = 1;
        private bool isCharSelected = true;
        private bool isIntersect = true;
        BadGuys monster; //monster
        private AnimatedSprite animatedSprite; //monster
        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            menuItems = new[] { "Start Game", "High Scores", "End Game" };
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            monster = new Monster1("Some"); //monster
            monster.LoadContent(Content); //monster
            Texture2D texture = Content.Load<Texture2D>("TextureAtlases/Mage"); //monster
            animatedSprite = new AnimatedSprite(texture, 4, 4); //monster
            bricks = new Brick[770, 450];
            Bricks(bricks, Content);
            mainCharacter = new Mage("Misho");
            mainCharacter.LoadContent(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font/font");
            magics = new List<IDrawMagic>();
            magicType = Content.Load<Texture2D>("TextureAtlases/Fire");
            background = Content.Load<Texture2D>("TextureAtlases/Backround3");
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            menuComponent = new MenuComponent(this, spriteBatch, font, menuItems, Content);
            Components.Add(menuComponent);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastX = mainCharacter.movingVector2.X;
            lastY = mainCharacter.movingVector2.Y;
            menuComponent.Update(gameTime);
            animatedSprite.Update();//monster
            monster.Update(gameTime); //monster
            CharSelection();
            mainCharacter.Update(gameTime);
            IntersectRectangel(mainCharacter, bricks);
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
            string lastState = CharacterState(mainCharacter.movingVector2.X, mainCharacter.movingVector2.Y);
            UpdateBullet(gameTime, lastState);


            base.Update(gameTime);
        }

        private void CharSelection()
        {
            int index = menuComponent.SelectedIndexCharacter;

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter) && isCharSelected)
            {
                MainCharacter(index);
                isCharSelected = false;
            }

        }

        private void IntersectRectangel(GoodGuys goodGuys, Brick[,] bricks1)
        {
            for (int row = 0; row < bricks1.GetLength(0); row++)
            {
                for (int col = 0; col < bricks1.GetLength(1); col++)
                {
                    if (bricks1[row, col] != null)
                    {
                        //if (goodGuys.destinationRectangle.X > bricks1[row, col].rectangle.X)
                        //{
                        //    goodGuys.movingVector2.X = lastX;
                        //    goodGuys.movingVector2.Y = lastY;
                        //}
                    }
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (menuComponent.IsPlayed)
            {
                this.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 450), Color.White);//IMPORTANT! First draw background
                BrickDraw(bricks);
                animatedSprite.Draw(spriteBatch, new Vector2(monster.X, monster.Y)); //monster
                foreach (var drawMagic in magics)
                {
                    drawMagic.Draw(spriteBatch);
                }
                for (int i = 0; i < magics.Count; i++)
                {
                    if (CheckOutOFScreen(magics[i].X, magics[i].Y))
                    {
                        magics.Remove(magics[i]);
                    }
                }
                mainCharacter.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void BrickDraw(Brick[,] bricks1)
        {
            for (int row = 0; row < bricks1.GetLength(0); row++)
            {
                for (int col = 0; col < bricks1.GetLength(1); col++)
                {
                    if (bricks1[row, col] != null)
                    {
                        bricks1[row, col].Draw(spriteBatch);
                    }
                }
            }
        }

        private void Bricks(Brick[,] bricks1, ContentManager content)
        {
            Brick some = new Brick(10, 20);
            for (int row = 0; row < bricks1.GetLength(0); row++)
            {

            }
            Console.WriteLine();
        }

        private void MainCharacter(int characterNum)
        {
            switch (characterNum)
            {
                case 0:
                    mainCharacter = new Mage("Misho");
                    currIndex = 0;
                    break;
                case 1:
                    mainCharacter = new Tank("Simeon");
                    currIndex = 1;
                    break;
                case 2:
                    mainCharacter = new Warrior("Pavleta");
                    currIndex = 2;
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
