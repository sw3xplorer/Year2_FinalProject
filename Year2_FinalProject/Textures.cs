public class Textures
{
    public List<Texture2D> textureList = new();

    public void addTexture(Texture2D texture)
    {
        textureList.Add(texture);
    }
    public void AddTexture(string texturePath)
    {
        textureList.Add(Raylib.LoadTexture(texturePath));
    }
    public void DrawTextureNum(int num, int posX, int posY)
    {
        Raylib.DrawTexture(textureList[num], posX, posY, Color.WHITE);
    }
}  