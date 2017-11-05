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
    class Charecctor : Sprite
    {

        bool up ,jumpup = false;
        
        public Bat(Texture2D texture)

        public Charecctor(Texture2D texture)
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

            if (Keyboard.GetState().IsKeyDown(Input.right)) Velocity.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Input.left)) Velocity.X = -3f;
            else Velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Input.jump)&&up==false)
            {
                Velocity.X = -Speed;
            }
            if(jumpup == true)
            {
                float i = 1;
                Position.Y -= 7.5f * i;//up
                if (Position.Y<140f)
                {
                    up = true;
                }
            }

            if(up == true)
            {
                float i = 1;
                Velocity.Y += 7.5f * i;  //down
                jumpup = false;
            }

            if (Position.Y + _texture.Height >=386.5)
            {
                up = false;
            }
            if(up == false)
            {
                Velocity.Y = 0f;


            foreach (var sprite in sprites)
            {
                if (sprite == this) continue;

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                    this.Velocity.X = -this.Velocity.X;
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                    this.Velocity.Y = -this.Velocity.Y;
                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                    this.Velocity.Y = -this.Velocity.Y;
            }


            if ((Position.X <= 0 || Position.X + _texture.Width >= Game1.screenWidth))


            {
                Velocity.X = -Velocity.X;
            }

            Position += Velocity;
                // Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.screenHeingt - _texture.Height);
                Velocity = Vector2.Zero;



            }
        }
    }