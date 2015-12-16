using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Characters.GoodGuys;

namespace OopProject.Characters.Villians
{
    class Vallian : DrawCharacter
    {
        private const int Health = 200;
        private const int Mana = 300;
        private static int randomNumber = 0;
        public Vallian(string name, Texture2D texture2D, int x, int y)
            : base(name)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

    }
}
