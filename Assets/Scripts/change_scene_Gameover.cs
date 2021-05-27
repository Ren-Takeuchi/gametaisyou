using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene_Gameover : MonoBehaviour
{
    public GameObject chara;
    public GameObject gameclear;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == chara.name)
        {
            SceneManager.LoadScene("gameover");
        }
    }

}
