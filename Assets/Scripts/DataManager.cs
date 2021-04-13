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
    public static DataManager instance;
    public Texture2D texture;
    public new string name;
    public List<ClearData> clearDatas = new List<ClearData>();

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
        DontDestroyOnLoad(gameObject);
        if (JsonIO.LoadFromJson<Serialization<ClearData>>("ClearData") != null)
            clearDatas = JsonIO.LoadFromJson<Serialization<ClearData>>("ClearData").ToList();
    }

    public ClearData FindClearData(string name)
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