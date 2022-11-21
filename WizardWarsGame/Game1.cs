using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Engine;
using Engine;
using Microsoft.Xna.Framework;
using System;

namespace WizardWarsGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }


class TickTick : ExtendedGameWithLevels
    {
        public const float Depth_Background = 0; // for background images
        public const float Depth_UIBackground = 0.9f; // for UI elements with text on top of them
        public const float Depth_UIForeground = 1; // for UI elements in front
        public const float Depth_LevelTiles = 0.5f; // for tiles in the level
        public const float Depth_LevelObjects = 0.6f; // for all game objects except the player
        public const float Depth_LevelPlayer = 0.7f; // for the player

        public static ExtendedGame GetCurrentGame { get; private set; }

        [STAThread]
        static void Main()
        {
            TickTick game = new TickTick();
            GetCurrentGame = game;
            game.Run();
        }

        public TickTick()
        {
            IsMouseVisible = true;
            System.Diagnostics.Debug.WriteLine(this.Window.Title == string.Empty);
            this.Window.Title = "TickTick";
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            // set a custom world and window size
            worldSize = new Point(1440, 825);
            windowSize = new Point(1024, 586);

            // to let these settings take effect, we need to set the FullScreen property again
            FullScreen = false;

            // load the player's progress from a file
            LoadProgress();

            // add the game states
            //GameStateManager.AddGameState(StateName_Title, new TitleMenuState());
            //GameStateManager.AddGameState(StateName_LevelSelect, new LevelMenuState());
            //GameStateManager.AddGameState(StateName_Help, new HelpState());
            //GameStateManager.AddGameState(StateName_Playing, new PlayingState());
            //GameStateManager.AddGameState(StateName_Error, new ErrorState());

            // start at the title screen
            //GameStateManager.SwitchTo(StateName_Title);

            // play background music
            AssetManager.PlaySong("Sounds/snd_music", true);
        }

    }
}