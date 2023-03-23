public class Enemies
{
    float gravity = 0.98f;
    Color clear = new Color(255, 255, 255, 0);
    Vector2 slimeVel = new Vector2(0,0);
    Vector2 slimePos = new Vector2(0,0);
    Vector2 skeletonVel = new Vector2(0,0);
    Vector2 skeletonPos = new Vector2(0,0);
    Vector2 batVel = new Vector2(0,0);
    Vector2 batPos = new Vector2(0,0);
    Texture2D slime = Raylib.LoadTexture("slime.png");
    Texture2D skeletonL = Raylib.LoadTexture("skeletonL.png");
    Texture2D skeletonR = Raylib.LoadTexture("skeletonR.png");
    Texture2D batL = Raylib.LoadTexture("batL.png");
    Texture2D batR = Raylib.LoadTexture("batR.png");
    public List<Rectangle> Slimes = new();
    public List<Rectangle> Skeletons = new();
    public List<Rectangle> Bats = new();
    bool jump;

    Rectangle slimeRec;
    Rectangle skeletonRec;
    Rectangle batRec;

    public Enemies()
    {
        Slimes.Add(slimeRec = new Rectangle(20, 468, slime.width, slime.height));
        Slimes.Add(slimeRec = new Rectangle(300, 450, slime.width, slime.height));
        Slimes.Add(slimeRec = new Rectangle(100, 300, slime.width, slime.height));


        Skeletons.Add(skeletonRec = new Rectangle(900, 275, skeletonL.width, skeletonL.height));
        Skeletons.Add(skeletonRec = new Rectangle(1000, 275, skeletonL.width, skeletonL.height));


        Bats.Add(batRec = new Rectangle(150, 20, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(500, 40, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(777, 60, batL.width, batL.height));
    }

    public void DrawEnemies()
    {
        foreach (Rectangle Slime in Slimes)
        {
            Raylib.DrawRectangleRec(Slime, clear);
            Raylib.DrawTexture(this.slime, (int)Slime.x, (int)Slime.y, Color.WHITE);
        }
        foreach (Rectangle Skeleton in Skeletons)
        {
            Raylib.DrawRectangleRec(Skeleton, clear);
            Raylib.DrawTexture(this.skeletonL, (int)Skeleton.x, (int)Skeleton.y, Color.WHITE);
        }
        foreach (Rectangle Bat in Bats)
        {
            Raylib.DrawRectangleRec(Bat, clear);
            Raylib.DrawTexture(this.batL, (int)Bat.x, (int)Bat.y, Color.WHITE);
        }
    }

    public void CheckCollisionE(Platforms p)
    {
        foreach (Rectangle slime in Slimes)
        {
            foreach (Rectangle platform in p.test)
            {
                if (Raylib.CheckCollisionRecs(new(slime.x, slime.y + slimeVel.Y, slime.width, slime.height), platform))
                {
                    if(slimeVel.Y > 0)
                    {
                        jump = true;
                    }
                    this.slimeVel.Y = 0;
                }
                if (Raylib.CheckCollisionRecs(new(slime.x + slimeVel.X, slime.y, slime.width, slime.height-1), platform))
                {
                    this.slimeVel.X = 0;
                }
            }
            slime.x += slimeVel.X;
            this.slimeRec.y += slimeVel.Y;
            
        }
    }
}
