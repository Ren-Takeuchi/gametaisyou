using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_player : MonoBehaviour
{
    // Start is called before the first frame update

    private float front_fream = 0.0f;

    private float back_fream = 0.0f;

    private bool change_check_front = false;
    private bool change_check_back = false;

    public GameObject front_gameObject;
    public GameObject back_gameObject;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        front_fream++;
        back_fream++;
        if (front_fream >= 120.0f && !change_check_front)
        {
            front_fream = 0.0f;
            change_check_front = true;
        }
        if (front_fream >= 120.0f && change_check_front)
        {
            front_fream = 0.0f;
            change_check_front = false;
        }
        if (back_fream >= 120.0f && !change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = true;
        }
        if (back_fream >= 120.0f && change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = false;
        }
    }

    void OnGUI()
    {
        if (change_check_front)
        {
            front_gameObject.SetActive(false);
        }
        if (!change_check_front)
        {
            front_gameObject.SetActive(true);
        }
        if (change_check_back)
        {
            back_gameObject.SetActive(true);
        }
        if (!change_check_back)
        {
            back_gameObject.SetActive(false);
        }
    }
}

