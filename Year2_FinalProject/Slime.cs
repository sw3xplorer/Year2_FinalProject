public class Slime
{
    float gravity = 0.98f;
    float speed = 3;
    int force = 20;
    public int hp = 10;
    Color clear = new Color(255, 255, 255, 0);
    public Vector2 velocity = new Vector2(0, 0);
    Vector2 pos = new Vector2(0, 0);
    public Vector2 knockback = new Vector2(15, -15);
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
        Raylib.DrawRectangleRec(rect, Color.RED);
        Raylib.DrawTexture(sprite, (int)rect.x, (int)rect.y, Color.WHITE);
    }

    public void Control(Player player)
    {
        if (velocity.X > 0) velocity.X--;
        else if (velocity.X < 0) velocity.X++;
        if (jumpCooldown > 0) jumpCooldown--;

        if (velocity.Y == 0 && !airborne && jumpCooldown == 0)
        {
            velocity.Y = -force;
            jump = false;
            airborne = true;
            waiting = false;
        }

        if (rect.x < player.playerRect.x && airborne && jumpCooldown == 0)
        {
            velocity.X = speed;
        }

        if (rect.x > player.playerRect.x && airborne && jumpCooldown == 0)
        {
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
                    airborne = false;
                    if (!waiting)
                    {
                        jumpCooldown = 60;
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
