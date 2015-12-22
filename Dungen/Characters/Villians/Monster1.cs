using System;
using System.Collections.Generic;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OopProject.Characters.Villians;

namespace Dungen.Characters.Villians
{
    public class Monster1 : OopProject.Characters.Villians.BadGuys
    {
        private const int Health = 50;
        private const int Mana = 10;
        private AnimatedSprite animatedSprite;

        /*
        public class Game1 : Game

        BadGuys monster; //monster
        private AnimatedSprite animatedSprite; //monster


       LoadContent
      

       Update
       animatedSprite.Update();//monster
       monster.Update(gameTime); //monster

       Draw
       animatedSprite.Draw(spriteBatch, new Vector2(monster.X, monster.Y)); //monster

    */


        //    public int X
        //    {
        //        get { return this.x; }
        //        set { this.x = value; }
        //    }
        //
        //    public int Y
        //    {
        //        get { return this.y; }
        //        set { this.y = value; }
        //    }

        public Monster1(string name)
            : base(name)
        {

        }


        public override void LoadContent(ContentManager content)
        {
            // this.currentCharacter = content.Load<Texture2D>("TextureAtlases/SmileyWalk");
            this.currentCharacter = content.Load<Texture2D>("TextureAtlases/Mage");

            
        }




    }
}
