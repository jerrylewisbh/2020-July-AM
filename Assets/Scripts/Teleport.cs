using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Teleport : MonoBehaviour
{


    [SerializeField] 
    private Color teleportableColor = Color.green;

    [SerializeField] 
    private Color notTeleportableColor = Color.red; 
    
    [SerializeField] 
    private float rayDistance = 100;

    [SerializeField] 
    private GameObject teleportObject;

    [SerializeField]
    private LayerMask layers;
    
    private LineRenderer line;


    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.blue);
        
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * rayDistance);
        

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layers))
        {
            //The ray is intersecting something 

            Debug.Log("Intersecting something");
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Teleportable"))
            {
                Debug.Log("Intersecting a teleportable");
                //Colliding with something teleportable

                line.material.color = teleportableColor;
                
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    float newHeight = hit.point.y + teleportObject.transform.position.y;
                    Vector3 newPos = new Vector3(hit.point.x,newHeight , hit.point.z);
                    teleportObject.transform.position = newPos;
                }
            }
        }
        else
        {
            line.material.color = notTeleportableColor;
        }
    }
}