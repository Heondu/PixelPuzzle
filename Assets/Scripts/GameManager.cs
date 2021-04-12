using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer originImage;
    [SerializeField]
    private SpriteRenderer originImageBorder;
    [SerializeField]
    private GameObject randomImage;
    [SerializeField]
    private Transform imageHolder;
    [SerializeField]
    private SpriteRenderer randomImageBorder;
    [SerializeField]
    private TextMeshProUGUI time;
    private Texture2D texture;
    private Color[] originColors;
    private SpriteRenderer[] randomImages;
    private static ClearData clearData;
    private float currentTime = 0;
    private int moveNum = 0;

    private void Awake()
    {
        texture = DataManager.texture;
        LoadImage();
        CreateRandomImage();
    }

    private void Start()
    {
        clearData = DataManager.FindClearData(DataManager.name);
        int incorrectColorCount = 0;
        for (int i = 0; i < originColors.Length; i++)
            if (originColors[i] != randomImages[i].color) incorrectColorCount++;
        clearData.minMoveNum = incorrectColorCount / 2 + 1;
    }

    private void Update()
    {
        CheckColors();
        currentTime += Time.deltaTime;
        clearData.time = Timer.GetTime(currentTime);
        time.text = clearData.time;
    }

    private void LoadImage()
    {
        originImage.sprite = ImageLoader.CreateSprite(texture);
        originImageBorder.sprite = ImageLoader.CreateSprite(new Texture2D(texture.width + 1, texture.height + 1));
        randomImageBorder.sprite = ImageLoader.CreateSprite(new Texture2D(texture.width + 1, texture.height + 1));
        originColors = texture.GetPixels();
    }

    private void CreateRandomImage()
    {
        Color[] colors = ImageLoader.RandomSortImage(texture);
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                GameObject clone = Instantiate(randomImage, imageHolder);
                Vector3 pos = new Vector3((float)x / 100, (float)y / 100, 0);
                Vector3 offset = new Vector3((float)texture.width / 100 / 2 - 0.005f, (float)texture.height / 100 / 2 - 0.005f, 0);
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
        if (correctColorCount == texture.width * texture.height && Input.GetMouseButtonDown(0) == false)
        {
            clearData.moveNum = moveNum + 1;
            if (clearData.moveNum < clearData.minMoveNum * 1.5f) clearData.rank = "★★★";
            else if (clearData.moveNum < clearData.minMoveNum * 2f) clearData.rank = "★★☆";
            else clearData.rank = "★☆☆";
            clearData.isClear = true;
            SceneLoader.LoadScene("Result");
        }
    }

    public void AddMoveNum()
    {
        moveNum++;
    }
}
