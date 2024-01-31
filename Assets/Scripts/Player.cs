using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public GameObject projectile;
    public float delay;
    public AudioClip shootSound;

    private Camera cam;
    private float timeSinceLastShot;
    private Animator animator;
    private AudioSource sound;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        animator = GetComponentInChildren<Animator>();
        sound = GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (animator.GetBool("Shot"))
        {
            animator.SetBool("Shot", false);
        }

        if (Input.GetButtonDown("Fire1") && (timeSinceLastShot > delay))
        {
            timeSinceLastShot = 0;
            GameObject newBlast = Instantiate(projectile);
            newBlast.transform.rotation = cam.transform.rotation;
            newBlast.transform.position = cam.transform.position;
            Rigidbody blastRB = newBlast.GetComponent<Rigidbody>();
            blastRB.AddForce(cam.transform.forward * velocity);
            animator.SetBool("Shot", true);
            sound.PlayOneShot(shootSound);
        }
    }
}
