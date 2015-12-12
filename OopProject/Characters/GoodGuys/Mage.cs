using System;
using Microsoft.Xna.Framework.Graphics;

namespace OopProject.Characters.GoodGuys
{
    public class Mage : DrawCharacter
    {
        private const int Health = 100;
        private const int Mana = 300;
        public Mage(string name, Texture2D texture2D)
            : base(name)
        {

        }


        public override void UnloadContent()
        {
            throw new NotImplementedException();
        }
    }
}
