using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactible
{
    public Transform spawnPoint;
    public GameObject bullet;

    public float power = 20;

    private void Shoot()
    {
        GameObject clone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        Rigidbody cloneRigidbody = clone.GetComponent<Rigidbody>();

        cloneRigidbody.AddForce(spawnPoint.forward * power, ForceMode.Force);
    }

    public override void Interact()
    {
        Shoot();
    }
}
