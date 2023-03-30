public class Slime
{
    float gravity = 0.98f;
    int force = 20;
    Color clear = new Color(255, 255, 255, 0);
    Vector2 slimeVel = new Vector2(0, 0);
    Vector2 slimePos = new Vector2(0, 0);
    public Vector2 knockback = new Vector2(15, -15);
    float speed = 3;
    Texture2D sprite = Raylib.LoadTexture("slime.png");
    public List<Rectangle> slimes = new();
    public Rectangle rect;
    bool jump = true;
    bool airborne;
    bool waiting = false;

    int jumpCooldown;


    public Slime(int x, int y)
    {
        rect = new Rectangle(x, y, sprite.width, sprite.height);
    }




    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, clear);
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public void Control(Player player)
    {
        slimeVel.X = 0;
        if (jumpCooldown > 0) jumpCooldown--;

        if (slimeVel.Y == 0 && !airborne && jumpCooldown == 0)
        {
            slimeVel.Y = -force;
            jump = false;
            airborne = true;
            waiting = false;
        }

        if (rect.x < player.playerRect.x && airborne && jumpCooldown == 0)
        {
            slimeVel.X = speed;
        }

        if (rect.x > player.playerRect.x && airborne && jumpCooldown == 0)
        {
            slimeVel.X = -speed;
        }
        slimeVel.Y += gravity;
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle platform in p.platformList)
        {
            if (Raylib.CheckCollisionRecs(new(rect.x, rect.y + slimeVel.Y, rect.width, rect.height), platform))
            {


                if (slimeVel.Y > 0)
                {
                    jump = true;
                    airborne = false;
                    if (!waiting)
                    {
                        jumpCooldown = 60;
                        waiting = true;
                    }
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
