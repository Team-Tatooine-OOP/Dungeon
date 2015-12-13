namespace Dungen.Characters.GoodGuys
{
    using System;

    using Microsoft.Xna.Framework.Content;

    public class Tank : GoodGuys
    {
        private const int Health = 300;
        private const int Mana = 100;

        public Tank(string name)
            : base(name)
        {

        }

        public override void UnloadContent()
        {
            throw new NotImplementedException();
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }
    }
}
