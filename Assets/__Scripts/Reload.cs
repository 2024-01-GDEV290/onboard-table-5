using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Reset"))
        {
            SceneManager.LoadScene("ForceFieldScene");
        }
    }
}
