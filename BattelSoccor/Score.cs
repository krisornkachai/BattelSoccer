﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BattelSoccor
{
    public class Score
    {
        public int Score1;
        public int Score2;

        private SpriteFont _font;

        public Score(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, Score1.ToString(), new Vector2(320, 70), Color.White);
            spriteBatch.DrawString(_font, Score1.ToString(), new Vector2(430, 70), Color.White);
        }
    }
}
