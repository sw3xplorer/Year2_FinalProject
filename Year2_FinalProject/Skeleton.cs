public class Skeleton
{
    float gravity = 0.98f;
    float speed = 1.5f;
    int force = 15;
    public int hp = 20;
    Color clear = new Color(255, 255, 255, 0);
    public Vector2 velocity = new Vector2(0, 0);
    Vector2 pos = new Vector2(0, 0);
    public Vector2 knockback = new Vector2(15, -15);
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
        if (velocity.X >= 0)
        {
            Raylib.DrawTexture(spriteR, (int)rect.x, (int)rect.y, Color.WHITE);
        }
        else if (velocity.X <= 0)
        {
            Raylib.DrawTexture(spriteL, (int)rect.x, (int)rect.y, Color.WHITE);
        }
    }

    public void Control(Player player)
    {
        if (velocity.X > 0) velocity.X--;
        else if (velocity.X < 0) velocity.X++;


        if (jumpCooldown > 0) jumpCooldown--;

        if (velocity.Y == 0 && jump && jumpCooldown == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_W))
        {
            velocity.Y = -force;
            jump = false;
            waiting = false;
        }

        if (rect.x < player.playerRect.x && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
            if (velocity.X < 0)
            {
                velocity.X += 0.25f;
            }
            else
            {
                if (speed < 1.5f) speed++;
                velocity.X = speed;
            }
            // velocity.X = speed;
        }

        if (rect.x > player.playerRect.x && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
            if (velocity.X > 0)
            {
                velocity.X -= 0.25f;
            }
            else
            {
                if (speed < 1.5f) speed++;
                velocity.X = -speed;
            }
            velocity.X = -speed;
        }
        velocity.Y += gravity;
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle platform in p.platformList)
        {
            if (Raylib.CheckCollisionRecs(new(rect.x, rect.y + velocity.Y, rect.width, rect.height), platform))
            {


                if (velocity.Y > 0)
                {
                    jump = true;
                    if (!waiting)
                    {
                        jumpCooldown = 480;
                        waiting = true;
                    }
                }
                velocity.Y = 0;
            }
            if (Raylib.CheckCollisionRecs(new(rect.x + velocity.X, rect.y, rect.width, rect.height - 1), platform))
            {
                velocity.X = 0;
            }
        }
        rect.x += velocity.X;
        rect.y += velocity.Y;
    }
}
