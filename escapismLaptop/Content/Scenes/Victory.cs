using escapismLaptop.Content.GameObjects;

namespace escapismLaptop.Content.Scenes
{
    internal class Victory : Scene
    {
        public Victory()
        {
            GameObject victory = new GameObject(ContentManager.getInstance().texture_victory);
            this.sceneObjects.Add(victory);
        }
    }
}
