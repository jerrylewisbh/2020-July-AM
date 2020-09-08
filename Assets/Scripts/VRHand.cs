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

    [SerializeField] [Tooltip("Determines if the hand moves with keyboard")]
    private bool isKeyboardEnabled = true;

    [SerializeField] 
    private float throwForce = 10;
    
    
    [SerializeField] private float handMovementSpeed = 1;
    private Animator animator;
    private GameObject touchedObject = null;
    private bool isGrabbing = false;

    private Vector3 previousPosition;
    private Vector3 previousRotation;


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
            KeyCode.UpArrow
        }

        if (Input.GetMouseButton(mouseButton))
        {
            animator.SetBool("gripPressed", true);

            if (!isGrabbing)
            {
                Grab();
            }
        }

        if (Input.GetMouseButtonUp(mouseButton))
        {
            animator.SetBool("gripPressed", false);
            Release();
        }

        float gripValue = Input.GetAxis(gripButtonName);
        Debug.Log("GRIP VALUE: " + gripValue);
        
        
        //animator.SetBool("gripPressed", true);
        
        previousPosition = transform.position;
        previousRotation = transform.rotation.eulerAngles;
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrabbing)
            {
                Interactible interactible = touchedObject.GetComponent<Interactible>();
                interactible.Interact();
            }
        }
        
        
    }


    private void Grab()
    {
        if (touchedObject != null)
        {
            touchedObject.transform.parent = transform;
            touchedObject.GetComponent<Rigidbody>().isKinematic = true;
            isGrabbing = true;
        }
    }

    private void Release()
    {
        if (isGrabbing)
        {
            touchedObject.GetComponent<Rigidbody>().isKinematic = false;
            touchedObject.transform.parent = null;
            isGrabbing = false;

            Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
            touchedObject.GetComponent<Rigidbody>().velocity = velocity * throwForce;
            
            Vector3 angularVelocity = (transform.rotation.eulerAngles - previousRotation) / Time.deltaTime;
            touchedObject.GetComponent<Rigidbody>().angularVelocity = angularVelocity * throwForce;

        }
    }


    private void OnCollisionEnter(Collision other)
    {
        Grabbable grabbable = other.gameObject.GetComponent<Grabbable>();
        if (grabbable != null && !isGrabbing)
        {
            touchedObject = other.gameObject;
            Debug.Log("touching: " + touchedObject.name);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (touchedObject != null && !isGrabbing)
        {
            if (other.gameObject == touchedObject)
            {
                touchedObject = null;
            }
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
            transform.Translate(Vector3.up * (Time.deltaTime * handMovementSpeed));
        }
        else if (Input.GetKey(KeyCode.R))
        {
            transform.Translate(Vector3.down * (Time.deltaTime * handMovementSpeed));
        }
    }
}