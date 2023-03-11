using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGate : MonoBehaviour
{
    [SerializeField] private Score scorePlayer;
    [SerializeField] private uint scoreToUnlock;
    [SerializeField] private uint level;

    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    private void Update()
    {
        if (level > 0)
        {
            if (scorePlayer.levels[level - 1] < 3)
            {
                gameObject.SetActive(false);
            }
        }

        if (scorePlayer.levels[level] == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        if (scorePlayer.levels[level] >= 1)
        {
            star1.SetActive(true);
        }
        if (scorePlayer.levels[level] >= 2)
        {
            star2.SetActive(true);
        }
        if (scorePlayer.levels[level] >= 3)
        {
            star3.SetActive(true);
        }
    }
}