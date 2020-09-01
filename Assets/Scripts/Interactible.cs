using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Base Interact Called");
    }
}
