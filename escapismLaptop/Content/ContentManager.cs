using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace escapismLaptop.Content
{
    //Design Pattern: Singleton Pattern
    internal class ContentManager
    {
        public Texture2D texture_playButton;
        public Texture2D texture_quitButton;
        public Texture2D texture_selectionRectangle;
        public Texture2D texture_helena;
        public Texture2D texture_box;
        public SpriteFont spriteFont;
        public StartMenu menu;
        public Texture2D spritesheetHelena;
        public Texture2D texture_gameOver;
        public Texture2D texture_spikes;
        public Texture2D texture_door;
        public Texture2D texture_halfslab;
        public Texture2D spritesheetGuard;
        public Texture2D spritesheetGunman;
        public Texture2D texture_victory;
        public Texture2D texture_bullet;
        public Texture2D background;
        public Texture2D texture_wings;
        public Song song;

        private static ContentManager uniqueInstance;
        private ContentManager()
        {

        }

        public static ContentManager getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new ContentManager();
            }
            return uniqueInstance;
        }

        public void initializeContent(Game1 game)
        {
            song = game.Content.Load<Song>("song");
            texture_playButton = game.Content.Load<Texture2D>("playButton");
            texture_quitButton = game.Content.Load<Texture2D>("quitButton");
            texture_selectionRectangle = game.Content.Load<Texture2D>("selectionRectangle");
            texture_helena = game.Content.Load<Texture2D>("helena");
            texture_box = game.Content.Load<Texture2D>("box");
            spriteFont = game.Content.Load<SpriteFont>("eenFont");
            spritesheetHelena = game.Content.Load<Texture2D>("spritesheetHelena");
            texture_gameOver = game.Content.Load<Texture2D>("GameOver");
            texture_spikes = game.Content.Load<Texture2D>("spikes");
            texture_door = game.Content.Load<Texture2D>("door");
            texture_halfslab = game.Content.Load<Texture2D>("halfslab");
            spritesheetGuard = game.Content.Load<Texture2D>("spritesheetGuard");
            spritesheetGunman = game.Content.Load<Texture2D>("spritesheetGunman");
            texture_victory = game.Content.Load<Texture2D>("Victory");
            texture_bullet = game.Content.Load<Texture2D>("bullet");
            background = game.Content.Load<Texture2D>("background");
            texture_wings = game.Content.Load<Texture2D>("wings");
        }
    }
}
