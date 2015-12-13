namespace Dungen.Characters.GoodGuys
{
    using Dungen.Characters;
    using Dungen.Interfaces;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public abstract class GoodGuys : DrawCharacter, IMovable
    {
        protected Texture2D currentCharacter;

        private int row;
        private int endCol;
        private int currentFrame;
        private Vector2 movingVector2;

        protected GoodGuys(string name)
            : base(name)
        {
        }

        public int Health { get; set; }

        public int Mana { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public override void Update(GameTime gameTime)
        {
            this.Moving();
        }

        public void Moving()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Left))
            {
                this.movingVector2.X -= 3;
            }
            else if (newState.IsKeyDown(Keys.Right))
            {
                this.movingVector2.X += 3;
            }
            else if (newState.IsKeyDown(Keys.Up))
            {
                this.movingVector2.Y -= 3;
            }
            else if (newState.IsKeyDown(Keys.Down))
            {
                this.movingVector2.Y += 3;
            }
        }

        public override void UnloadContent()
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int width = 64;
            int height = 64;
            int column = this.currentFrame % 4;
            Rectangle sourceRectangle = new Rectangle(width * column, height * this.row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.movingVector2.X, (int)this.movingVector2.Y, width, height);
            spriteBatch.Draw(this.currentCharacter, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
