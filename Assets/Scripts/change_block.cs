using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_block : MonoBehaviour
{
    // Start is called before the first frame update

    private float front_fream = 0.0f;

    private bool change_check_front = false;

    public GameObject front_gameObject;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        front_fream++;
       
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

    }

    void OnGUI()
    {
        if (change_check_front)
        {// 前の画像が消える
            front_gameObject.SetActive(false);
        }
        if (!change_check_front)
        {// 前の画像が描画される
            front_gameObject.SetActive(true);
        }

    }
}
