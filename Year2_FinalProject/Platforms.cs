public class Platforms
{
    public List<Rectangle> platformList = new();

    public Platforms()
    {
        platformList.Add(new Rectangle(0, 500, 2370, 64));
        platformList.Add(new Rectangle(900, 350, 200, 32));
    }
    public void DrawPlatforms()
    {
        foreach(Rectangle platform in platformList)
        {
            Raylib.DrawRectangleRec(platform, Color.BLACK);
        }
    }
}
