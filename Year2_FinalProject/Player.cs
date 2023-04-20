public class Player
{
    
    public Vector2 velocity = new Vector2(0,0);
    float force = 20;
    float gravity = 0.98f;
    float speed = 5;
    bool playerJump;
    public bool left;
    public int hp = 999999999;
    Color clear = new Color(255, 255, 255, 0);
    Texture2D facing = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarR = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarL = Raylib.LoadTexture("avatarL.png");
    public Rectangle playerRect;
    public Rectangle secondaryRect;

    public Player()
    {
        playerRect = new Rectangle(0, 50, avatarR.width, avatarR.height - 5);
        secondaryRect = new Rectangle((playerRect.width/2)-3, (playerRect.height/2)+30, 5, 30);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(playerRect, clear);
        Raylib.DrawRectangleRec(secondaryRect, clear);
        LeftOrRight();
    }
    
    public void LeftOrRight()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            facing = avatarR;
            left = false;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            facing = avatarL;
            left = true;
        }
       Raylib.DrawTexture(facing, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    }
    public void Controls()
    {
        if (velocity.X > 0) velocity.X--;
        else if (velocity.X < 0) velocity.X++;
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

    public void CheckCollision(Platforms p, Weapon sword)
    {
        foreach (Rectangle platform in p.platformList)
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

        secondaryRect.x += velocity.X;
        secondaryRect.y += velocity.Y;

        sword.rect.x += velocity.X;
        sword.rect.y += velocity.Y;

    }

    public void EnemyCollision(Slimes slimes, Skeletons skeletons, Bats bats, Weapon sword)
    {
        for (int i = 0; i < slimes.slimeList.Count(); i++)
        {

            if (Raylib.CheckCollisionRecs(playerRect, slimes.slimeList[i].rect))
            {
                if ((playerRect.x/2) > (slimes.slimeList[i].rect.x/2))
                {
                    velocity.X = slimes.slimeList[i].knockback.X;
                }
                else
                {
                    velocity.X = slimes.slimeList[i].knockback.X*-1;
                }
                velocity.Y = slimes.slimeList[i].knockback.Y;

                playerRect.x += velocity.X;
                playerRect.y += velocity.Y;

                secondaryRect.x += velocity.X;
                secondaryRect.y += velocity.Y;

                sword.rect.x += velocity.X;
                sword.rect.y += velocity.Y;
                hp--;
            }

        }

        for (int i = 0; i < skeletons.skeletonList.Count(); i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, skeletons.skeletonList[i].rect))
            {
                if ((playerRect.x/2) > (skeletons.skeletonList[i].rect.x/2))
                {
                    velocity.X = skeletons.skeletonList[i].knockback.X;
                }
                else
                {
                    velocity.X = skeletons.skeletonList[i].knockback.X*-1;
                }
                velocity.Y = skeletons.skeletonList[i].knockback.Y;

                playerRect.x += velocity.X;
                playerRect.y += velocity.Y;

                secondaryRect.x += velocity.X;
                secondaryRect.y += velocity.Y;

                sword.rect.x += velocity.X;
                sword.rect.y += velocity.Y;
                hp -= 3;
            }
        }

        for (int i = 0; i < bats.batList.Count(); i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, bats.batList[i].rect))
            {
                if ((playerRect.x/2) > (bats.batList[i].rect.x/2))
                {
                    velocity.X = bats.batList[i].knockback.X;
                }
                else
                {
                    velocity.X = bats.batList[i].knockback.X*-1;
                }
                velocity.Y = bats.batList[i].knockback.Y;

                playerRect.x += velocity.X;
                playerRect.y += velocity.Y;

                secondaryRect.x += velocity.X;
                secondaryRect.y += velocity.Y;

                sword.rect.x += velocity.X;
                sword.rect.y += velocity.Y;
                hp -= 2;
            }
            }
        }
    }
    
