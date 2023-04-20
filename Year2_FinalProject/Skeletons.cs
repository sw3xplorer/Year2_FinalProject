public class Skeletons
{
    public List<Skeleton> skeletonList = new();

    public Skeletons()
    {
        skeletonList.Add(new(500, 50));
        skeletonList.Add(new(700, 50));
        skeletonList.Add(new(1100, 50));
    }

    public void Draw()
    {
        for (int i = 0; i < skeletonList.Count(); i++)
        {
            skeletonList[i].Draw();
        }
    }

    public void Collision(Platforms platforms, Player player)
    {
        for (int i = 0; i < skeletonList.Count(); i++)
        {
            skeletonList[i].Control(player);
            skeletonList[i].CheckCollisions(platforms);

        }
    }

}
