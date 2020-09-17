using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//create a custom event which receives a float parameter
[System.Serializable]
public class TimedEvent : UnityEvent<float>
{
}

public class PushButton : MonoBehaviour
{

    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;
    public bool isPressed = false;

    private Animator animator;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        VRHand hand = other.GetComponent<VRHand>();

        if (hand != null)
        {
            animator.SetBool("isPressed", true);

            if (OnButtonPressed != null)
            {
                OnButtonPressed.Invoke();
            }
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        VRHand hand = other.GetComponent<VRHand>();

        if (hand != null)
        {
            animator.SetBool("isPressed", false);

            if (OnButtonReleased != null)
            {
               OnButtonReleased.Invoke();
            }
        }
    }
    
}
