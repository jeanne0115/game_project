using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour {

    Animator anim;
    Vector3 scale;
    Vector3 mousepos;
    Rigidbody2D rb2d;
    Vector3 handPos;
    Transform playerTr;
    public GameObject Hand;
    public GameObject Pre_isi;
    public GameObject Manager;
    GameObject instIsi;

    bool idou = false;
    bool oneJump;
    float scroll = 10f;
    float direction = 0f;
    float timeCount;
    float ido = 0;
    float idoo = 0;
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



        if (Input.GetMouseButtonDown(0) && oneJump == false)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            anim.SetTrigger("is_jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, 7);
            oneJump = true;
        }

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
                Manager.GetComponent<GameManager4>().Die();
            }
        }
        


        anim.SetBool("is_running", false);
        
        // デフォルトが右向きの画像の場合
        // スケール値取り出し
        scale = transform.localScale;


        if (idou == true)
        {
            anim.SetBool("is_running", true);
            scale.x = ido;
            transform.localScale = scale;
            direction = idoo;
        }
        else
        {
            anim.SetBool("is_running", false);
            direction = 0f;
            timeCount = 0;
        }
        rb2d.velocity = new Vector2(scroll * direction, rb2d.velocity.y);

        
    }

    public void PushButtonRight()
    {
        idou = true;
        ido = 1;
        idoo = 0.5f;
    }

    public void PushButtonLeft()
    {
        idou = true;
        ido = -1;
        idoo = -0.5f;
    }

    public void UpButton()
    {
        idou = false;
        ido = 0;
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if(oneJump == true)
            {
                oneJump = false;
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
