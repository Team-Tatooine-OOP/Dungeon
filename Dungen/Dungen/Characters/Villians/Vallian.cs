using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Characters.GoodGuys;

namespace OopProject.Characters.Villians
{
    class Vallian : Character
    {
        private const int Health = 200;
        private const int Mana = 300;
        private static int randomNumber = 0;
        public Vallian(string name, Texture2D texture2D, int x, int y)
            : base(name, Health, Mana, texture2D, x, y)
        {
        }


        public static Vector2 NewPos(Vector2 vector) // get random position for x or y to move for  second
        {
            float x = vector.X;
            float y = vector.Y;

            Random rnd = new Random();
            randomNumber = rnd.Next(1, 5);
            switch (randomNumber)
            {
                case 1:
                    x -= 3;
                    break;
                case 2:
                    x += 3;
                    break;
                case 3:
                    y -= 3;
                    break;
                case 4:
                    y += 3;
                    break;
            }
            return new Vector2(x, y);
        }

        public static Vector2 Move(Vector2 vector) // moving  second in this direction (x or y)
        {
            float x = vector.X;
            float y = vector.Y;

            switch (randomNumber)
            {
                case 1:
                    x -= 3;
                    break;
                case 2:
                    x += 3;
                    break;
                case 3:
                    y -= 3;
                    break;
                case 4:
                    y += 3;
                    break;
            }
            return new Vector2(x, y);
        }
    }
}
