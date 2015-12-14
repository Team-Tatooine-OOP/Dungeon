<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using Dungen.Characters.GoodGuys;
using Dungen.Interfaces;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OopProject.Characters.GoodGuys;
=======
﻿using Dungen.Characters.GoodGuys;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using IDrawable = OopProject.Interfaces.IDrawable;
>>>>>>> origin/master

namespace Dungen
{
    using Dungen.Characters.Villians;

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D magicType;
        private Texture2D background; // Initialize field for warrior image
        private GoodGuys myMage;
        private List<IDrawMagic> magics;
        private DrawMagic myMagic;
        private float timeSinceLastChange = 0f; //for counting the seconds
        private KeyboardState mprevious;
        private int counter = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
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
<<<<<<< HEAD
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

=======
            myMage.LoadContent(Content);
            myMage.Update(gameTime);
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
>>>>>>> origin/master
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
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
            base.Draw(gameTime);
            spriteBatch.End();
        }

    }
}
