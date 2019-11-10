using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rankUpgame
{
    class LevelGeometry
    {
       public Texture2D tex { get; private set; }
       public Vector2 pos { get; set; }
       public LevelGeometry(Texture2D Tex, Vector2 Pos)
        {
            tex = Tex;
            pos = Pos;
        }

        public void DrawGeometry(SpriteBatch sp)
        {
            sp.Draw(tex, pos);
        }


    }
}
