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

    Vector3 player_pos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        front_fream++;
        back_fream++;
        if (front_fream >= 300.0f && !change_check_front)
        {
            front_fream = 0.0f;
            change_check_front = true;
            player_pos = front_gameObject.transform.position;
        }
        if (back_fream >= 300.0f && !change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = true;
            back_gameObject.transform.position = new Vector3(player_pos.x, player_pos.y, player_pos.z);
        }
        if (back_fream >= 300.0f && change_check_back)
        {
            back_fream = 0.0f;
            change_check_back = false;
            player_pos = back_gameObject.transform.position;
        }
        if (front_fream >= 300.0f && change_check_front)
        {
            front_fream = 0.0f;
            change_check_front = false;
            front_gameObject.transform.position = new Vector3(player_pos.x, player_pos.y, player_pos.z);
        }

    }

    void OnGUI()
    {
        if (change_check_front)
        {// 前の画像が消える
            front_gameObject.SetActive(false);
        }
        if (change_check_back)
        {// 後ろの画像が描画
            back_gameObject.SetActive(true);
        }
        if (!change_check_back)
        {// 後ろの画像が消える
            back_gameObject.SetActive(false);
        }
        if (!change_check_front)
        {// 前の画像が描画される
            front_gameObject.SetActive(true);
        }

    }
}

