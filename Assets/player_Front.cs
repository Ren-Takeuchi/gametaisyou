using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Front : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float x_val;
    private float y_val;
    private float speed;
    public float inputSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        x_val = Input.GetAxis("Horizontal");

        Vector3 worldPos = myTransform.position;
        myTransform.position = worldPos;  // ワールド座標での座標を設定

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb2d.velocity.y == 0)
            {
                rb2d.AddForce(transform.up * 300);
            }
        }
    }
    void FixedUpdate()
    {
        //待機
        if (x_val == 0)
        {
            speed = 0;
        }
        //右に移動
        else if (x_val > 0)
        {
            speed = inputSpeed;
            //右方向を向く
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //左に移動
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            //左方向を向く
            transform.localScale = new Vector3(1, 1, 1);
        }
        // キャラクターを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
}
