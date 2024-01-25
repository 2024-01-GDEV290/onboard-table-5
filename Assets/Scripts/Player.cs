using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public GameObject projectile;
    public float delay;

    private Camera cam;
    private float timeSinceLastShot;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && (timeSinceLastShot > delay))
        {
            timeSinceLastShot = 0;
            GameObject newBlast = Instantiate(projectile);
            newBlast.transform.rotation = cam.transform.rotation;
            newBlast.transform.position = cam.transform.position;
            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
            blastRB.AddForce(cam.transform.forward * velocity);
        }
    }
}
