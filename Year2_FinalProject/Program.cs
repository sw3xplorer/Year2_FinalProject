global using Raylib_cs;
string currentScene = "start";
Raylib.InitWindow(1366, 768, "Insert name here");
Raylib.SetTargetFPS(60);

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

    }


    Raylib.EndDrawing();
    //Logic

    if (currentScene == "start")
    {
        currentScene = Input.EnterToStart(currentScene);
    }


}