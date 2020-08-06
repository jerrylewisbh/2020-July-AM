using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public float MoveSpeed = 25;
    public CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Start Was Called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update was called");
    }
}
