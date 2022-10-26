using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] Camera focusCamera;

    void OnTriggerStay(Collider other)
    {
        Debug.Log("do something");
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(playerCamera.enabled)
            {
                playerCamera.enabled = false;
                focusCamera.enabled = true;
            }
            else
            {
                playerCamera.enabled = true;
                focusCamera.enabled = false;
            }
        }
    }
}
