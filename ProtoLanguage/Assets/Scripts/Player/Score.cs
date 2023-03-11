using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score")]
public class Score : ScriptableObject
{
    public uint total;

    public uint[] levels = new uint[8];

    public void UpdateScore()
    {
        uint temp = 0;
        for (int i = 0; i < levels.Length; i++)
        {
            if (levels[i] > 3)
                levels[i] = 3;

            temp += levels[i];
        }
        total = temp;
    }
}