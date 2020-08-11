using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float power = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject clone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();

            cloneRigidbody.AddForce(spawnPoint.forward * power, ForceMode.Force);

        }
    }
}
