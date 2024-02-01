using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcherRotate : MonoBehaviour
{
    public int rotationRate;
    private Vector3 newRotation;

    private void Awake()
    {
        newRotation = new Vector3(0, rotationRate, 0);
    }

    private void FixedUpdate()
    {
        transform.Rotate(newRotation * Time.deltaTime);
    }
}
