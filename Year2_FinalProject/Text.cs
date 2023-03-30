public class Text
{
    public static void StartText()
    {
        Raylib.DrawText("Title", 630, 150, 39, Color.BLACK);
        Raylib.DrawText("Enter to start", 560, 600, 30, Color.BLACK);
    }

    public static void HUD(Player stats)
    {
        Raylib.DrawText($"{stats.hp}", 0, 0, 39, Color.BLACK);
        
    }

}
