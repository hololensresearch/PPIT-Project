using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderB : MonoBehaviour
{
    public bool isTaggedB = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Jig")
        {
            Debug.Log("Collision B:");
            isTaggedB = true;  
        }  
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name=="Jig")
        {
            Debug.Log("Exit B:");
            isTaggedB = false;  
        }
    }
}
