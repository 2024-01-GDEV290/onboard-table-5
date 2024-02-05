using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public GameObject projectile;
    public float delay;
    public AudioClip shootSound;
    public AudioClip footstep;
    public AudioClip footstep2;
    public AudioClip jump;
    public GameObject flash;

    private Camera cam;
    private float timeSinceLastShot;
    private Animator animator;
    private AudioSource sound;
    private float stepTaken;

    private void Awake()
    {
        Cursor.visible = false;
        cam = GetComponentInChildren<Camera>();
        animator = GetComponentInChildren<Animator>();
        sound = GetComponentInChildren<AudioSource>();
    }
    
    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        stepTaken += Time.deltaTime;

        if (Input.GetAxis("Horizontal") != 0 && stepTaken >= 0.5 || Input.GetAxis("Vertical") != 0 && stepTaken >= 0.5)
        {
            stepTaken = 0;
            sound.PlayOneShot(footstep);

            if (stepTaken >= 0.25) 
            {
                stepTaken = 0;
                sound.PlayOneShot(footstep2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sound.PlayOneShot(jump);
        }

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
            flash.SetActive(true);
            Invoke("EndFlash", 0.1f);
        }
    }

    private void EndFlash()
    {
        flash.SetActive(false);
    }
}
