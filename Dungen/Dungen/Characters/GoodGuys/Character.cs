using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Interfaces;

namespace OopProject.Characters.GoodGuys
{
    public abstract class Character
    {
        public int Health { get; set; }

        public int Mana { get; set; }

        public string Name { get; set; }

        //List<Item> Inventory { get; set; }

        public Texture2D Texture2D { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Character(string name, int health, int mana, Texture2D texture2D, int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Texture2D = texture2D;
            this.Health = health;
            this.Mana = mana;
            //Inventory = new List<Item>();
        }


    }
}
