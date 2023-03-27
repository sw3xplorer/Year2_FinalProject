global using Raylib_cs;
global using System.Numerics;
Raylib.InitWindow(1370, 770, "Insert name here");
string currentScene = "start";
Camera2D camera = new(Vector2.Zero, Vector2.Zero, 0, 1);
// public List<Texture2D> backgrounds = new() {  }
Player player = new Player();
Enemies enemies = new Enemies();
Slimes slime = new Slimes();

Raylib.SetTargetFPS(60);
Platforms platforms = new Platforms();

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
        player.Character();
        slime.Draw();
        camera.target = new(player.playerRect.x - (Raylib.GetScreenWidth() / 2), player.playerRect.y - (Raylib.GetScreenHeight() / 2));
        platforms.DrawPlatforms();
    }
    Raylib.EndMode2D();
    Raylib.EndDrawing();

    //Logic

    if (currentScene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            currentScene = "game";
        }
    }

    else if (currentScene == "game")
    {
        player.Controls();
        player.CheckCollision(platforms);
        slime.Control(player);
        slime.CheckCollision2(platforms);
    }


}