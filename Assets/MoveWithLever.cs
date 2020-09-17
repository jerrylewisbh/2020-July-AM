using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithLever : MonoBehaviour
{

    [SerializeField] 
    private Lever lever;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * 10 * lever.LeverAngle();
    }
}
