using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] GameObject focusCamera;
    bool focusing = false;

    // void Update()
    // {
    //     if(focusing && Input.GetKeyUp(KeyCode.F))
    //     {
    //         Debug.Log("unfocusing");
    //         playerCamera.SetActive(true);
    //         focusCamera.SetActive(false);
    //         focusing = false;
    //     }
    // }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("staing in trigger");

        if(Input.GetKeyUp(KeyCode.F))
        {
            Debug.Log("pressed F");
            
            if(!focusing)
            {
                Debug.Log("switching to focus cam");
                playerCamera.GetComponentInChildren<Camera>().enabled = false;
                // playerCamera.GetComponent<Camera>().enabled = false;
                focusCamera.GetComponent<Camera>().enabled = true;
                // playerCamera.SetActive(false);
                // focusCamera.SetActive(true);
                focusing = true;
            }
            else
            {
                Debug.Log("switching to player cam");
                playerCamera.GetComponentInChildren<Camera>().enabled = true;
                focusCamera.GetComponent<Camera>().enabled = false;
                focusing = false;
            }
        }
    }
}
