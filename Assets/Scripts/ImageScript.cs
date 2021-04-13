using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ImageScript : MonoBehaviour, IPointerClickHandler
{
    public Texture2D texture;
    public ClearData clearData;
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private new TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI time;
    [SerializeField]
    private TextMeshProUGUI rank;
    [SerializeField]
    private TextMeshProUGUI moveNum;

    private void Start()
    {
        image.texture = texture;
        name.text = clearData.name;

        if (clearData.isClear)
        {
            time.text = clearData.time;
            rank.text = clearData.rank;
            moveNum.text = clearData.moveNum.ToString();
            time.gameObject.SetActive(true);
            rank.gameObject.SetActive(true);
            moveNum.gameObject.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DataManager.instance.texture = texture;
        DataManager.instance.name = clearData.name;
        SceneLoader.LoadScene("Main");
    }
}
