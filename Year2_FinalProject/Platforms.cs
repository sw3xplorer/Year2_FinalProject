public class Platforms
{
    public List<Rectangle> platformList = new();
    public Rectangle finishRect = new Rectangle(6614, 500, 64, 64);

    public Platforms()
    {
        platformList.Add(new Rectangle(-1000, -300, 975, 800)); //wall
        platformList.Add(new Rectangle(-1000, 500, 3370, 64)); //wide platform 1
        platformList.Add(new Rectangle(900, 350, 200, 32)); //small upper 1
        platformList.Add(new Rectangle(1300, 300, 150, 32)); //small upper 2
        
        platformList.Add(new Rectangle(2500, 500, 150, 32)); //gap platform

        platformList.Add(new Rectangle(2800, 500, 1500, 64)); //wide platform 2
        platformList.Add(new Rectangle(3100, 350, 200, 32)); //small upper 1
        platformList.Add(new Rectangle(3500, 350, 200, 32)); //small upper 2

        platformList.Add(new Rectangle(4236, 500, 64, 564)); //pit wall left
        platformList.Add(new Rectangle(4300, 1000, 1500, 64)); //pit bottom
        platformList.Add(new Rectangle(5800, 500, 64, 564)); //pit wall right

        platformList.Add(new Rectangle(4300, 880, 50, 16)); //staircase
        platformList.Add(new Rectangle(4400, 760, 50, 16));
        platformList.Add(new Rectangle(4300, 640, 50, 16));

        platformList.Add(new Rectangle(4450, 420, 150, 32));
        platformList.Add(new Rectangle(4750, 420, 150, 32)); //platforms above pit
        platformList.Add(new Rectangle(5050, 300, 100, 32));
        platformList.Add(new Rectangle(5300, 750, 64, 32));
        platformList.Add(new Rectangle(5470, 680, 64, 32));
        platformList.Add(new Rectangle(5640, 600, 64, 32));

        platformList.Add(new Rectangle(5864, 500, 750, 64));
        platformList.Add(new Rectangle(6678, 300, 64, 264));

        // platformList.Add(new Rectangle(6614, 500, 64, 64));
    }
    public void DrawPlatforms()
    {
        foreach (Rectangle platform in platformList)
        {
            Raylib.DrawRectangleRec(platform, Color.BLACK);
        }
        Raylib.DrawRectangleRec(finishRect, Color.GREEN);
    }
}
