using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderA : MonoBehaviour
{
    public bool isTaggedA = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name=="Jig")
        {
            Debug.Log("Collision A:");
            isTaggedA = true; 
        }  
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name=="Jig")
        {
            Debug.Log("Exit A:");
            isTaggedA = false;  
        }
    }
}
