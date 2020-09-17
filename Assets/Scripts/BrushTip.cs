using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushTip : MonoBehaviour
{
    public Material selectedMaterial;
    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponent<TrailRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paint"))
        {
            selectedMaterial = other.GetComponent<MeshRenderer>().material;
            GetComponent<MeshRenderer>().material = selectedMaterial;
            trail.material = selectedMaterial;
        }
    }
    
}
