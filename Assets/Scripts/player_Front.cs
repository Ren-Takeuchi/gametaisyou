﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_Front : MonoBehaviour
{

    //変数定義
    public float flap = 1000f;
    public float scroll = 5f;
    float direction = 0f;
    Rigidbody2D rb2d;
    bool jump = false;

    private GameObject GameObject;

    // Use this for initialization
    void Start()
    {
        //コンポーネント読み込み
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        //キーボード操作
        if (Input.GetKey(KeyCode.D))
        {
            direction = 3f;
            //右方向を向く
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction = -3f;
            //左方向を向く
            transform.localScale = new Vector3(1, 1, 1);

        }
        else
        {
            direction = 0f;
        }


        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown("space") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("clear");
        }

        if (collider.gameObject.tag == "gameover")
        {
            SceneManager.LoadScene("1-2");
        }

    }
}
