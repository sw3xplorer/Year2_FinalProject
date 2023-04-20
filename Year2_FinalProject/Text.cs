public class Text
{
    public static void StartText()
    {
        Raylib.DrawText("Title", 630, 150, 39, Color.BLACK);
        Raylib.DrawText("Enter to start", 560, 600, 30, Color.BLACK);
    }

    public static void HUD(Player stats)
    {
        Raylib.DrawText($"Life: {stats.hp}", (int)stats.playerRect.x - (Raylib.GetScreenWidth() / 2)+25, (int)stats.playerRect.y - (Raylib.GetScreenHeight() / 2)+25, 39, Color.RED);
    }

}
