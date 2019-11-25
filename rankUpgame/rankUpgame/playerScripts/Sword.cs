using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace rankUpgame
{
    class Sword
    {
   

        Texture2D sprite;
        Texture2D sprite2;
        Vector2 pos;

       public bool HasKilled { get; private set; } 
        bool active { get; set; }

       public int killedInnocent { get; private set; }
       public int killedenemy { get; private set; }
        public Sword(Texture2D newSprite, Texture2D newSprite2)
        {
            sprite = newSprite;
            sprite2 = newSprite2;
        }

        float timer;
        public void action(Player player)
        {
            
            pos = new Vector2(player.pos.X + player.sprite.Width,player.pos.Y + player.sprite.Height/4);
            if (Keyboard.GetState().IsKeyDown(Keys.F)&& !active)
            {
                active = true;


            }

            if (timer > 30)
            {
                active = false;
                timer = 0;
            }
            timer++;           
        }

        public void Draw(SpriteBatch sp)
        {
            
            if (active)
            {
                if (HasKilled)
                {
                    sp.Draw(sprite2, pos);
                }
                else
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
                    if (pos.Y + sprite.Height >= entities[i].pos.Y && pos.Y + sprite.Height < entities[i].pos.Y + entities[i].sprite.Height)
                    {
                        if (pos.X + sprite.Width >= entities[i].pos.X && pos.X <= entities[i].pos.X + entities[i].sprite.Width)
                        {
                            HasKilled = true;
                            if (entities[i].type == Entities.Type.enemy)
                            {
                                killedenemy++;
                            }
                            if (entities[i].type == Entities.Type.innocent)
                            {
                                killedInnocent++;
                            }
                            entities.Remove(entities[i]);

                        }

                    }
                }
                

            }


        }
       



    }
}
