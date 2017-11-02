using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BattelSoccor.Sprites
{
    class Bat : Sprite
    {
        public Bat(Texture2D texture)
            : base(texture)
        {
            Speed = 5f;
        }

        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Pleses give a value to input");
            }

            if (Keyboard.GetState().IsKeyDown(Input.left))
            {
                Velocity.X = -Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.right))
            {
                Velocity.X = Speed;
            }

            else if (Keyboard.GetState().IsKeyDown(Input.jump))
            {
                Velocity.Y = Speed;
            }


            Position += Velocity;
           // Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.screenHeingt - _texture.Height);
            Velocity = Vector2.Zero;
        }
    }
}
