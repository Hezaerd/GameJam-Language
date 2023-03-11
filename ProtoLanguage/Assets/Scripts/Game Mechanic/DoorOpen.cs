using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public bool doorOpen = false;
    public GameObject door;

    void Start()
    {
        
        doorOpen = false;
    }

   
    void Update()
    {
        if (doorOpen)
        {
            Destroy(gameObject);
            Debug.Log("porte ouverte");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            doorOpen = true;
        }
    }

}
