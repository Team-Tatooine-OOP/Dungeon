namespace Dungen.Characters.GoodGuys
{
    using System;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Mage : GoodGuys
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
