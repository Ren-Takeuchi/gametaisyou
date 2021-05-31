using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown("End"))
        {
            Application.Quit();
        }
    }
}