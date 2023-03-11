using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI appleCountUI;
    private int apples;
    public GameObject player;

    //player


    public bool playing;
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //appleCountUI.text = player.GetComponent<appleCount>.ToString();
        updateCount();
        appleCountUI.text = apples.ToString() + " / 5";

        if (playing == true)
        {

            Timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(Timer / 60F);
            int seconds = Mathf.FloorToInt(Timer % 60F);
            //int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");//+ ":" + milliseconds.ToString("00");
        }
    }

    public void updateCount()
    {
        apples = FindObjectOfType<Controller>().GetApples();
    }
}
