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

    public float speed = 3.0f;

    public GameObject player;

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

        float horizontalKey = Input.GetAxisRaw("Horizontal");

        //右入力で左向きに動く
        if (horizontalKey > 0)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //左入力で左向きに動く
        else if (horizontalKey < 0)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        //ボタンを話すと止まる
        else
        {
            rb2d.velocity = Vector2.zero;
        }

        //キャラのy軸のdirection方向にscrollの力をかける
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        //ジャンプ判定
        if (Input.GetKeyDown("space") && !jump || Input.GetButtonDown("Jump") && !jump)
        {
            rb2d.AddForce(Vector2.up * flap);
            jump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
    }
}

