public class Slimes
{
    float gravity = 0.98f;
    Color clear = new Color(255, 255, 255, 0);
    Vector2 slimeVel = new Vector2(0, 0);
    Vector2 slimePos = new Vector2(0, 0);
    float speed = 3;
    Texture2D sprite = Raylib.LoadTexture("slime.png");
    public List<Rectangle> slimes = new();
    Rectangle rect;
    bool jump;

    public Slimes()
    {
        slimes.Add(rect = new Rectangle(20, 468, rect.width, rect.height));
        slimes.Add(rect = new Rectangle(300, 450, rect.width, rect.height));
        slimes.Add(rect = new Rectangle(100, 300, rect.width, rect.height));
    }

    public void Draw()
    {
        foreach (Rectangle Slime in slimes)
        {
            Raylib.DrawRectangleRec(Slime, clear);
            Raylib.DrawTexture(this.sprite, (int)Slime.x, (int)Slime.y, Color.WHITE);
        }
    }

    public void Control(Player playerPos)
    {
        slimeVel.X = 0;
        for (int i = 0; i < slimes.Count; i++)
        {
            Rectangle slime = slimes[i]; //skapar en rektangel slime beroende på vilken i

            if (slime.x < playerPos.playerRect.x)
            {
                slimeVel.X = speed; //updaterar positionen
            }
            if (slime.x > playerPos.playerRect.x)
            {
                slimeVel.X = -speed; //updaterar positionen
            }
            // slime.y += slimeVel.Y;
            // slime.x += slimeVel.X;
            slimeVel.Y += gravity;

            slimes[i] = slime; //uploadar positionen in i listan
        }
    }

    public void CheckCollisions(Platforms p)
    {
        foreach (Rectangle slime in slimes)
        {
            foreach (Rectangle platform in p.test)
            {
                if (Raylib.CheckCollisionRecs(new(slime.x, slime.y + slimeVel.Y, slime.width, slime.height), platform))
                {
                    if (slimeVel.Y > 0)
                    {
                        jump = true;
                    }
                    this.slimeVel.Y = 0;
                }
                if (Raylib.CheckCollisionRecs(new(slime.x + slimeVel.X, slime.y, slime.width, slime.height - 1), platform))
                {
                    this.slimeVel.X = 0;
                }
            }
            rect.x += slimeVel.X;
            rect.y += slimeVel.Y;
        }
    }

    public void CheckCollision2(Platforms p)
    {
        for (int i = 0; i < slimes.Count; i++)
        {
            Rectangle slime = slimes[i];
            foreach (Rectangle platform in p.test)
            {
                if (Raylib.CheckCollisionRecs(new(slime.x, slime.y + slimeVel.Y, slime.width, slime.height), platform))
                {
                    if (slimeVel.Y > 0)
                    {
                        jump = true;
                    }
                    slimeVel.Y = 0;
                }
                if (Raylib.CheckCollisionRecs(new(slime.x + slimeVel.X, slime.y, slime.width, slime.height - 1), platform))
                {
                    slimeVel.X = 0;
                }
            }
            slime.x += slimeVel.X;
            slime.y += slimeVel.Y;

            slimes[i] = slime;
        }
    }
}
