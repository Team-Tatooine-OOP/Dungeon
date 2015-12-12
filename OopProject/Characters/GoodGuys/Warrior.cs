using System;
using Microsoft.Xna.Framework.Graphics;

namespace OopProject.Characters.GoodGuys
{
    class Warrior : Character
    {
        private const int Health = 200;
        private const int Mana = 200;
        private double x;
        private double y;

        public Warrior(string name, Texture2D text, int x, int y)
               : base(name, Mana, Health, text, x, y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
