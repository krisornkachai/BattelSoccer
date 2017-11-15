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
        private List<Texture2D> texture2DCha1;
        private List<Texture2D> texture2DHeal1;

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
            btnPlay.setPosition(new Vector2(360, 240));
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture2DCha1 = new List<Texture2D>() { Content.Load<Texture2D>("Charector") ,
                Content.Load<Texture2D>("CharectorRed") ,
                Content.Load<Texture2D>("CharectorBlue") };    
            
            var batTexture = Content.Load<Texture2D>("Charector");
            var ballTexture = Content.Load<Texture2D>("Ball");
            var healTexture = Content.Load<Texture2D>("healthbar2");  //newwwwwww
            // charactersteam = new Charactersteam(batTexture, 4, 6);
            _score = new Score(Content.Load<SpriteFont>("Font"));

            _sprites = new List<Sprite>()
            {
                new Sprite(Content.Load<Texture2D>("bg")),
                new Charecctor(batTexture,texture2DCha1,"Charac_1")
                {
                    Position=new Vector2(20,(screenHeingt/2)+(batTexture.Height/2)),
                    Input = new Input()
                    {
                        left=Keys.A,
                        right=Keys.D,
                        jump=Keys.W,
                    }
                },
                  new Charecctor(batTexture,texture2DCha1,"Charac_2")
                {
                    Position=new Vector2(screenWidth - 20 - batTexture.Width,(screenHeingt/2)+(batTexture.Height/2)),
                    Input = new Input()
                    {
                        left=Keys.Left,
                        right=Keys.Right,
                        jump=Keys.Up,
                    }
                },
                  new Ball(ballTexture)
                  {
                       Position=new Vector2((screenWidth/2)-(batTexture.Width/2),(screenHeingt/2)-(batTexture.Height/2)),
                       score=_score,
                  },
                  new Healthbar(healTexture,texture2DHeal1,"HB1")
                  {
                      Position=new Vector2((screenWidth/2)-300,(screenHeingt/2)-(batTexture.Height/2)-100),
                  },
                  new Healthbar(healTexture,texture2DHeal1,"HB2")
                  {
                      Position=new Vector2((screenWidth/2)+200,(screenHeingt/2)-(batTexture.Height/2)-100),
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
