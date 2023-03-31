public class Enemies
{
    float gravity = 0.98f;
    Color clear = new Color(255, 255, 255, 0);
   
    Vector2 batVel = new Vector2(0, 0);
    Vector2 batPos = new Vector2(0, 0);
    Texture2D slime = Raylib.LoadTexture("slime.png");
    
    Texture2D batL = Raylib.LoadTexture("batL.png");
    Texture2D batR = Raylib.LoadTexture("batR.png");
    public List<Rectangle> Slimes = new();
    public List<Rectangle> Skeletons = new();
    public List<Rectangle> Bats = new();
    bool jump;

    Rectangle skeletonRec;
    Rectangle batRec;

    public Enemies()
    {


        Bats.Add(batRec = new Rectangle(150, 20, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(500, 40, batL.width, batL.height));
        Bats.Add(batRec = new Rectangle(777, 60, batL.width, batL.height));
    }

    public void DrawEnemies()
    {
        

        foreach (Rectangle Bat in Bats)
        {
            Raylib.DrawRectangleRec(Bat, clear);
            Raylib.DrawTexture(this.batL, (int)Bat.x, (int)Bat.y, Color.WHITE);
        }
    }


    
}


// class Slime
// {
//     public Rectangle rect;
//     public Vector2 velocity;

//     Texture2D sprite = Raylib.LoadTexture("slime.png");

//     public Slime()
//     {
//         rect = new Rectangle(0, 0, sprite.width, sprite.height);
//     }

    
// }