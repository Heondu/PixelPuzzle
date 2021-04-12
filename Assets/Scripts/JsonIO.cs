using UnityEngine;
using System.IO;

public class JsonIO : MonoBehaviour
{
    private static string path = "Assets/Resources/ClearData/";

    public static void SaveToJson<T>(T t, string fileName)
    {
        if (IsExists(fileName) == false) CreateFile(fileName);
        string jsonString = JsonUtility.ToJson(t, true);
        File.WriteAllText(path + fileName + ".json", jsonString);
    }

    public static T LoadFromJson<T>(string fileName)
    {
        if (IsExists(fileName) == false) CreateFile(fileName);
        string jsonString = File.ReadAllText(path + fileName + ".json");
        return JsonUtility.FromJson<T>(jsonString);
    }

    private static bool IsExists(string fileName)
    {
        if (File.Exists(path + fileName + ".json")) return true;
        else return false;
    }

    private static void CreateFile(string fileName)
    {
        File.Create(path + fileName + ".json").Close();
    }
}
