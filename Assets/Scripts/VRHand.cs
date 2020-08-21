using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Handness
{
    Right,
    Left
}

public class VRHand : MonoBehaviour
{
    public Handness handness;
    private string gripButtonName;

    private Animator animator;

    public void Awake()
    {
        if (handness == Handness.Right)
        {
            gripButtonName = "RightGrip";
        }
        else
        {
            gripButtonName = "LeftGrip";
        }

        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        float gripValue = Input.GetAxis(gripButtonName);
        
      // animator.SetBool("gripPressed", true);
    }
}
