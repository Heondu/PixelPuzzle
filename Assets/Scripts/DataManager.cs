using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Serialization<T>
{
    [SerializeField]
    private List<T> list;
    public List<T> ToList() { return list; }
    public Serialization(List<T> list) { this.list = list; }
}

public class DataManager : MonoBehaviour
{
    public static Texture2D texture;
    public static new string name;
    public static List<ClearData> clearDatas = new List<ClearData>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (JsonIO.LoadFromJson<Serialization<ClearData>>("ClearData") != null)
            clearDatas = JsonIO.LoadFromJson<Serialization<ClearData>>("ClearData").ToList();
    }

    public static ClearData FindClearData(string name)
    {
        for (int i = 0; i < clearDatas.Count; i++)
        {
            if (clearDatas[i].name == name) return clearDatas[i];
        }
        return null;
    }

    private void OnApplicationQuit()
    {
        JsonIO.SaveToJson(new Serialization<ClearData>(clearDatas), "ClearData");
    }
}