using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        bool a1 = GameObject.Find("PointA").GetComponent<ColliderA>().isTaggedA;
        bool b1 = GameObject.Find("PointB").GetComponent<ColliderB>().isTaggedB;

        GameObject lineXray1 = GameObject.Find("Line135_xray");
        GameObject lineHip1 = GameObject.Find("Line135_hip");

        Renderer lineXrayRenderer1 = lineXray1.GetComponent<Renderer>();
        Renderer lineHipRenderer1 = lineHip1.GetComponent<Renderer>();

        if(a1 == true && b1 == true)
        {
            lineXrayRenderer1.material.SetColor("_Color", Color.green);
            lineHipRenderer1.material.SetColor("_Color", Color.green);
        }
        else if(a1== true && b1 == false)
        {
            lineXrayRenderer1.material.SetColor("_Color", Color.blue);
            lineHipRenderer1.material.SetColor("_Color", Color.blue);
        }
        else if(a1 == false && b1 == true)
        {
            lineXrayRenderer1.material.SetColor("_Color", Color.blue);
            lineHipRenderer1.material.SetColor("_Color", Color.blue);
        }
        else
        {
            lineXrayRenderer1.material.SetColor("_Color", Color.yellow);
            lineHipRenderer1.material.SetColor("_Color", Color.yellow);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        bool a2 = GameObject.Find("PointA").GetComponent<ColliderA>().isTaggedA;
        bool b2 = GameObject.Find("PointB").GetComponent<ColliderB>().isTaggedB;

        GameObject lineXray2 = GameObject.Find("Line135_xray");
        GameObject lineHip2 = GameObject.Find("Line135_hip");

        Renderer lineXrayRenderer2 = lineXray2.GetComponent<Renderer>();
        Renderer lineHipRenderer2 = lineHip2.GetComponent<Renderer>();

        if(a2 == true && b2 == false)
        {
            lineXrayRenderer2.material.SetColor("_Color", Color.blue);
            lineHipRenderer2.material.SetColor("_Color", Color.blue);
        }
        else if(a2 == false && b2 == true)
        {
            lineXrayRenderer2.material.SetColor("_Color", Color.blue);
            lineHipRenderer2.material.SetColor("_Color", Color.blue);
        }
        else
        {
            lineXrayRenderer2.material.SetColor("_Color", Color.yellow);
            lineHipRenderer2.material.SetColor("_Color", Color.yellow);
        }
    }  
}
