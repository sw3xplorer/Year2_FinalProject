global using Raylib_cs;
string currentScene = "start";
// public List<Texture2D> backgrounds = new() {  }
Raylib.InitWindow(1370, 770, "Insert name here");
Raylib.SetTargetFPS(60);
Player player = new Player();
Platforms platforms = new Platforms();

while (!Raylib.WindowShouldClose())
{
    //Graphics
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (currentScene == "start")
    {
        Text.StartText();
    }

    else if (currentScene == "game")
    {
        player.Character();
        platforms.DrawPlatforms();
    }

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
    }

}