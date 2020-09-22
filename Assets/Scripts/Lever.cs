using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Lever : MonoBehaviour
{
    private HingeJoint leverJoint;
    private void Awake()
    {
        leverJoint = GetComponentInChildren<HingeJoint>();
    }

    private void Update()
    {
        Debug.Log("normalized angle: " + NormalizedJointAngle());
    }

    public float NormalizedJointAngle()
    {
        return leverJoint.angle / leverJoint.limits.max;
    }
}
