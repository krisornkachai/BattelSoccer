using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace BattelSoccor.Sprites
{
    class Charecctor : Sprite
    {
       
        //bool pressBottom = false;
        // private Charactersteam charactersteam;
        public int movecharacter = 3;
        bool up, jumpup = false;
        private List<Texture2D> texture2DList;

        //public bool Hb = false;
        public Charecctor(Texture2D texture, List<Texture2D> ListCha, string Charac)

            : base(texture)
        {
            Speed = 5f;
            name = Charac;
            texture2DList = ListCha;
            //  charactersteam = new Charactersteam(texture, 4, 6);
            // var left = Content.Load<Texture2D>("Charector");

        }

        public void NextMove(List<Texture2D> cha)
        {

            _texture = cha[1];
            
        }

        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            if (Input == null)
            {
                throw new Exception("Pleses give a value to input");
            }

            if (Keyboard.GetState().IsKeyDown(Input.right))
            {
                Velocity.X = 3f;
                _texture = texture2DList[2];
                // movecharacter = 1;
                // pressBottom = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.left))
            {
                Velocity.X = -3f;
                //movecharacter = 0;
                //pressBottom = true;
            }
            else Velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Input.jump) && up == false)
            {
                jumpup = true;
            }
            if (jumpup == true)
            {
                float i = 1;
                Position.Y -= 7.5f * i;//up
                if (Position.Y < 140f)
                {
                    up = true;
                }
            }

            if (up == true)
            {
                float i = 1;
                Velocity.Y += 7.5f * i;  //down
                jumpup = false;
            }

            if (Position.Y + _texture.Height >= 386.5)
            {
                up = false;
            }
            if (up == false)
            {
                Velocity.Y = 0f;
            }


            foreach (var sprite in sprites)
            {

                if (sprite == this) continue;
                if (sprite.name == "Ball") continue;

                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;

                }

                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;

                }
                if (this.Velocity.Y > 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;

                }

                if (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;

                }




            }


            if ((Position.X <= 0 || Position.X + _texture.Width >= Game1.screenWidth))


            {
                if (Position.X <= 0)
                {
                    Position.X = 1;
                }
                else if (Position.X + _texture.Width >= Game1.screenWidth)
                {
                    Position.X = Game1.screenWidth - 1 - _texture.Width;
                }

            }


            Position += Velocity;
            // Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.screenHeingt - _texture.Height);
            Velocity = Vector2.Zero;



        }
    }
}