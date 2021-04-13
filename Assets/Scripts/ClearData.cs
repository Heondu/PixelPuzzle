[System.Serializable]
public class ClearData
{
    public string name;
    public string time;
    public string rank;
    public int moveNum;
    public bool isClear;

    public ClearData(string name)
    {
        this.name = name;
        time = "";
        rank = "";
        moveNum = 0;
        isClear = false;
    }
}
