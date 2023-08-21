
using escapismLaptop;
using escapismLaptop.Content;
using escapismLaptop.Content.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public enum Button{
    play,
    quit
}
public class StartMenu : Scene{

    public Button selectedButton;
    GameObject selectionRectangle;

    public StartMenu(){

        selectedButton = Button.play;

        GameObject playButton = new GameObject(ContentManager.getInstance().texture_playButton);
        GameObject quitButton = new GameObject(ContentManager.getInstance().texture_quitButton);

        playButton.location = new Microsoft.Xna.Framework.Vector2(200, 50);
        quitButton.location = new Microsoft.Xna.Framework.Vector2(200, 250);

        this.sceneObjects.Add(playButton);
        this.sceneObjects.Add(quitButton);

        selectionRectangle = new GameObject(ContentManager.getInstance().texture_selectionRectangle);
        selectionRectangle.location = new Microsoft.Xna.Framework.Vector2(200, 50);
        this.sceneObjects.Add(selectionRectangle);
        
    }
    public void changeSelectedButton(){
        if(this.selectedButton == Button.play)
            selectedButton = Button.quit;

        if(this.selectedButton == Button.quit)
            selectedButton = Button.play;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if(this.selectedButton == Button.play)
            selectionRectangle.location = new Vector2(200, 50);
        else
            selectionRectangle.location = new Vector2(200, 250);
        
    }
    




}