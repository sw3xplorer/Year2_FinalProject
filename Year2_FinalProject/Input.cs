public class Input
{
    public static string EnterToStart(string scene)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
        {
            return "game";
        }

        return scene;
    }
}
