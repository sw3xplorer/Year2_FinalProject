public class Enemies
{
    Texture2D slime = Raylib.LoadTexture("slime.png");
    Texture2D skeletonL = Raylib.LoadTexture("skeletonL.png");
    Texture2D skeletonR = Raylib.LoadTexture("skeletonR.png");
    Texture2D batL = Raylib.LoadTexture("batL.png");
    Texture2D batR = Raylib.LoadTexture("batR.png");
    public List<Rectangle> Slimes = new();
    public List<Rectangle> Skeletons = new();
    public List<Rectangle> Bats = new();

    Rectangle slimeRec;
    Rectangle skeletonRec;
    Rectangle batRec;

    public Enemies()
    {
        Slimes.Add(slimeRec = new Rectangle(20, 64, slime.width, slime.height));
        Slimes.Add(slimeRec = new Rectangle(300, 0, slime.width, slime.height));
        Slimes.Add(slimeRec = new Rectangle(100, 0, slime.width, slime.height));


        Skeletons.Add(skeletonRec = new Rectangle(900, 32, skeletonL.width, skeletonL.height));
        Skeletons.Add(skeletonRec = new Rectangle(1000, 32, skeletonL.width, skeletonL.height));


        Bats.Add(batRec = new Rectangle(150, 20, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(500, 40, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(777, 60, batL.width, batL.height));
    }

    public void DrawEnemies()
    {
        foreach (Rectangle slime in Slimes)
        {
            Raylib.DrawRectangleRec(slimeRec, Color.WHITE);
        }
        foreach (Rectangle skeleton in Skeletons)
        {
            Raylib.DrawRectangleRec(skeletonRec, Color.WHITE);
        }
        foreach (Rectangle bat in Bats)
        {
            Raylib.DrawRectangleRec(batRec, Color.WHITE);
        }
    }
}