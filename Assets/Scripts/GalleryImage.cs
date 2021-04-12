using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GalleryImage : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private new TextMeshProUGUI name;

    public void Init(Texture2D texture, string name)
    {
        rawImage.texture = texture;
        this.name.text = name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DataManager.texture = rawImage.texture as Texture2D;
        DataManager.name = name.text;
        SceneLoader.LoadScene("Popup");
    }
}
