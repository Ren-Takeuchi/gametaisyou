using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_enemy : MonoBehaviour
{
    // Start is called before the first frame update


    private float back_fream = 0.0f;

    private bool change_check_back = false;

    public GameObject back_gameObject;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        back_fream++;

        if (back_fream >= 300.0f && !change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = true;
        }
        if (back_fream >= 300.0f && change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = false;
        }

    }

    void OnGUI()
    {
        if (change_check_back)
        {// 後ろの画像が描画
            back_gameObject.SetActive(true);
        }
        if (!change_check_back)
        {// 後ろの画像が消える
            back_gameObject.SetActive(false);
        }

    }
}
