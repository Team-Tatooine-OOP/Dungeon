using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Characters.GoodGuys
{
    public class Mage : OopProject.Characters.GoodGuys.GoodGuys
    {
        private const int Health = 100;
        private const int Mana = 300;

        public Mage(string name)
            : base(name)
        {

        }

        public override void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            this.currentCharacter = content.Load<Texture2D>("TextureAtlases/Mage");
        }
    }
}
