public class Player
{
    
    Vector2 velocity = new Vector2(0,0);
    Vector2 position = new Vector2(0,0);
    float force = 20;
    float gravity = 0.98f;
    float speed = 5;
    bool playerJump;
    Color clear = new Color(255, 255, 255, 0);
    Texture2D facing = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarR = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarL = Raylib.LoadTexture("avatarL.png");
    public Rectangle playerRect;

    public Player()
    {
        playerRect = new Rectangle(0, 0, avatarR.width, avatarR.height - 5);
    }

    public void Character()
    {
        Raylib.DrawRectangleRec(playerRect, clear);
        LeftOrRight();
    }

    public void LeftOrRight()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            Raylib.DrawTexture(avatarR, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
            facing = avatarR;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            Raylib.DrawTexture(avatarL, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
            facing = avatarL;
        }
        else
        {
            Raylib.DrawTexture(facing, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
        }
    }
    public void Controls()
    {
        velocity.X = 0;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
           velocity.X = speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            velocity.X = -speed;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && playerJump)
        {
            velocity.Y = -force;
            playerJump = false;
        }
        velocity.Y += gravity;
    }

    public void CheckCollision(Platforms p)
    {
        foreach (Rectangle platform in p.test)
        {
            if (Raylib.CheckCollisionRecs(new(playerRect.x, playerRect.y + velocity.Y, playerRect.width, playerRect.height), platform))
            {
                if(velocity.Y > 0)
                {
                    playerJump = true;
                }
                velocity.Y = 0;
            }
            if (Raylib.CheckCollisionRecs(new(playerRect.x + velocity.X, playerRect.y, playerRect.width, playerRect.height-1), platform))
            {
                velocity.X = 0;
            }

        }
        playerRect.x += velocity.X;
        playerRect.y += velocity.Y;

    }
    
}
