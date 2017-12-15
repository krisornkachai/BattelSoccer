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
    class Healthbar : Sprite
    {
       
        private List<Texture2D> texture2DListHeal;
        public Healthbar(Texture2D texture, List<Texture2D> ListHeal, String Heal)

            : base(texture,Heal)
        {
            name = Heal;
            texture2DListHeal = ListHeal;

        }


        public override void Update(GameTime gametime, List<Sprite> sprites)
        {
            if (hitball && healbartab < 12)
            {

                _texture = texture2DListHeal[healbartab];
                healbartab += 1;
                if (healbartab > 11)
                {
                    hitball = false;
                }
                hitball = false;

            }


        }
    }
}
