using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public int XX = 0;
    public int YY = 0;

    void Start()
    {
        string tempstr = "Mine_[3, 1]";
        string cutstr = tempstr.Substring(tempstr.IndexOf("[")+1).Trim();
        int pos = cutstr.IndexOf(']');

        string cutstr2 = cutstr.Substring(0, pos);

        string[] splite = cutstr2.Split(",");

        XX = int.Parse(splite[0]);
        YY = int.Parse(splite[1]);
    }

    void Update()
    {
        
    }
}
