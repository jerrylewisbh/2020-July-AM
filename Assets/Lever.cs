using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] 
    private HingeJoint joint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Debug.Log(LeverAngle());
    }

    public float LeverAngle()
    {
        return joint.angle / joint.limits.max;
    }


}
