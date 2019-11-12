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
            timer++;
        }

        public void Draw(SpriteBatch sp)
        {
            
            if (active)
            {
                sp.Draw(sprite, pos);
            }
        }
        public void CombatCollision(List<Entities> entities)
        {
            if (active)
            {
                // check collision with entitie
                for (int i = 0; i < entities.Count; i++)
                {
                    if (pos.Y + sprite.Height >= entities[i].pos.Y && pos.Y + sprite.Height < entities[i].pos.Y + entities[i].sprite.Height && pos.X + sprite.Width >= entities[i].pos.X && pos.X <= entities[i].pos.X + entities[i].sprite.Width)
                    {
                        //do logic
                        System.Diagnostics.Debug.Print("coll");
                        entities.Remove(entities[i]);
                    }
                }
                

            }


        }



    }
}
