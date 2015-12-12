using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OopProject.Characters.GoodGuys
{
    class Warrior : GoodGuys
    {
        private const int Health = 200;
        private const int Mana = 200;
        private double x;
        private double y;

        public Warrior(string name)
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
