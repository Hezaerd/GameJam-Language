using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTotalScore : MonoBehaviour
{
    [SerializeField] private Score scorePlayer;

    private void Update()
    {
        scorePlayer.UpdateScore();
        GetComponent<TextMeshProUGUI>().text = scorePlayer.total.ToString();
    }
}