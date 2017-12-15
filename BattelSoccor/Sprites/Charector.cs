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
        int coutframe=0;
        bool oldkeyisdash = false;
        //bool pressBottom = false;
        // private Charactersteam charactersteam
        public int dashnum=0;
        int spritepower = 8;
        public int movecharacter = 3;
        bool up, jumpup = false;
        bool touchpoweron = true;
        int powercout = 0;
        int unticount = 0;
        private List<Texture2D> texture2DListMoveright;
        private List<Texture2D> powertexture;
        private List<Texture2D> untitexture;
        int moverightc1=0;

        //public bool Hb = false;
        public Charecctor(Texture2D texture, List<Texture2D> ListCha, List<Texture2D> ListPow, List<Texture2D> ListUnti, string Charac)

            : base(texture,Charac)
        {
            Speed = 5f;
            name = Charac;
            texture2DListMoveright = ListCha;
            powertexture = ListPow;
            untitexture = ListUnti;
            //  charactersteam = new Charactersteam(texture, 4, 6);
            // var left = Content.Load<Texture2D>("Charector");

        }

        public void NextMoveright(List<Texture2D> cha)
        {
            coutframe++;
            if (coutframe > 3) {
                coutframe = 0;
            if (moverightc1 < 5)
            {

                moverightc1++;
            }
            else { moverightc1 = 0; }

              _texture = cha[moverightc1];
            }
        }



        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            dash = false;
            textureData = new Color[_texture.Width *_texture.Height];
            _texture.GetData(textureData);
            if (Input == null)
            {
                throw new Exception("Pleses give a value to input");
            }

            if (Keyboard.GetState().IsKeyDown(Input.right))
            {
                 oldkeyisdash = false;
                oldKeyIsLeft = false;
                Velocity.X = 3f;
                NextMoveright(texture2DListMoveright);
                // movecharacter = 1;
                // pressBottom = true;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.left))
            {
                 oldkeyisdash = false;
                oldKeyIsLeft = true;
                Velocity.X = -3f;
                NextMoveright(texture2DListMoveright);
                //movecharacter = 0;
                //pressBottom = true;
            }else if (Keyboard.GetState().IsKeyDown(Input.dash) && !oldkeyisdash)
            {   if (sprites[4].healbartab > -1) {
                if (this.name == "Charac_1")
                    sprites[4].healbartab--;
                    oldkeyisdash = true;
                    dash = true;
                    dashnum = 10;
                }

                if (sprites[5].healbartab > -1)
                {
                    if (this.name == "Charac_2")
                        sprites[5].healbartab--;
                    oldkeyisdash = true;
                    dash = true;
                    dashnum = 10;
                }
              /*  if (oldKeyIsLeft)
                {
                 Velocity.X = -8f;
                }
                else
                {
                    Velocity.X = 8f;

                }*/
               
                
                NextMoveright(texture2DListMoveright);
                //movecharacter = 0;
                //pressBottom = true;
            }
             else Velocity.X = 0f;

            if (dashnum > 0)
            {   if(this.name== "Charac_1")
                Velocity.X = 8f;

                if (this.name == "Charac_2")
                    Velocity.X = -8f;

                dashnum--;
            }
            if (dashnum == 0)
            {
                dash = false;
            }

            if (Keyboard.GetState().IsKeyDown(Input.jump) && up == false)
            {
                 oldkeyisdash = false;
                NextMoveright(texture2DListMoveright);
                jumpup = true;
            }
            if (Keyboard.GetState().IsKeyDown(Input.power)){

                if (name == "Charac_1" && sprites[4].healbartab > 10)
                {
                    if (!sprites[2].untiOn && !sprites[2].powerOn) { 
                    spritepower = 8;
                    unticount = 1;
                    sprites[spritepower]._texture = powertexture[powercout];
                    untiOn = true;}

                }

                if (name == "Charac_2" && sprites[5].healbartab > 10)
                {
                    if (!sprites[1].untiOn && !sprites[1].powerOn)
                    {
                        spritepower = 8;
                        unticount = 1;
                        sprites[spritepower]._texture = powertexture[powercout];
                        untiOn = true;
                    }
                }






            }



            if (unticount > 0)
            {
                untiOn = true;
                unticount++;
                if (this.IsTouchingRight(sprites[3]) || this.IsTouchingLeft(sprites[3]) || this.IsTouchingTop(sprites[3]))
                {
                    untiOn = false;
                    sprites[3].Position.X = this.Position.X-50;
                    sprites[3].Position.Y = this.Position.Y -50;
                    unticount = 0;
                    sprites[spritepower+1].Position.X = 0;
                    sprites[spritepower+1].Position.Y = 0;
                    powercout = 1;

                }
                if(name== "Charac_2") {
                sprites[spritepower+1]._texture = untitexture[unticount%8];
                sprites[spritepower+1].Position.X = this.Position.X - 130;
                sprites[spritepower+1].Position.Y = this.Position.Y - 120;
                    sprites[5].healbartab = 0;
                }

                if (name == "Charac_1")
                {
                    sprites[spritepower + 1]._texture = untitexture[unticount % 8];
                    sprites[spritepower + 1].Position.X = this.Position.X - 100;
                    sprites[spritepower + 1].Position.Y = this.Position.Y - 120;
                    sprites[4].healbartab = 0;
                }
            }



            if (powercout > 0)
                {
                powerOn = true;
                    powercout++;
                if (powercout > 16)
                    {
                   
                    powerOn = false;
                        powercout = 0;
                    sprites[spritepower].Position.X = 0;
                    sprites[spritepower].Position.Y =0;
                }

                if (name == "Charac_2")
                {
                    sprites[spritepower]._texture = powertexture[powercout];
                    sprites[spritepower].Position.X = sprites[3].Position.X - 70;
                    sprites[spritepower].Position.Y = sprites[3].Position.Y - 70;
                }
                if (name == "Charac_1")
                {
                    sprites[spritepower]._texture = powertexture[powercout];
                    sprites[spritepower].Position.X = sprites[3].Position.X - 70;
                    sprites[spritepower].Position.Y = sprites[3].Position.Y - 70;
                }

            }

            

            if (jumpup == true)
            {
                float i = 1;
                Position.Y -= 7.5f * i;//up
                if (Position.Y < 200f)
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

            if (Position.Y + _texture.Height >= 400)
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
                if (sprite.name == "unti1") continue;
                if (sprite.name == "power1") continue;
                if (sprite.name == "unti2") continue;
                if (sprite.name == "power2") continue;
                if (sprite.name == "HB1") continue;
                if (sprite.name == "HB2") continue;
                if (sprite.name == "gola") continue;
                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;

                }

                if (this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                {
                    this.Velocity.X = -this.Velocity.X;

                }
                if (this.Velocity.Y < 0 && this.IsTouchingTop(sprite))
                {
                    this.Velocity.Y = -this.Velocity.Y;

                }

                if (this.Velocity.Y > 0 && this.IsTouchingBottom(sprite))
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