using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace rankUpgame
{
    class Sword
    {
        ContentManager content;

        Texture2D sprite;
        Vector2 pos;
        bool active { get; set; }
        public Sword(Texture2D newSprite)
        {
            sprite = newSprite;
        }

        float timer;
        public void action(Player player)
        {
            
            pos = new Vector2(player.pos.X + player.sprite.Width,player.pos.Y + player.sprite.Height/4);

            if (timer > 300)
            {
                active = true;
                timer = 0;
            }
            else if (timer > 100 && timer < 300)
            {
                active = false;
            }
            System.Diagnostics.Debug.Print("" + timer);
            timer++;
        }

        public void Draw(SpriteBatch sp)
        {
            
            if (active)
            {
                sp.Draw(sprite, pos);
            }
        }
        


    }
}
