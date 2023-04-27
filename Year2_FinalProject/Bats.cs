public class Bats
{
    public List<Bat> batList = new();

    public Bats()
    {
        batList.Add(new(3200, 300));
        //4300-5800 x 1000 y

        batList.Add(new(4500, 350));
        batList.Add(new(4800, 350));
        batList.Add(new(5200, 500));
        batList.Add(new(5700, 650));
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
