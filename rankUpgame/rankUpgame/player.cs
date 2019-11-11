using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;


namespace rankUpgame
{
    class Player:Game
    {
        Texture2D sprite { get; set;}
       public Vector2 pos { get; set;}

       public Player(Texture2D Sprite,Vector2 Pos)
        {
            sprite = Sprite;
            pos = Pos;
        }

        protected override void Update(GameTime gameTime)
        {
            
            base.Update(gameTime);
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
                if (pos.Y + sprite.Height >= geometry[i].pos.Y && pos.Y + sprite.Height < geometry[i].pos.Y + geometry[i].tex.Height && pos.X >= geometry[i].pos.X && pos.X <= geometry[i].pos.X + geometry[i].tex.Width)
                {
                    collided = true;
                    System.Diagnostics.Debug.Print("pos changed from:" + pos);
                    pos = new Vector2(pos.X, prevPos.Y);
                    System.Diagnostics.Debug.Print("to:" + prevPos);
                    hasjumped = false;
                  
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
                pos -= Vector2.UnitY *10;
                vel.Y = -10;
                hasjumped = true;
            }

            if (hasjumped)
            {
                vel.Y +=  0.15f;
            }
        }


    }
}
