using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour {

    Animator anim;
    Vector3 scale;
    Vector3 mousepos;
    Rigidbody2D rb2d;
    Vector3 instPos;
    Vector3 handPos;
    Transform playerTr;
    public GameObject Instpos;
    public GameObject Light;
    public GameObject Hand;
    public GameObject Pre_isi;
    public GameObject Manager;
    GameObject instIsi;

    bool oneJump;
    bool one_Light = false;
    float scroll = 10f;
    float direction = 0f;
    float timeCount;
    int speed = 10;
    public int stage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        oneJump = false;
	}
	
	// Update is called once per frame
	void Update () {

        playerTr = gameObject.GetComponent<Transform>();
        if (playerTr.position.y <= -7)
        {
            if(stage == 1)
            {
                Manager.GetComponent<GameManager>().Die();
            }
            else if(stage == 2)
            {
                Manager.GetComponent<GameManager2>().Die();
            }
            else if(stage == 3)
            {
                Manager.GetComponent<GameManager3>().Die();
            }
            else if(stage == 4)
            {

            }
        }
        


        anim.SetBool("is_running", false);
        
        // デフォルトが右向きの画像の場合
        // スケール値取り出し
        scale = transform.localScale;


        //仮でPC用操作
        if (Input.GetMouseButtonDown(0))
        {
            
            mousepos = Input.mousePosition;
            if ((mousepos.x <= 695 && mousepos.x >= 565) && (mousepos.y >= 145 && mousepos.y <= 385) && (oneJump == false))
            {
                anim.SetTrigger("is_jump");
                rb2d.velocity = new Vector2(rb2d.velocity.x, 7);
                Instantiating();
                oneJump = true;
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            
            if(one_Light == false)
            {
                Instantiating();
                one_Light = true;
            }
            mousepos = Input.mousePosition;
            Debug.Log(mousepos.x);
            Debug.Log(mousepos.y);

            timeCount += Time.deltaTime;
            if(timeCount >= 0.1 && !(mousepos.x >= 1025 && mousepos.y <= 243))
            {
                Instantiating();
                timeCount = 0;
            }
            mousepos = Input.mousePosition;
            //左に移動するときの処理
            if(mousepos.x <= 564)
            {
                anim.SetBool("is_running", true);
                scale.x = -1;
                transform.localScale = scale;
                direction = -0.5f;

            }else if(mousepos.x >=696 && !(mousepos.x >= 1025 && mousepos.y <= 243))//右に移動するときの処理
            {
                    
                anim.SetBool("is_running", true);
                scale.x = 1;
                transform.localScale = scale;
                direction = 0.5f;
            }
        }
        else
        {
            anim.SetBool("is_running", false);
            direction = 0f;
            timeCount = 0;
            one_Light = false;
        }
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if(oneJump == true)
            {
                oneJump = false;
                Instantiating();
            }
        }

        //クリア時の処理
        if(collision.gameObject.tag == "kuria")
        {
            if (stage == 1)
            {
                Manager.GetComponent<GameManager>().Kuria();
            }
            else if (stage == 2)
            {
                Manager.GetComponent<GameManager2>().Kuria();
            }
            else if (stage == 3)
            {
                Manager.GetComponent<GameManager3>().Kuria();
            }
            else if (stage == 4)
            {

            }
        }

        //罠などで死ぬ場合の処理
        if(collision.gameObject.tag == "Die")
        {
            if (stage == 1)
            {
                Manager.GetComponent<GameManager>().Die();
            }
            else if (stage == 2)
            {
                Manager.GetComponent<GameManager2>().Die();
            }
            else if (stage == 3)
            {
                Manager.GetComponent<GameManager3>().Die();
            }
            else if (stage == 4)
            {

            }
        }
    }

    private void Instantiating()
    {
        if(oneJump == false)
        {
            instPos = Instpos.GetComponent<Transform>().position;
            Instantiate(Light, instPos, Quaternion.identity);
        }
    }

    public void Touseki()
    {
        anim.SetTrigger("is_touseki");
        handPos = Hand.GetComponent<Transform>().position;
        instIsi = Instantiate(Pre_isi, handPos, Quaternion.identity);
        if(scale.x == -1)
        {
            speed = -10;
        }
        else
        {
            speed = 10;
        }
        instIsi.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
}
