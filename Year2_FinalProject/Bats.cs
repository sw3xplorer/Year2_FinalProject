public class Bats
{
    public List<Bat> batList = new();

    public Bats()
    {
        batList.Add(new(100, 20));
        batList.Add(new(400, 20));
        batList.Add(new(900, 20));
    }

    public void Draw()
    {
        for (int i = 0; i < batList.Count(); i++)
        {
            batList[i].Draw();
        }
    }

    public void Collision(Platforms platforms, Player player)
    {
        for (int i = 0; i < batList.Count(); i++)
        {
            batList[i].Control(player);
            batList[i].CheckCollisions(platforms);

        }
    }
}
