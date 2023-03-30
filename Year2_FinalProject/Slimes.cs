
public class Slimes
{
    public List<Slime> slimeList = new();

    public Slimes()
    {
        slimeList.Add(new(100, 50));
        slimeList.Add(new(400, 50));
        slimeList.Add(new(900, 50));
    }

    public void Draw()
    {
        for (int i = 0; i < slimeList.Count(); i++)
        {
            slimeList[i].Draw();
        }
    }

    public void Collision(Platforms platforms, Player player)
    {
        for (int i = 0; i < slimeList.Count(); i++)
        {
            slimeList[i].Control(player);
            slimeList[i].CheckCollisions(platforms);

        }
    }
}
