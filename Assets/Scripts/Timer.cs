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

        if (h > 0) return $"{h}시간 {m}분 {s}초";
        else if (m > 0) return $"{m}분 {s}초";
        else return $"{s}초";
    }
}
