using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BattelSoccor.Sprites
{
    class Ball : Sprite
    {
        private float keeppos;
        private float _timer = 0f;
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        private float tg = 0, g = 9.8f;
        private float vx = 0, vy = 0;
        public Score score;
        public int SpeedIncrementSpan = 10;
        private Vector2 root2;

        public Ball(Texture2D texture)
            : base(texture,"Ball")
        {
            Speed = 3f;
            name = "Ball";

        }

        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = Position;
                _startSpeed = Speed;

                Restart();


            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

                _isPlaying = true;
            }
            if (!_isPlaying) return;

            _timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            tg = (float)gametime.ElapsedGameTime.TotalSeconds;

            if (_timer > SpeedIncrementSpan)
            {
                Speed++;
                _timer = 0;


            }

            foreach (var sprite in sprites)
            {
                if (sprite == this) continue;
                if (sprite.name == "healthbar") continue;
              //  if (sprite.name == "bg") continue;

                if (sprite.name == "Charac_1")
                {
                    if (this.IsTouchingLeft(sprite))
                    {
                        if (sprites[1].dash)
                        {
                            sprites[4].hitball = true; // Healbar
                            vx = 17;
                            vy += 7;

                        }
                        else { 
                            //if(sprites[4].oldKeyIsLeft)
                            sprites[4].hitball = true; // Healbar
                        vx = 7;
                        vy += 3;
                        this.vx = -this.vx;}

                    }
                    if (this.IsTouchingRight(sprite))
                    {
                        if (sprites[1].dash) { 
                            sprites[4].hitball = true; // Healbar
                        vx = -17;
                        vy += 7;
                        this.vx = -this.vx;
                        }
                        else
                        {  sprites[4].hitball = true; // Healbar
                            vx = -7;
                            vy += 3;
                            this.vx = -this.vx;
                        }


                    }
                    if (this.IsTouchingTop(sprite))
                    {
                        sprites[4].hitball = true; // Healbar
                        this.vy = sprites[4].Velocity.Y + 10; /*  Velocity.Y += 10f;
                                                        this.Velocity.Y = -this.Velocity.Y;*/
                        vy += 2;
                   
                        if (vy > 6)
                        {
                            vy += -3;
                        }
                        this.vy = -this.vy;
                    }
                  if (this.IsTouchingBottom(sprite))
                    {
                        sprites[4].hitball = true; // Healbar
                        vx = -7;
                        vy += 3;
                        this.vx = -this.vx;
                    }
                }
                if (sprite.name == "Charac_2")
                {
                    if (this.IsTouchingLeft(sprite))
                    {    if(sprites[2].dash)
                        {
                            sprites[5].hitball = true; // Healbar
                            vx = 17;
                            vy += 7;

                        }
                        else { 
                        sprites[5].hitball = true; // Healbar
                        vx = 7;
                        vy += 3;
                        this.vx = -this.vx;}

                    }
                    if (this.IsTouchingRight(sprite))
                    {
                        if (sprites[2].dash)
                        {
                            sprites[5].hitball = true; // Healbar
                            vx = -17;
                            vy += 7;
                            this.vx = -this.vx;
                        }
                        else {
                            sprites[5].hitball = true; // Healbar
                        vx = -7;
                        vy += 3;
                        this.vx = -this.vx;
                          }

                    }
                    if (this.IsTouchingTop(sprite))
                    {
                        sprites[5].hitball = true; // Healbar
                                                   /*  Velocity.Y += 10f;
                                                     this.Velocity.Y = -this.Velocity.Y;*/
                        this.vy = sprites[5].Velocity.Y + 10;                           /*  Velocity.Y += 10f;
                                                     this.Velocity.Y = -this.Velocity.Y;*/

                        vy += 2;


                        vy += 3;
                        if (vy > 6)
                        {
                            vy += -3;
                        }
                        this.vy = -this.vy;
                    }
                  /*  if (this.IsTouchingBottom(sprite))
                    { this.vy = -this.vy;
                        vx = -5;
                    }*/
                }


            }
            vy = (vy + (g * tg));
            if (Position.Y <= 0 || Position.Y + _texture.Height >= Game1.screenHeingt || Position.Y + _texture.Height >= 400)
            { //Velocity.Y = -Velocity.Y;
                if (Position.Y <= 0)
                {
                    vy -= 1;
                }
                if (Position.Y >= 1000)
                {
                    vy += 1;
                }
                if (Position.Y >= 800)
                {
                    vy += 20;
                }else 
                    vy = -vy;
               
                vy = (vy * 0.7f);
                tg = 0;

            }

            if ((Position.X <= 0 || Position.X >= Game1.screenWidth && Position.Y < 400)&&(Position.Y <326||Position.Y >288))
            {
                vx = -vx;
                keeppos = Position.Y;
                if (Position.X <= 20 && (Position.Y <420 && Position.Y > 288))
                {
                    sprites[1].Position.X = 120;
                    sprites[1].Position.Y = 326;
                    sprites[2].Position.X = 584;
                    sprites[2].Position.Y = 326;
                    score.Score1++;
                    Restart();
                }
                else if(Position.X >= 600 &&(Position.Y <420&&Position.Y >288))
                {
                    sprites[1].Position.X = 120;
                    sprites[1].Position.Y = 326;
                    sprites[2].Position.X = 584;
                    sprites[2].Position.Y = 326;
                    score.Score2++;
                    Restart();
                }

            }
            Position += new Vector2(vx, vy);
        }

        public void Restart()
        {
            vx = 0;
            vy -= 3;
            Position = (Vector2)_startPosition;
            // Speed = (float)_startSpeed;
            _timer = 0;
            // _isPlaying = false;

        }



    }
}