global using Raylib_cs;
global using System.Numerics;
Raylib.InitWindow(1370, 770, "Insert name here");
string currentScene = "start";
Camera2D camera = new(Vector2.Zero, Vector2.Zero, 0, 1);

// public List<Texture2D> backgrounds = new() {  }
Slimes slimeList = new Slimes();
Skeletons skeletonList = new Skeletons();
Bats batList = new Bats();
Player player = new Player();
Platforms platforms = new Platforms();
Weapon sword = new Weapon(player);

Raylib.SetTargetFPS(60);

while (!Raylib.WindowShouldClose())
{
    //Graphics
    Raylib.BeginDrawing();
    Raylib.BeginMode2D(camera);
    Raylib.ClearBackground(Color.GRAY);

    if (currentScene == "start")
    {
        Text.StartText();
    }
    else if (currentScene == "game")
    {
        Text.HUD(player);
        player.Draw();
        sword.Draw(player);
        // slimeList.Draw();
        // skeletonList.Draw();
        // batList.Draw();
        camera.target = new(player.playerRect.x - (Raylib.GetScreenWidth() / 2), player.playerRect.y - (Raylib.GetScreenHeight() / 2));
        platforms.DrawPlatforms();
        
    }
    else if (currentScene == "loss")
    {
        Raylib.ClearBackground(Color.BLACK);
    }
    Raylib.EndMode2D();
    Raylib.EndDrawing();

    //Logic

    if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER)) currentScene = "game";
    }

    else if (currentScene == "game")
    {
        player.Controls();
        player.CheckCollision(platforms, sword);
        player.EnemyCollision(slimeList, skeletonList, batList, sword);
        // slimeList.Collision(platforms, player);
        // skeletonList.Collision(platforms, player);
        // batList.Collision(platforms, player);
        sword.Collision(slimeList, skeletonList, batList, player);
        if (player.hp == 0) currentScene = "loss";
    }


}

