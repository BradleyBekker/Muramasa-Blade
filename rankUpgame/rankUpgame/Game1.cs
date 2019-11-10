using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rankUpgame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        LevelGeometry geometry;
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


            geometry = new LevelGeometry(LGsprite, new Vector2(0, 300));
            player = new Player(pSprite, new Vector2(0, 0));
        }

       
        protected override void UnloadContent()
        {
        }

       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            player.GravityApplication(5);
            player.GroundCollision(geometry);
            player.movement();




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            geometry.DrawGeometry(spriteBatch);
            spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}
