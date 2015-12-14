using System;
using System.Collections.Generic;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Characters.Villians;

namespace Dungen.Characters.Villians
{
    public class Monster1 : OopProject.Characters.Villians.BadGuys
    {
        private const int Health = 50;
        private const int Mana = 300;
        private AnimatedSprite animatedSprite;
        public Monster1(string name)
            : base(name)
        {
        }

        public void Update(GameTime gameTime)
        {
            animatedSprite.Update();
        }


        public override void LoadContent(ContentManager content)
        {
            this.currentCharacter = content.Load<Texture2D>("TextureAtlases/SmileyWalk");
            animatedSprite = new AnimatedSprite(this.currentCharacter, 4, 4);
        }

        

    }
}
