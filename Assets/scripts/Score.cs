using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int highscore = 0;

    public void increment()
    {
        highscore++;
        Debug.Log("HIGHSCORE: " + highscore);
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
