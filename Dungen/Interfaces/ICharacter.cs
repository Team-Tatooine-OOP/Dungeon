﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace OopProject.Interfaces
{
    interface ICharacter
    {
        void LoadContent(ContentManager content);
        void Update(GameTime gametime);
        void Draw(SpriteBatch spriteBatch);
    }
}
