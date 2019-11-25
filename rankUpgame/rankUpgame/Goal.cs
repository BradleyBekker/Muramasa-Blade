using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rankUpgame
{
    class Goal
    {
        Vector2 pos { get; set; }
        Texture2D sprite { get; set; }
        public Goal(Vector2 newPos,Texture2D newSprite)
        {
            pos = newPos;
            sprite = newSprite;
        }
        public bool Cleared(Player player)
        {

            if (pos.Y + sprite.Height >= player.pos.Y && pos.Y + sprite.Height < player.pos.Y + player.sprite.Height && pos.X + sprite.Width >= player.pos.X && pos.X <= player.pos.X + player.sprite.Width)
            {
                System.Diagnostics.Debug.Print("win");
                return true;
            }
            return false;
        }
       public void Draw(SpriteBatch sp)
        {
            sp.Draw(sprite, pos);
        }
    }
}
