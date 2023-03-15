public class Platforms
{
    public Rectangle platform = new Rectangle(0, 500, 1370, 64);


    public void DrawPlatform()
    {
        Raylib.DrawRectangleRec(platform, Color.BLACK);
    }
}
