using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefield : MonoBehaviour
{
    public float powerDownTime;
    public AudioClip powerDownSound;

    private AudioSource source;
    private Animator anim;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            Invoke("PwrDnSFX", powerDownTime - powerDownSound.length);
            Invoke("PowerDown", powerDownTime);
            anim.SetBool("hit", true);
        }
    }
    void PowerDown()
    {
        Destroy(this.gameObject);
    }

    private void PwrDnSFX()
    {
        source.PlayOneShot(powerDownSound);
    }
}
