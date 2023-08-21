using escapismLaptop.Content;
using escapismLaptop.Content.Input;
using escapismLaptop.Content.Levels;
using escapismLaptop.Content.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace escapismLaptop
{

    public enum eLevel
    {
    level1,
    level2,
    level3,
    level4,
    level5
    }
    public enum eScene{
        startMenu,
        playing,
        gameOver,
        victory
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static eScene currentSceneType;
        public static eLevel currentLevelNumber;

        public static Scene currentScene;
        public static Level currentLevel;

        public static InputManager inputManager;

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.ApplyChanges();
            _graphics.PreferredBackBufferHeight = 640; // 10 tiles
            _graphics.PreferredBackBufferWidth = 960; //  15 tiles
            _graphics.ApplyChanges();

            currentSceneType = eScene.startMenu;
            currentLevelNumber = eLevel.level1;

            

            

            

            

            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            ContentManager.getInstance().initializeContent(this);


            ContentManager.getInstance().menu = new StartMenu();
            currentScene = ContentManager.getInstance().menu;

            MediaPlayer.Play(ContentManager.getInstance().song);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                if(currentSceneType == eScene.playing)
                {
                    currentSceneType = eScene.startMenu;
                    currentScene = ContentManager.getInstance().menu;
                }
                    
           

            

            if(currentSceneType == eScene.startMenu){
                if (Keyboard.GetState().IsKeyDown(Keys.Down)){
                    (currentScene as StartMenu).selectedButton = Button.quit;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up)){
                    (currentScene as StartMenu).selectedButton = Button.play;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter)){
                    if ((currentScene as StartMenu).selectedButton == Button.quit){
                        Exit();
                    }
                    if ((currentScene as StartMenu).selectedButton == Button.play){
                        currentSceneType = eScene.playing;
                        currentScene = new Playing();
                        if (currentLevel == null)
                            currentLevel = new Level1();
                    }
                }
            }



            if(currentSceneType == eScene.gameOver)
            {
                if (Keyboard.GetState().GetPressedKeyCount() > 0)
                {
                    this.Restart();
                }
            }
                

            currentScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            _spriteBatch.Begin();
            if(currentSceneType == eScene.playing)
            _spriteBatch.Draw(ContentManager.getInstance().background, new Rectangle(0, 0, 960, 640), Color.White);

            currentScene.Draw(_spriteBatch);
            
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public static void Lose()
        {
            currentSceneType = eScene.gameOver; 
            currentScene = new GameOver();
        }
        public static void WinLevel()
        {
            if(currentLevelNumber == eLevel.level1)
            {
                currentLevelNumber = eLevel.level2;
                currentLevel = new Level2();
            }
            else if(currentLevelNumber == eLevel.level2)
            {
                currentLevelNumber = eLevel.level3;
                currentLevel = new Level3();
            }
            else if (currentLevelNumber == eLevel.level3)
            {
                currentLevelNumber = eLevel.level4;
                currentLevel = new Level4();
            }
            else if(currentLevelNumber == eLevel.level4)
            {
                currentLevelNumber = eLevel.level5;
                currentLevel = new Level5();
            }
            else if (currentLevelNumber == eLevel.level5)
            {
                currentSceneType = eScene.victory;
                currentScene = new Victory();
            }



        }

        private void Restart()
        {
            currentSceneType = eScene.playing;
            currentScene = new Playing();
            currentLevelNumber = eLevel.level1;
            currentLevel = new Level1();
        }
    }
}
