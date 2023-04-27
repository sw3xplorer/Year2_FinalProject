
public class Slimes
{
    public List<Slime> slimeList = new();
    public Slimes()
    {
        slimeList.Add(new(1000, 325));
        slimeList.Add(new(1050, 470));
        slimeList.Add(new(1400, 270));
        slimeList.Add(new(3200, 470));
        slimeList.Add(new(3600, 470));
        slimeList.Add(new(4350, 960));
        slimeList.Add(new(4650, 960));
        slimeList.Add(new(5000, 960));
        slimeList.Add(new(5350, 960));
        slimeList.Add(new(5650, 960));
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
