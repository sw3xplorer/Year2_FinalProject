public class Player
{

    public Vector2 velocity = new Vector2(0, 0);
    float force = 20;
    float gravity = 0.98f;
    float speed = 5;
    bool playerJump;
    public bool pause = false;
    public bool left;
    public int hp = 20;
    int timer = 0;
    Color clear = new Color(255, 255, 255, 0);
    Texture2D facing = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarR = Raylib.LoadTexture("avatarR.png");
    Texture2D avatarL = Raylib.LoadTexture("avatarL.png");
    public Rectangle playerRect;
    public Rectangle detectionRect;

    public Player()
    {
        playerRect = new Rectangle(0, 300, avatarR.width, avatarR.height - 5); // x= 0
        detectionRect = new Rectangle(-700 + (playerRect.width / 2), -100, 1400, 800); // x=-700
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(playerRect, clear);
        Raylib.DrawRectangleRec(detectionRect, clear);
        LeftOrRight();
    }

    public void LeftOrRight()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && velocity.X > 0)
        {
            facing = avatarR;
            left = false;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && velocity.X < 0)
        {
            facing = avatarL;
            left = true;
        }
        Raylib.DrawTexture(facing, (int)playerRect.x, (int)playerRect.y, Color.WHITE);
    }
    public void Controls()
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            if (velocity.X < 0)
            {
                velocity.X += 0.25f;
            }
            else
            {
                if (speed < 5) speed++;
                velocity.X = speed;
            }
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            if (velocity.X > 0)
            {
                velocity.X -= 0.25f;
            }
            else
            {
                if (speed < 5) speed++;
                velocity.X = -speed;
            }
        }
        else
        {
            if (velocity.X > 0) velocity.X--;
            else if (velocity.X < 0) velocity.X++;
        }


        if (Raylib.IsKeyPressed(KeyboardKey.KEY_W) && playerJump && velocity.Y == 0)
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
                if (velocity.Y > 0)
                {
                    playerJump = true;
                }
                velocity.Y = 0;
            }
            if (Raylib.CheckCollisionRecs(new(playerRect.x + velocity.X, playerRect.y, playerRect.width, playerRect.height - 1), platform))
            {
                velocity.X = 0;
            }

        }
        playerRect.x += velocity.X;
        playerRect.y += velocity.Y;

        detectionRect.x += velocity.X;
        detectionRect.y += velocity.Y;

        sword.rect.x += velocity.X;
        sword.rect.y += velocity.Y;

    }


    public void EnemyCollision(Slimes slimes, Skeletons skeletons, Bats bats, Weapon sword)
    {
        if (timer > 0) timer--;
        for (int i = 0; i < slimes.slimeList.Count(); i++)
        {

            if (Raylib.CheckCollisionRecs(playerRect, slimes.slimeList[i].rect) && timer == 0)
            {
                if ((playerRect.x / 2) > (slimes.slimeList[i].rect.x / 2))
                {
                    velocity.X = slimes.slimeList[i].knockback.X;
                }
                else
                {
                    velocity.X = slimes.slimeList[i].knockback.X * -1;
                }
                velocity.Y = slimes.slimeList[i].knockback.Y;
                hp--;
                timer = 90;
            }

        }

        for (int i = 0; i < skeletons.skeletonList.Count(); i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, skeletons.skeletonList[i].rect) && timer == 0)
            {
                if ((playerRect.x / 2) > (skeletons.skeletonList[i].rect.x / 2))
                {
                    velocity.X = skeletons.skeletonList[i].knockback.X;
                }
                else
                {
                    velocity.X = skeletons.skeletonList[i].knockback.X * -1;
                }
                velocity.Y = skeletons.skeletonList[i].knockback.Y;
                hp -= 3;
                timer = 90;
            }
        }

        for (int i = 0; i < bats.batList.Count(); i++)
        {
            if (Raylib.CheckCollisionRecs(playerRect, bats.batList[i].rect) && timer == 0)
            {
                if ((playerRect.x / 2) > (bats.batList[i].rect.x / 2))
                {
                    velocity.X = bats.batList[i].knockback.X;
                }
                else
                {
                    velocity.X = bats.batList[i].knockback.X * -1;
                }
                velocity.Y = bats.batList[i].knockback.Y;
                hp -= 2;
                timer = 90;
            }
        }
    }
}

