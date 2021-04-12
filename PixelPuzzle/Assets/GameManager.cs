using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer orignImage;
    [SerializeField]
    private GameObject randomImage;
    [SerializeField]
    private Transform imageHolder;
    [SerializeField]
    private TextMeshProUGUI text;
    private Texture2D texture2D;
    private Color[] originColors;
    private SpriteRenderer[] randomImages;
    private string path = "Assets/Resources/Sample3.png";


    private void Awake()
    {
        LoadImage();
        CreateRandomImage();
    }

    private void Update()
    {
        CheckColors();
    }

    private void LoadImage()
    {
        texture2D = ImageLoader.OnLoad(path);
        orignImage.sprite = ImageLoader.CreateSprite(texture2D);
        originColors = texture2D.GetPixels();
    }

    private void CreateRandomImage()
    {
        Color[] colors = ImageLoader.RandomSortImage(path);
        for (int y = 0; y < texture2D.height; y++)
        {
            for (int x = 0; x < texture2D.width; x++)
            {
                GameObject clone = Instantiate(randomImage, imageHolder);
                Vector3 pos = new Vector3((float)x / 100, (float)y / 100, 0);
                Vector3 offset = new Vector3((float)texture2D.width / 100 / 2 - 0.005f, (float)texture2D.height / 100 / 2 - 0.005f, 0);
                clone.transform.localPosition = pos - offset;
            }
        }
        ApplyColor(colors);
    }

    private void ApplyColor(Color[] colors)
    {
        randomImages = imageHolder.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < colors.Length; i++)
            randomImages[i].color = colors[i];
    }

    private void CheckColors()
    {
        int correctColorCount = 0;
        for (int i = 0; i < originColors.Length; i++)
            if (originColors[i] == randomImages[i].color) correctColorCount++;
        if (correctColorCount == texture2D.width * texture2D.height) text.gameObject.SetActive(true);
    }
}
