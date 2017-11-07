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
      
        private float _timer = 0f;
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;
        private float tg=0, g = 9.8f;
        private float vx = 0, vy = 0;
        public Score score;
        public int SpeedIncrementSpan = 10;
        private Vector2 root2 ;

        public Ball(Texture2D texture) 
            : base(texture)
        {
            Speed = 3f;
            name = "Ball";
        }

        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = Position;
                //_startSpeed = Speed;

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
               // score.Score1+=(int)_timer;
             //   score.Score2 += (int)gametime.ElapsedGameTime.TotalSeconds;
                Speed++;
                _timer = 0;
               // tg = _timer;

            }

            foreach (var sprite in sprites)
            {
                if (sprite == this) continue;
                


                if (this.IsTouchingLeft(sprite))
                     {
                    vx = 10;
                    vy += 4;
                    this.vx= -this.vx;
                   
                }
                if ( this.IsTouchingRight(sprite))
                {
                    vx= -10;
                    vy += 4;
                    this.vx = -this.vx;
                  

                }
                if (  this.IsTouchingTop(sprite))
                {
                    /*  Velocity.Y += 10f;
                      this.Velocity.Y = -this.Velocity.Y;*/

                    vy += 10f;
                    this.vy = -this.vy;
                }
                //if (  this.IsTouchingBottom(sprite))
                    //this.vy= -this.vy;
            }

            if (Position.Y <= 0 || Position.Y + _texture.Height >= Game1.screenHeingt || Position.Y + _texture.Height >= 375)
            { //Velocity.Y = -Velocity.Y;
                vy = -vy;
                // root2 = new Vector2((float)(0.707), (float)(0.707));
                // Velocity.Y =(float)(Velocity.Y *0.707f);
                vy = (vy * 0.707f);
                tg = 0;
               
            }

            if (Position.X <= 0 || Position.X >= Game1.screenWidth)
            {

                vx= -vx;
                vx = (vx * 0.6f);
  
                if (Position.X + _texture.Width > Game1.screenWidth)
                {
                   
                    // score.Score1++;
                    //Restart();
                }
                else
                {
                    
                    // score.Score2++;
                    // Restart();
                }
            }
            // Position += Velocity * Speed;

            /*  Velocity.X=(Velocity.X+(a*ta));
              Velocity.Y = (Velocity.Y + (g * tg));
              Position += Velocity;*/

             
            vy = (vy + (g * tg));
            Position += new Vector2(vx,vy);
        }

        public void Restart()
        {
            /* var direction = Game1.random.Next(0, 4);
             switch (direction)
             {

                 case 0:
                     Velocity = new Vector2(1, 1);
                     break;
                 case 1:
                     Velocity = new Vector2(1, -1);
                     break;
                 case 2:
                     Velocity = new Vector2(-1, -1);
                     break;
                 case 3:
                     Velocity = new Vector2(-1, 1);
                     break;
             }*/
           // Velocity = new Vector2(0, 1f);
            Position = (Vector2)_startPosition;
           // Speed = (float)_startSpeed;
            _timer = 0;
           // _isPlaying = false;

        }

    }
}
