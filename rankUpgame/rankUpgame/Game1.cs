using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
namespace rankUpgame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<LevelGeometry> level = new List<LevelGeometry>();
        SpriteFont font;
        Texture2D pSprite;
        Texture2D LGsprite;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pSprite = this.Content.Load<Texture2D>("Untitled-1");
            LGsprite = this.Content.Load<Texture2D>("floor");
            font = this.Content.Load<SpriteFont>("File");

            level.Add(new LevelGeometry(LGsprite, new Vector2(0, 300)));
            level.Add( new LevelGeometry(LGsprite, new Vector2(400, 300)));
            player = new Player(pSprite, new Vector2(0, 0));
        }

       
        protected override void UnloadContent()
        {
        }

       
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            player.GravityApplication(5);

           
            player.movement();

            player.GroundCollision(level);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            for (int i = 0; i < level.Count; i++)
            {
                level[i].DrawGeometry(spriteBatch);
                spriteBatch.DrawString(font, "" + level[i].pos, level[i].pos, Color.White);
            }
            spriteBatch.DrawString(font, "" + player.pos + "" , player.pos, Color.White);

            spriteBatch.End();
            
            
            
        }
    }
}
