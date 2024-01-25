using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcefield : MonoBehaviour
{
    public float powerDownTime;
    public AudioClip powerDownSound;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            source.PlayOneShot(powerDownSound);
            Invoke("PowerDown", powerDownTime);
        }
    }

    void PowerDown()
    {
        Destroy(this.gameObject);
    }
}
