using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Interfaces;

namespace OopProject.Characters.GoodGuys
{
    public abstract class GoodGuys : DrawCharacter
    {
        public int Health { get; set; }

        public int Mana { get; set; }

        public Texture2D Texture2D { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        protected GoodGuys(string name)
            : base(name)
        {

        }
        public override void UnloadContent()
        {
            throw new System.NotImplementedException();
        }
    }
}
