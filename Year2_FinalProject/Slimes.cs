public class Slimes
{
    float gravity = 0.98f;
    int force = 15;
    Color clear = new Color(255, 255, 255, 0);
    Vector2 slimeVel = new Vector2(0, 0);
    Vector2 slimePos = new Vector2(0, 0);
    float speed = 3;
    Texture2D sprite = Raylib.LoadTexture("slime.png");
    public List<Rectangle> slimes = new();
    Rectangle rect;
    bool jump = true;
    bool airborne;
    public Slimes()
    {
        rect = new Rectangle(100, 50, sprite.width, sprite.height);
    }
    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, clear);
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public void Control(Player player)
    {
        slimeVel.X = 0;

        if (slimeVel.Y == 0 && !airborne)
        {
            slimeVel.Y = -force;
            jump = false;
            airborne = true;
        }

        if (rect.x < player.playerRect.x && airborne)
        {
            slimeVel.X = speed;
        }

        if (rect.x > player.playerRect.x && airborne)
        {
            slimeVel.X = -speed;
        }
        slimeVel.Y += gravity;
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle platform in p.test)
        {
            if (Raylib.CheckCollisionRecs(new(rect.x, rect.y + slimeVel.Y, rect.width, rect.height), platform))
            {
                if (slimeVel.Y > 0)
                {
                    jump = true;
                    airborne = false;
                }
                slimeVel.Y = 0;
            }
            if (Raylib.CheckCollisionRecs(new(rect.x + slimeVel.X, rect.y, rect.width, rect.height - 1), platform))
            {
                slimeVel.X = 0;
            }
        }
        rect.x += slimeVel.X;
        rect.y += slimeVel.Y;
    }

}
