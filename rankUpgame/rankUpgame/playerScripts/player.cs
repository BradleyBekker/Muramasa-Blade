using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace rankUpgame
{
    class Player
    {
        enum direction {left, right }
        direction dir = direction.right;
       public Texture2D sprite { get; set;}
       public Vector2 pos { get; set;}

       public Player(Texture2D Sprite,Vector2 Pos)
        {
            sprite = Sprite;
            pos = Pos;
        }

 

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(sprite, pos);
        }

       public void GravityApplication(int GravityPower)
        {
            for (int i = 0; i < GravityPower; i++)
            {
                pos = pos + Vector2.UnitY ;
                
            }
        }

        Vector2 prevPos;
        public void GroundCollision(List<LevelGeometry> geometry)
        {
            bool collided = false;
            for (int i = 0; i < geometry.Count; i++)
            {
                if (pos.Y + sprite.Height >= geometry[i].pos.Y && pos.Y + sprite.Height < geometry[i].pos.Y + geometry[i].tex.Height)
                {
                    if (pos.X + sprite.Width >= geometry[i].pos.X && pos.X <= geometry[i].pos.X + geometry[i].tex.Width)
                    {
                        collided = true;
                        pos = new Vector2(pos.X, prevPos.Y);
                        hasjumped = false;
                        vel.Y = 0;
                    }

                }
                if (pos.Y + sprite.Height >= geometry[i].pos.Y && pos.Y + sprite.Height < geometry[i].pos.Y + geometry[i].tex.Height)
                {
                    if (pos.X + sprite.Width >= geometry[i].pos.X && pos.X <= geometry[i].pos.X + geometry[i].tex.Width)
                    {
                    
                        pos = new Vector2(prevPos.X, pos.Y);
           
                    }

                }


            }

            if (!collided)
            {
                prevPos = pos;
            }

        }
        Vector2 vel = new Vector2(0, 0);

        bool hasjumped;
        public void movement()
        {
                pos += vel;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                
                vel.X = 3;
            }else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                vel.X = -3;
            }
            else
            {
                vel.X = 0;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !hasjumped)
            {
                pos -= Vector2.UnitY *15;
                vel.Y = -12;
                hasjumped = true;
            }

            if (hasjumped)
            {
                vel.Y +=  0.15f;
            }
        }
       

    }
}
