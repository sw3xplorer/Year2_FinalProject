public class Text
{
    public bool restart = false;
    public static void StartText()
    {
        Raylib.DrawText("Title", 630, 150, 39, Color.BLACK);
        Raylib.DrawText("Enter to start", 560, 600, 30, Color.BLACK);
        Raylib.DrawText("Note: version alpha", 550, 700, 25, Color.BLACK);

    }

    public static void HUD(Player stats)
    {
        Raylib.DrawText($"Life: {stats.hp}", 10, 10, 39, Color.RED);
    }

    public static void WinText(Player pos)
    {
        Raylib.DrawText("Congrats!", 600, 150, 39, Color.BLACK);
        Raylib.DrawText("You won!", 600, 250, 39, Color.BLACK);
    }
    
    public static void LossText(Player pos)
    {
        Raylib.DrawText("You died", 600, 350, 39, Color.WHITE);
        // Raylib.DrawText("Press R to restart", 480, 400, 39, Color.WHITE);
        // if(Raylib.IsKeyPressed(KeyboardKey.KEY_R))
        // {
        //     sList.slimeList.Clear();
        //     skList.skeletonList.Clear();
        //     bList.batList.Clear();
        //     Slimes slimeList = new Slimes();
        //     Skeletons skeletonList = new Skeletons();
        //     Bats batList = new Bats();
        //     Player player = new Player();
        //     Weapon sword = new Weapon();
            
        // }
    }
}
