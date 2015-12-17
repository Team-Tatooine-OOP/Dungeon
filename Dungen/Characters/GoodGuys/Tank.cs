﻿using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OopProject.Characters.GoodGuys
{
    public class Tank : GoodGuys
    {
        private const int Health = 300;
        private const int Mana = 100;
        public Tank(string name)
            : base(name)
        {

        }

        public override void LoadContent(ContentManager content)
        {

            this.currentCharacter = content.Load<Texture2D>("TextureAtlases/Mage");
        }
    }
}
