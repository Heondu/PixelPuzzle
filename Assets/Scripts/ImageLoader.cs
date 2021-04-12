using UnityEngine;
using System.IO;

public class ImageLoader : MonoBehaviour
{
    private static string path = "Assets/Resources/Images/";

    public static Texture2D OnLoad(string fileName)
    {
        byte[] byteTexture = File.ReadAllBytes(path + fileName + ".png");
        Texture2D texture2D = new Texture2D(0, 0, TextureFormat.RGBA32, false);
        texture2D.filterMode = FilterMode.Point;
        if (byteTexture.Length > 0)
        {
            texture2D.LoadImage(byteTexture);
        }
        return texture2D;
    }

    public static Color[] RandomSortImage(Texture2D texture)
    {
        Texture2D randTexture = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        randTexture.SetPixels(texture.GetPixels());
        for (int x = 0; x < randTexture.width; x++)
        {
            for (int y = 0; y < randTexture.height; y++)
            {
                int randX = Random.Range(0, randTexture.width + 1);
                int randY = Random.Range(0, randTexture.height + 1);
                Color temp = randTexture.GetPixel(randX, randY);
                randTexture.SetPixel(randX, randY, randTexture.GetPixel(x, y));
                randTexture.SetPixel(x, y, temp);
            }
        }
        randTexture.Apply();
        return randTexture.GetPixels(0, 0, randTexture.width, randTexture.height);
    }

    public static Sprite CreateSprite(Texture2D texture)
    {
        if (texture.filterMode != FilterMode.Point) texture.filterMode = FilterMode.Point;
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }
}
