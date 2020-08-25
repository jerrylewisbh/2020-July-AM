using System;
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
    private int mouseButton;

    [SerializeField]
    [Tooltip("Determines if the hand moves with keyboard")]
    private bool isKeyboardEnabled = true;

    [SerializeField] 
    private float handMovementSpeed = 1;
    
    
    private Animator animator;

    public void Awake()
    {
        if (handness == Handness.Right)
        {
            gripButtonName = "RightGrip";
            mouseButton = 1;
        }
        else
        {
            gripButtonName = "LeftGrip";
            mouseButton = 0;
        }

        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (isKeyboardEnabled)
        {
            MoveHands();
        }

        if (Input.GetMouseButton(mouseButton))
        {
            animator.SetBool("gripPressed", true);
        }

        if (Input.GetMouseButtonUp(mouseButton))
        {
            animator.SetBool("gripPressed", false);
        }
        
        float gripValue = Input.GetAxis(gripButtonName);
        //animator.SetBool("gripPressed", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        Grabbable grabbable = other.gameObject.GetComponent<Grabbable>();
        if (grabbable != null)
        {
            
        }
    }


    private void MoveHands()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * handMovementSpeed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (Time.deltaTime * handMovementSpeed));
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * handMovementSpeed));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * handMovementSpeed));
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * (Time.deltaTime * handMovementSpeed) );
        }
        else if (Input.GetKey(KeyCode.R))
        {
            transform.Translate(Vector3.down * (Time.deltaTime * handMovementSpeed));
        }
    }
    
}
