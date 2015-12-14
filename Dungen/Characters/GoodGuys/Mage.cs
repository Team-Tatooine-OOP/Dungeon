<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using Dungen.Magic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dungen.Characters.GoodGuys
{
    public class Mage : OopProject.Characters.GoodGuys.GoodGuys
=======
﻿namespace Dungen.Characters.GoodGuys
{
    using System;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public class Mage : GoodGuys
>>>>>>> origin/master
    {
        private const int Health = 100;
        private const int Mana = 300;
        public Mage(string name)
            : base(name)
        {
        }

<<<<<<< HEAD
        public void Update(GameTime gameTime)
=======
        public override void UnloadContent()
>>>>>>> origin/master
        {

        }


        public override void LoadContent(ContentManager content)
        {
            this.currentCharacter = content.Load<Texture2D>("TextureAtlases/Mage");
        }

    }
}
