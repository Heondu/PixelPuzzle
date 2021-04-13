using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayResult : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private new TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI time;
    [SerializeField]
    private TextMeshProUGUI rank;
    [SerializeField]
    private TextMeshProUGUI moveNum;

    private void Awake()
    {
        rawImage.texture = DataManager.instance.texture;
        ClearData clearData = DataManager.instance.FindClearData(DataManager.instance.name);
        name.text = clearData.name;
        time.text = clearData.time;
        rank.text = clearData.rank;
        moveNum.text = clearData.moveNum.ToString();
    }
}
