using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rankUpgame
{
    class Enemies : Entities
    {
        public Enemies(Vector2 Pos, Texture2D Sprite) : base(Pos, Sprite)
        {
            type = Type.enemy;
        }
        public override void behaviour()
        {

        }


    }
}
