using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace rankUpgame
{
     class Entities
    {
        public enum Type {enemy,innocent }

       public Type type { get; protected set; }
        public Vector2 pos {get; protected set; }
        public Texture2D sprite {get; protected set; }
        
        public Entities(Vector2 Pos,Texture2D Sprite)
        {
            pos = Pos;
            sprite = Sprite;
        }
        public virtual void behaviour()
        {

        }
        public void draw(SpriteBatch sp)
        {
            sp.Draw(sprite, pos);
        }

    }
}
