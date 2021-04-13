using UnityEngine;

public class GalleryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject galleryImage;
    [SerializeField]
    private Transform content;

    private void Awake()
    {
        for (int i = 0; i < DataManager.instance.clearDatas.Count; i++)
        {
            if (DataManager.instance.clearDatas[i].isClear)
            {
                string name = DataManager.instance.clearDatas[i].name;
                GameObject clone = Instantiate(galleryImage, content);
                clone.GetComponent<GalleryImage>().Init(Resources.Load<Texture2D>("Images/" + name), name);
            }
        }
    }
}
