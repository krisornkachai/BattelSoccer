using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BattelSoccor.Models;
using BattelSoccor.Sprites;
using System;
using System.Collections.Generic;
using BattelSoccor.Buttons;

namespace BattelSoccor
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        enum GameState
        {
            Mainmenu,
            GamePlay
        }
        GameState CurrentState = GameState.Mainmenu;
        //  private Charactersteam charactersteam;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int screenWidth;
        public static int screenHeingt;
        public static Random random;


        private Score _score;
        private List<Sprite> _sprites;
        private List<Texture2D> texture2DCha1MoveRight;
        private List<Texture2D> texture2DCha1MoveLeft;
        private List<Texture2D> texture2DCha1MoveJump;


        private List<Texture2D> texture2DCha2MoveRight;
        private List<Texture2D> texture2DCha2MoveLeft;
        private List<Texture2D> texture2DCha2MoveJump;

        private List<Texture2D> texture2DHeal1;
        private List<Texture2D> texture2DHeal2;
        Button btnPlay;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 720;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeingt = graphics.PreferredBackBufferHeight;
            random = new Random();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            IsMouseVisible = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            btnPlay = new Button(Content.Load<Texture2D>("btn_start"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(482, 387));
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            texture2DCha1MoveRight = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor1/Charac_1/2_1") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_2") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_3"),
                Content.Load<Texture2D>("charactor1/Charac_1/2_4") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_5") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_6")
            };

            texture2DCha1MoveLeft = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor1/Charac_1/2_1") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_2") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_3"),
                Content.Load<Texture2D>("charactor1/Charac_1/2_4") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_5") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_6")
            };

            texture2DCha1MoveJump = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor1/Charac_1/2_1") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_2") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_3"),
                Content.Load<Texture2D>("charactor1/Charac_1/2_4") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_5") ,
                Content.Load<Texture2D>("charactor1/Charac_1/2_6")
            };

            texture2DCha2MoveRight = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor2/Charac_2/2_1") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_2") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_3"),
                Content.Load<Texture2D>("charactor2/Charac_2/2_4") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_5") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_6")
            };

            texture2DCha2MoveLeft = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor2/Charac_2/2_1") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_2") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_3"),
                Content.Load<Texture2D>("charactor2/Charac_2/2_4") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_5") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_6")
            };


            texture2DCha2MoveJump = new List<Texture2D>() {
                Content.Load<Texture2D>("charactor2/Charac_2/2_1") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_2") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_3"),
                Content.Load<Texture2D>("charactor2/Charac_2/2_4") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_5") ,
                Content.Load<Texture2D>("charactor2/Charac_2/2_6")
            };


            texture2DHeal1 = new List<Texture2D>() // newwwww
            {   Content.Load<Texture2D>("charactor1/bar1/bar0"),
               Content.Load<Texture2D>("charactor1/bar1/bar1"),
               Content.Load<Texture2D>("charactor1/bar1/bar2"),
               Content.Load<Texture2D>("charactor1/bar1/bar3"),
               Content.Load<Texture2D>("charactor1/bar1/bar4"),
               Content.Load<Texture2D>("charactor1/bar1/bar5"),
               Content.Load<Texture2D>("charactor1/bar1/bar6"),
               Content.Load<Texture2D>("charactor1/bar1/bar7"),
               Content.Load<Texture2D>("charactor1/bar1/bar8"),
               Content.Load<Texture2D>("charactor1/bar1/bar9"),
               Content.Load<Texture2D>("charactor1/bar1/bar10"),
                 Content.Load<Texture2D>("charactor1/bar1/bar11"),
            };

            texture2DHeal2 = new List<Texture2D>() // newwwww
            {   Content.Load<Texture2D>("charactor2/bar2/bar0"),
               Content.Load<Texture2D>("charactor2/bar2/bar1"),
               Content.Load<Texture2D>("charactor2/bar2/bar2"),
               Content.Load<Texture2D>("charactor2/bar2/bar3"),
               Content.Load<Texture2D>("charactor2/bar2/bar4"),
               Content.Load<Texture2D>("charactor2/bar2/bar5"),
               Content.Load<Texture2D>("charactor2/bar2/bar6"),
               Content.Load<Texture2D>("charactor2/bar2/bar7"),
               Content.Load<Texture2D>("charactor2/bar2/bar8"),
               Content.Load<Texture2D>("charactor2/bar2/bar9"),
               Content.Load<Texture2D>("charactor2/bar2/bar10"),
               Content.Load<Texture2D>("charactor2/bar2/bar11"),
            };

            var batTexture = Content.Load<Texture2D>("charactor1/Charac_1/2_1");
            var ballTexture = Content.Load<Texture2D>("Ball");
            var healTexture = Content.Load<Texture2D>("charactor2/bar2/bar0");  //newwwwwww
            // charactersteam = new Charactersteam(batTexture, 4, 6);
            _score = new Score(Content.Load<SpriteFont>("Font"));

            _sprites = new List<Sprite>()
            {
                new Sprite(Content.Load<Texture2D>("bg"),"bg"),
                new Charecctor(batTexture,texture2DCha1MoveRight,"Charac_1")
                {
                    Position=new Vector2(120,326),
                    Input = new Input()
                    {
                        left=Keys.A,
                        right=Keys.D,
                        jump=Keys.W,
                        dash=Keys.S,
                    }
                },
                  new Charecctor( Content.Load<Texture2D>("charactor2/Charac_2/2_1"),texture2DCha2MoveRight,"Charac_2")
                {
                    Position=new Vector2(584,326),
                    Input = new Input()
                    {
                        left=Keys.Left,
                        right=Keys.Right,
                        jump=Keys.Up,
                        dash=Keys.Down,
                    }
                },
                  new Ball(ballTexture)
                  {
                       Position=new Vector2((screenWidth/2),(screenHeingt/2)),
                       score=_score,
                  },
                  new Healthbar( healTexture,texture2DHeal2,"HB1")
                  {
                      Position=new Vector2((screenWidth/2)-250,(screenHeingt/2)-(batTexture.Height/2)-100),
                  },
                  new Healthbar(Content.Load<Texture2D>("charactor1/bar1/bar0"),texture2DHeal1,"HB2")
                  {
                      Position=new Vector2((screenWidth/2)+100,(screenHeingt/2)-(batTexture.Height/2)-100),
                  },
               /*    new Sprite(Content.Load<Texture2D>("goal"))
                  {
                      Position=new Vector2(0,0),
                  },*/
                    new Sprite(Content.Load<Texture2D>("goal1"),"goal1")
                  {
                      Position=new Vector2(-60,300),
                  },
                     new Sprite(Content.Load<Texture2D>("goal2"),"goal2")
                  {
                      Position=new Vector2(650,300),
                  },
            };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            switch (CurrentState)
            {

                case GameState.Mainmenu:
                    if (btnPlay.isClicked == true) CurrentState = GameState.GamePlay;
                    btnPlay.Update(mouse);
                    break;
                case GameState.GamePlay:
                    break;


            }



            foreach (var sprite in _sprites)
            {

                sprite.Update(gameTime, _sprites);
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            /* GraphicsDevice.Clear(Color.CornflowerBlue);

             // TODO: Add your drawing code here

     */
            spriteBatch.Begin();



            switch (CurrentState)
            {
                case GameState.Mainmenu:
                    spriteBatch.Draw(Content.Load<Texture2D>("bg_mainMenu"), new Rectangle(0, 0, screenWidth, screenHeingt), Color.White);
                    btnPlay.Draw(spriteBatch);
                    break;
                case GameState.GamePlay:
                    foreach (var sprite in _sprites)
                        sprite.Draw(spriteBatch);

                    _score.Draw(spriteBatch);
                    break;

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
