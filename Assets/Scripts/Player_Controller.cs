using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    Animator anim;
    Vector3 scale;
    Vector3 mousepos;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

       
        anim.SetBool("is_running", false);
        
        // デフォルトが右向きの画像の場合
        // スケール値取り出し
        scale = transform.localScale;


        //仮でPC用操作
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            if ((mousepos.x <= 575 && mousepos.x >= 435) && (mousepos.y >= 186 && mousepos.y <= 435))
            {
                anim.SetTrigger("is_jump");
            }
        }
        if (Input.GetMouseButton(0))
        {
            mousepos = Input.mousePosition;
            //左に移動するときの処理
            if(mousepos.x <= 434)
            {
                anim.SetBool("is_running", true);
                scale.x = -1;
                transform.localScale = scale;

            }else if(mousepos.x >=576)//右に移動するときの処理
            {
                anim.SetBool("is_running", true);
                scale.x = 1;
                transform.localScale = scale;

            }
        }
        else
        {
            anim.SetBool("is_running", false);
            
        }

    }
}
