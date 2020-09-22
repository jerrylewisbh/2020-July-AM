using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLever : MonoBehaviour
{

    [SerializeField] 
    private Lever lever;

    [SerializeField] 
    private float moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        float leverValue = lever.NormalizedJointAngle();
        transform.Translate(transform.forward * (moveSpeed * leverValue * Time.deltaTime));
    }
}
