using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattelSoccor.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace BattelSoccor.Sprites
{
    class Sprite
    {
        public bool hitball = false;
        protected Texture2D _texture;
        public string name = "bg";
        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public Input Input;
        public Color[]textureData;
        //public bool HB = false;
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }

        }

        public Sprite(Texture2D texture)
        {

            _texture = texture;

        }


        public virtual void Update(GameTime gametime, List<Sprite> sprites)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_texture, Position, Color.White);
        }

        #region collision
        protected bool IsTouchingLeft(Sprite sprite)
        {

            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Left &&
                   this.Rectangle.Bottom > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Bottom;

        }

        protected bool IsTouchingRight(Sprite sprite)
        {

            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
                   this.Rectangle.Right > sprite.Rectangle.Right &&
                   this.Rectangle.Bottom > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Bottom;

        }

        protected bool IsTouchingTop(Sprite sprite)
        {

            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
                   this.Rectangle.Top < sprite.Rectangle.Top &&
                   this.Rectangle.Right > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Right;

        }

        protected bool IsTouchingBottom(Sprite sprite)
        {

            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                   this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                   this.Rectangle.Right > sprite.Rectangle.Left &&
                   this.Rectangle.Left < sprite.Rectangle.Right;

        }

        #endregion

        protected bool IntersecsPixel(Rectangle rect1,Color[] data1,Rectangle rect2,Color[] data2)
        {
            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for(int y = top;y< bottom; y++)
            {
                for(int x = left; x < right; x++)
                {
                    Color colour1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
                    Color colour2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];
                 if (colour1.A != 0 && colour2.A != 0) return true; }
              

            }
            return false;
        }
    }
}
