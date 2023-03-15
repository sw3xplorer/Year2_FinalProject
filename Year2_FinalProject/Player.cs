public class Player
{
    Texture2D facing = Raylib.LoadTexture("avatarR.png");
    float speed = 5;
    float gravity = 9;
    Color clear = new Color (255, 255, 255, 0);
    Texture2D avatarR = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarL = Raylib.LoadTexture("avatarL.png");
    Rectangle playerRect;

    public Player()
    {
        playerRect = new Rectangle(0, 0, avatarR.width, avatarR.height);
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
        else if(Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            playerRect.x -= speed;
        }
        
    }

    public void CheckCollision(Platforms p)
    {
        if(Raylib.CheckCollisionRecs(playerRect, p.platform))
        {
            playerRect.y += 0;
        }
        else 
        {
            playerRect.y += gravity;
        }
    }
}
