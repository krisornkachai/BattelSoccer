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
    class Selectchar : Sprite
    {
        int moverightc1 = 0;

        //bool pressBottom = false;
        // private Charactersteam charactersteam;

        private List<Texture2D> texture2DListMoveright;


        //public bool Hb = false;
        public Selectchar(Texture2D texture, List<Texture2D> _slideshow, string Charac)

            : base(texture,Charac)
        {
            name = Charac;
            texture2DListMoveright = _slideshow;
            //  charactersteam = new Charactersteam(texture, 4, 6);
            // var left = Content.Load<Texture2D>("Charector");

        }

        public void Selectmove(List<Texture2D> listchar)
        {


            if (moverightc1 < 2)
            {

                moverightc1++;
            }
            else
            {
                moverightc1 = 0;
            }

            _texture = listchar[moverightc1];
            this.Charecctorselecte = moverightc1;




            //เปลื่ยนตัวที่เลือก
        }

        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            //sele
            textureData = new Color[_texture.Width * _texture.Height];
            _texture.GetData(textureData);


            if (Input == null)
            {
                throw new Exception("Pleses give a value to input");
            }

            if (Keyboard.GetState().IsKeyDown(Input.right))
            {
                Selectmove(texture2DListMoveright);

            }
            else if (Keyboard.GetState().IsKeyDown(Input.left))
            {
                Selectmove(texture2DListMoveright);

            }

        }


    }
}