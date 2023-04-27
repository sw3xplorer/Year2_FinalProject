public class Skeletons
{
    public List<Skeleton> skeletonList = new();

    public Skeletons()
    {
        skeletonList.Add(new(2300, 410));
        skeletonList.Add(new(3600, 250));
        skeletonList.Add(new(4500, 920));
        skeletonList.Add(new(5150, 920));
        skeletonList.Add(new(5700, 920));

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
