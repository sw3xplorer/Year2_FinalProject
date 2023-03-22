public class Player
{

    float speed = 5;
    float velocity;
    float force = 20;
    float gravity = 0.98f;
    bool onGround;
    bool playerJump;
    Color clear = new Color(255, 255, 255, 0);
    Texture2D facing = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarR = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarL = Raylib.LoadTexture("avatarL.png");
    Rectangle playerRect;

    public Player()
    {
        playerRect = new Rectangle(0, 0, avatarR.width, avatarR.height - 5);
    }

    public void Character()
    {
        Raylib.DrawRectangleRec(playerRect, Color.WHITE);
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
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && playerJump && onGround)
        {
            velocity = -force;
            playerJump = false;
        }

        velocity += gravity;
        playerRect.y += velocity;

    }

    public void CheckCollision(Platforms p)
    {
        foreach (Rectangle platform in p.test)
        {

            if (Raylib.CheckCollisionRecs(playerRect, platform))
            {
                // playerRect.y = platform.y - playerRect.height;
                velocity = 0;
                playerRect.y -= gravity;
                playerJump = true;
                onGround = true;
            }
        }
    }
}
