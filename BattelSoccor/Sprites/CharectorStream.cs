using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattelSoccor.Sprites
{
    class Charactersteam
    {
        public Texture2D Character1 { get; set; }
       // public Texture2D Character2 { get; set; }
        int Moves;
        bool Bottompress = false;
        //  battlesoccerView battle = new battlesoccerView();

        //public int Move { get; set; }

        public int Row { get; set; }


        public int Colums { get; set; }

        private int currentframe;
        private int totalframe;

        private int timeSinceLastFrame = 0;

        private int milisecondPerFrame = 50;

        public Charactersteam(Texture2D character1, int row, int colums)
        {
            Character1 = character1;
            Row = row;
            Colums = colums;
            currentframe = 0;
            totalframe = Row * Colums;
            //Move = move;
        }

        public void Update(GameTime gameTime, int mov, bool pressbottom)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            Bottompress = pressbottom;

            if (timeSinceLastFrame > milisecondPerFrame)
            {
                timeSinceLastFrame -= milisecondPerFrame;
                if (Bottompress)
                {
                    currentframe++;
                }

                timeSinceLastFrame = 0;
                if (currentframe == totalframe)
                {
                    currentframe = 0;
                }
            }
            Moves = mov;


        }
        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Character1.Width / Colums;
            int hight = Character1.Height / Row;
            int row = (int)((float)currentframe / Colums);
            int column = currentframe % Colums;

            Rectangle sourceRectangle = new Rectangle(width * column, hight * Moves, width, hight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, hight);

            spritebatch.Begin();
            spritebatch.Draw(Character1, destinationRectangle, sourceRectangle, Color.White);
            spritebatch.End();
        }
    }
}
