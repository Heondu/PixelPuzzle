using UnityEngine;
using UnityEngine.UI;

public class TitleImageLoader : MonoBehaviour
{
    [SerializeField]
    private GameObject image;
    [SerializeField]
    private Transform content;

    private void Awake()
    {
        Texture2D[] textures = Resources.LoadAll<Texture2D>("Images");
        
        for (int i = 0; i < textures.Length; i++)
        {
            GameObject clone = Instantiate(image, content);
            Texture2D texture = ImageLoader.OnLoad(textures[i].name);
            ImageScript imageScript = clone.GetComponent<ImageScript>();
            imageScript.texture = texture;

            ClearData clearData = DataManager.instance.FindClearData(textures[i].name);
            if (clearData == null)
            {
                clearData = new ClearData(textures[i].name);
                DataManager.instance.clearDatas.Add(clearData);
            }
            imageScript.clearData = clearData;
        }
    }
}
