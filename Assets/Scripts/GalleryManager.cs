using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GalleryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject galleryImage;
    [SerializeField]
    private Transform content;

    private void Awake()
    {
        for (int i = 0; i < DataManager.clearDatas.Count; i++)
        {
            if (DataManager.clearDatas[i].isClear)
            {
                GameObject clone = Instantiate(galleryImage, content);
                clone.GetComponent<GalleryImage>().Init(ImageLoader.OnLoad(DataManager.clearDatas[i].name), DataManager.clearDatas[i].name);
            }
        }
    }
}
