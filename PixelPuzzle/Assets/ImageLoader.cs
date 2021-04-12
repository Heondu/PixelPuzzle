using UnityEngine;
using System.IO;

public class ImageLoader : MonoBehaviour
{
    public static Texture2D OnLoad(string path)
    {
        byte[] byteTexture = File.ReadAllBytes(path);
        Texture2D texture2D = new Texture2D(0, 0);
        texture2D.filterMode = FilterMode.Point;
        if (byteTexture.Length > 0)
        {
            texture2D.LoadImage(byteTexture);
        }
        return texture2D;
    }

    public static Color[] RandomSortImage(string path)
    {
        Texture2D texture2D = OnLoad(path);
        for (int x = 0; x < texture2D.width; x++)
        {
            for (int y = 0; y < texture2D.height; y++)
            {
                int randX = Random.Range(0, texture2D.width + 1);
                int randY = Random.Range(0, texture2D.height + 1);
                Color temp = texture2D.GetPixel(randX, randY);
                texture2D.SetPixel(randX, randY, texture2D.GetPixel(x, y));
                texture2D.SetPixel(x, y, temp);
            }
        }
        texture2D.Apply();
        return texture2D.GetPixels(0, 0, texture2D.width, texture2D.height);
    }

    public static Sprite CreateSprite(Texture2D texture2D)
    {
        return Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
    }
}
