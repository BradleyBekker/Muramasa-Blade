using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rankUpgame
{
    class Counter
    {
        string name { get; set; }
        public float value { get; private set; }
        
        public Counter(string name,float startingValue)
        {
            this.name = name;
            value = startingValue;
        }

        public void DepleteCounter(float amount)
        {
            value -= amount;
        }
        public void IncreaseCounter(float amount)
        {
            value += amount;
        }
        public void Draw(SpriteFont font,Vector2 pos,SpriteBatch sp)
        {
            sp.DrawString(font, name + ":" + value,pos, Color.Black);
        }


    }
}
