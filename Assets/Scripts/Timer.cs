using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static string GetTime(float time)
    {
        int s = (int)time % 60;
        int m = (int)time / 60;
        int h = m / 60;
        m = m % 60;

        if (h > 0) return $"{h}�ð� {m}�� {s}��";
        else if (m > 0) return $"{m}�� {s}��";
        else return $"{s}��";
    }
}
