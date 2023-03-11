using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathDoor : MonoBehaviour
{
    private bool doorOpen = false;
    [SerializeField] public bool bonnePorte = false;
    public GameObject door;
    public AudioSource audioSource;
    //public audio Buzzer;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            Destroy(door);
            Debug.Log("porte ouverte");
        }
    }





    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (bonnePorte)
            {
                doorOpen = true;
            }
            else
            {
                audioSource.Play();
            }
            

        }
    }
}
