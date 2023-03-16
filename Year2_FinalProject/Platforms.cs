public class Platforms
{
    public List<Rectangle> test = new();

    public Platforms()
    {
        test.Add(new Rectangle(0, 500, 1370, 64));
        test.Add(new Rectangle(900, 350, 200, 32));
    }

    public void DrawPlatforms()
    {
        foreach(Rectangle platform in test)
        {
            Raylib.DrawRectangleRec(platform, Color.BLACK);
        }
    }
}
