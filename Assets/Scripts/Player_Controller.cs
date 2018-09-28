using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    Animator anim;
    Vector3 scale;
    Vector3 mousepos;
    bool jumpFlg;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        jumpFlg = false;
	}
	
	// Update is called once per frame
	void Update () {

       
        anim.SetBool("is_running", false);

        //float x = Input.GetAxisRaw("Horizontal");
        // デフォルトが右向きの画像の場合
        // スケール値取り出し
        scale = transform.localScale;


        //仮でPC用操作
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            if ((mousepos.x <= 575 && mousepos.x >= 435) && (mousepos.y >= 186 && mousepos.y <= 435) && (jumpFlg == false))
            {
                anim.SetBool("is_jump", true);
            }
        }
        if (Input.GetMouseButton(0))
        {
            mousepos = Input.mousePosition;
            //左に移動するときの処理
            if(mousepos.x <= 510)
            {
                anim.SetBool("is_running", true);
                scale.x = -1;
                transform.localScale = scale;

            }else if(mousepos.x >=511)//右に移動するときの処理
            {
                anim.SetBool("is_running", true);
                scale.x = 1;
                transform.localScale = scale;

            }
        }
        else
        {
            anim.SetBool("is_running", false);
            anim.SetBool("is_jump", false);
        }

    }
}
