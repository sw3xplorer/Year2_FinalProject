public class Skeleton
{
    float gravity = 0.98f;
    float speed = 4;
    int force = 15;
    Color clear = new Color(255, 255, 255, 0);
    Vector2 vel = new Vector2(0, 0);
    Vector2 pos = new Vector2(0, 0);
    public Vector2 knockback = new Vector2(20, -15);
    Texture2D spriteL = Raylib.LoadTexture("skeletonL.png");
    Texture2D spriteR = Raylib.LoadTexture("skeletonR.png");
    public List<Rectangle> skeletons = new();
    public Rectangle rect;
    bool jump;
    int jumpCooldown;
    bool waiting;

    public Skeleton(int x, int y)
    {
        rect = new Rectangle(x, y, spriteL.width, spriteL.height);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(rect, clear);
        if (vel.X >= 0)
        {
            Raylib.DrawTexture(spriteR, (int)rect.x, (int)rect.y, Color.WHITE);
        }
        else if (vel.X <= 0)
        {
            Raylib.DrawTexture(spriteL, (int)rect.x, (int)rect.y, Color.WHITE);
        }
    }

    public void Control(Player player)
    {
        vel.X = 0;
        if (jumpCooldown > 0) jumpCooldown--;

        if (vel.Y == 0 && jump && jumpCooldown == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_W))
        {
            vel.Y = -force;
            jump = false;
            waiting = false;
        }

        if (rect.x < player.playerRect.x)
        {
            vel.X = speed;
        }

        if (rect.x > player.playerRect.x)
        {
            vel.X = -speed;
        }
        vel.Y += gravity;
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle platform in p.platformList)
        {
            if (Raylib.CheckCollisionRecs(new(rect.x, rect.y + vel.Y, rect.width, rect.height), platform))
            {


                if (vel.Y > 0)
                {
                    jump = true;
                    if (!waiting)
                    {
                        jumpCooldown = 480;
                        waiting = true;
                    }
                }
                vel.Y = 0;
            }
            if (Raylib.CheckCollisionRecs(new(rect.x + vel.X, rect.y, rect.width, rect.height - 1), platform))
            {
                vel.X = 0;
            }
        }
        rect.x += vel.X;
        rect.y += vel.Y;
    }
}
