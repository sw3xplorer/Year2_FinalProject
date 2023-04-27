public class Bat
{
    float speed = 4;
    public int hp = 5;
    Color clear = new Color(255, 255, 255, 0);
    public Vector2 velocity = new Vector2(0, 0);
    Vector2 pos = new Vector2(0, 0);
    public Vector2 knockback = new Vector2(8, -5);
    Texture2D spriteL = Raylib.LoadTexture("batL.png");
    Texture2D spriteR = Raylib.LoadTexture("batR.png");
    public List<Rectangle> bats = new();
    public Rectangle rect;

    public Bat(int x, int y)
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
        velocity.X = 0;
        velocity.Y = 0;
        if (velocity.X > 0) velocity.X--;
        else if (velocity.X < 0) velocity.X++;

        if (rect.x < player.playerRect.x && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
            if (velocity.X < 0)
            {
                velocity.X += 0.25f;
            }
            else
            {
                if (speed < 4) speed++;
                velocity.X = speed;
            }
        }

        else if (rect.x > player.playerRect.x && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
           if (velocity.X > 0)
            {
                velocity.X -= 0.25f;
            }
            else
            {
                if (speed < 4) speed++;
                velocity.X = -speed;
            }
        }
        if (rect.y < player.playerRect.y && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
            velocity.Y = speed;
        }
        else if (rect.y > player.playerRect.y && Raylib.CheckCollisionRecs(rect, player.detectionRect))
        {
            velocity.Y = -speed;
        }
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle platform in p.platformList)
        {
            if (Raylib.CheckCollisionRecs(new(rect.x, rect.y + velocity.Y, rect.width, rect.height), platform))
            {
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

