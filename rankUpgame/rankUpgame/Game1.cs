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
        Counter score = new Counter("score", 1000);
        SpriteFont font;
        Texture2D background;

        Texture2D pSprite;
        Texture2D LGsprite;
        Sword Sword;
        List<Entities> Mobs = new List<Entities>();
        Goal goal;
        int currentLevel;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight =720;
            graphics.PreferredBackBufferWidth = 1280;
            IsFixedTimeStep = true;
            
        }


        protected override void Initialize()
        {
            currentLevel = 3;
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            background = this.Content.Load<Texture2D>("background");
            Texture2D Ssprite = this.Content.Load<Texture2D>("Sword");
            Texture2D Ssprite2 = this.Content.Load<Texture2D>("satedSword");
            Sword = new Sword(Ssprite,Ssprite2);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pSprite = this.Content.Load<Texture2D>("Player");

            font = this.Content.Load<SpriteFont>("File");
            LoadLevel( currentLevel);
            
        }

       
        protected override void UnloadContent()
        {
            this.Content.Unload();
          
        }

       
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (goal.Cleared(player))
            {


                if (Sword.HasKilled)
                {
                    score.IncreaseCounter(100 * Sword.killedenemy);
                    score.DepleteCounter(100 * Sword.killedInnocent);
                    System.Diagnostics.Debug.Print("win");
                    UnloadContent();
                    currentLevel++;
                    LoadContent();
                }
                else
                {
                    LoadContent();
                }
            }
            PlayerLogic();
            score.DepleteCounter(1f/30f);
         
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero);
            for (int i = 0; i < Mobs.Count; i++)
            {
                Mobs[i].draw(spriteBatch);

            }
            goal.Draw(spriteBatch);

            player.Draw(spriteBatch);
            Sword.Draw(spriteBatch);

            for (int i = 0; i < level.Count; i++)
            {
                level[i].DrawGeometry(spriteBatch);
                spriteBatch.DrawString(font, "" + level[i].pos, level[i].pos, Color.White);
            }
            spriteBatch.DrawString(font, "" + player.pos + "" , player.pos, Color.White);
            score.Draw(font, new Vector2(1000, 0), spriteBatch);

            spriteBatch.End();
        }



        void PlayerLogic()
        {
            player.GravityApplication(5);


            player.movement();

            player.GroundCollision(level);
            Sword.action(player);
            Sword.CombatCollision(Mobs);

        }

        void LoadLevel(int i)
        {
            if (i == 1)
            {
                Mobs.Clear();
                level.Clear();
                LGsprite = this.Content.Load<Texture2D>("floor2");
                level.Add(new LevelGeometry(LGsprite, new Vector2(0, 688)));
                player = new Player(pSprite, new Vector2(0, 0));
                
                Texture2D Gsprite = this.Content.Load<Texture2D>("goal");
                goal = new Goal(new Vector2(1200, 616), Gsprite);

                Texture2D Esprite = this.Content.Load<Texture2D>("enemyPH");
                Texture2D Isprite = this.Content.Load<Texture2D>("innocent");

                Mobs.Add(new Enemies(new Vector2(464, 624), Esprite));
            }
            else if(i  == 2)
            {
                Mobs.Clear();
                level.Clear();
                LGsprite = this.Content.Load<Texture2D>("platform");
                level.Add(new LevelGeometry(LGsprite, new Vector2(0, 488)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(400, 450)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(800, 430)));
                player = new Player(pSprite, new Vector2(0, 0));
               Texture2D Gsprite = this.Content.Load<Texture2D>("goal");
                goal = new Goal(new Vector2(900, 362), Gsprite);

                Texture2D Esprite = this.Content.Load<Texture2D>("enemyPH");
                Texture2D Isprite = this.Content.Load<Texture2D>("innocent");

                Mobs.Add(new Enemies(new Vector2(464, 386), Esprite));
                Mobs.Add(new Enemies(new Vector2(496, 386), Isprite));
            }

            else if(i  == 3)
            {
                Mobs.Clear();
                level.Clear();
                LGsprite = this.Content.Load<Texture2D>("platform");

                level.Add(new LevelGeometry(LGsprite, new Vector2(0, 656)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(256, 656)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(512, 656)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(768, 656)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(0, 592)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(256, 592)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(768, 592)));



                level.Add(new LevelGeometry(LGsprite, new Vector2(1024, 528)));


                //  level.Add(new LevelGeometry(LGsprite, new Vector2(512, 656)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(512, 592)));
                

                level.Add(new LevelGeometry(LGsprite, new Vector2(424, 320)));
                //level.Add(new LevelGeometry(LGsprite, new Vector2(670, 250)));
                level.Add(new LevelGeometry(LGsprite, new Vector2(700, 400)));

                player = new Player(pSprite, new Vector2(0, 0));

                Texture2D Gsprite = this.Content.Load<Texture2D>("goal");
                goal = new Goal(new Vector2(424 + 128, 320-70), Gsprite);

                Texture2D Esprite = this.Content.Load<Texture2D>("enemyPH");
                Texture2D Isprite = this.Content.Load<Texture2D>("innocent");

                Mobs.Add(new Enemies(new Vector2(424, 320 - 64), Esprite));
            }
            else
            {
                return;
            }

            
        }
    }
}
