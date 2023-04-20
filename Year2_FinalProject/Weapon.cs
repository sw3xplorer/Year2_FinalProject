public class Weapon
{
    Color clear = new Color(255, 255, 255, 0);
    Texture2D sprite = Raylib.LoadTexture("Gladius.png");
    Vector2 origin = new Vector2(9.5f, 58);
    Vector2 knockback = new Vector2(20, -10);
    int timer = 0;
    int dmg = 3;
    public float rotation;
    public bool swing;
    public bool contact = false;
    public Rectangle rect;
    public Weapon(Player player)
    {
        rect = new Rectangle(player.playerRect.x + player.playerRect.width-5, player.playerRect.y+18, 30, sprite.height+10);
    }
    public void Draw(Player direction)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_E) && !direction.left && timer == 0 || (Raylib.IsKeyPressed(KeyboardKey.KEY_E) && direction.left && timer == 0))
        {  
            rotation = 0;
            timer = 120;
            swing = true;
        }

        if (timer > 0 && !direction.left)
        {
            rect.x = direction.playerRect.x + direction.playerRect.width-5;
            rotation += 15;
            Raylib.DrawRectangleRec(rect, Color.BLUE);
            Raylib.DrawTexturePro(sprite, new(0,0, sprite.width, sprite.height), rect, origin, rotation, Color.WHITE);
            timer--;
            if (timer == 0) swing = false;
        }
        
        else if (timer > 0 && direction.left)
        {
            rect.x = direction.playerRect.x-25;
            rotation -= 15;
            Raylib.DrawRectangleRec(rect, Color.BLUE);
            Raylib.DrawTexturePro(sprite, new(0,0, sprite.width, sprite.height), new Rectangle(direction.playerRect.x-5, direction.playerRect.y+18, 30, sprite.height+10), origin, rotation, Color.WHITE);
            timer--;
            if (timer == 0) swing = false;
        }
        
    }

    public void Collision(Slimes slimes, Skeletons skeletons, Bats bats, Player facing)
    {
        for (int i = 0; i < slimes.slimeList.Count(); i++)
        {   

            if (Raylib.CheckCollisionRecs(rect, slimes.slimeList[i].rect) && swing && !contact)
            {
                slimes.slimeList[i].hp -= dmg;

                if (facing.left)
                {
                    slimes.slimeList[i].velocity.X = knockback.X*-1;
                }
                else slimes.slimeList[i].velocity.X = knockback.X;

                slimes.slimeList[i].velocity.Y = knockback.Y;

                contact = true;
                Console.WriteLine("HIT");

                slimes.slimeList[i].rect.x += slimes.slimeList[i].velocity.X;
                slimes.slimeList[i].rect.y += slimes.slimeList[i].velocity.Y;
            }
            else if (timer == 0)
            {
                contact = false;
            }

            if (slimes.slimeList[i].hp <= 0)
            {
                slimes.slimeList.RemoveAt(i);
                break;
            }

        }

        for (int i = 0; i < skeletons.skeletonList.Count(); i++)
        {   

            if (Raylib.CheckCollisionRecs(rect, skeletons.skeletonList[i].rect) && swing && !contact)
            {
                skeletons.skeletonList[i].hp -= dmg;

                if (facing.left)
                {
                    skeletons.skeletonList[i].velocity.X = knockback.X*-1;
                }
                else skeletons.skeletonList[i].velocity.X = knockback.X;

                skeletons.skeletonList[i].velocity.Y = knockback.Y;

                contact = true;
                Console.WriteLine("HIT");

                skeletons.skeletonList[i].rect.x += skeletons.skeletonList[i].velocity.X;
                skeletons.skeletonList[i].rect.y += skeletons.skeletonList[i].velocity.Y;
            }
            else if (timer == 0)
            {
                contact = false;
            }

            if (skeletons.skeletonList[i].hp <= 0)
            {
                skeletons.skeletonList.RemoveAt(i);
                break;
            }

        }


        for (int i = 0; i < bats.batList.Count(); i++)
        {   

            if (Raylib.CheckCollisionRecs(rect, bats.batList[i].rect) && swing && !contact)
            {
                bats.batList[i].hp -= dmg;

                if (facing.left)
                {
                    bats.batList[i].velocity.X = knockback.X*-1;
                }
                else bats.batList[i].velocity.X = knockback.X;

                bats.batList[i].velocity.Y = knockback.Y;

                contact = true;
                Console.WriteLine("HIT");

                bats.batList[i].rect.x += bats.batList[i].velocity.X;
                bats.batList[i].rect.y += bats.batList[i].velocity.Y;
            }
            else if (timer == 0)
            {
                contact = false;
            }

            if (bats.batList[i].hp <= 0)
            {
                bats.batList.RemoveAt(i);
                break;
            }

        }
    }
}
