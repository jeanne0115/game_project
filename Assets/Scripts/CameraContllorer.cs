using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContllorer : MonoBehaviour {

    public GameObject Player;
    Vector3 PlayerPos;
    Vector3 CameraPos;

    public float UpCamera;
    public float DownCamera;
    public float RightCamera;
    public float LeftCamera;
    public float kariCamera;

	// Use this for initialization
	void Start () {

        CameraPos = this.GetComponent<Transform>().position;
        UpCamera = CameraPos.y + 5;
        DownCamera = CameraPos.y - 5;
        RightCamera = CameraPos.x + 9;
        LeftCamera = CameraPos.x - 9;

    }
	
	// Update is called once per frame
	void Update () {
        if(Player != null)
            PlayerPos = Player.GetComponent<Transform>().position;
        CameraPos = this.GetComponent<Transform>().position;


        if(PlayerPos.x >= RightCamera)//右移動する処理
        {
            
            this.transform.position += new Vector3(18, 0, 0);
            LeftCamera = RightCamera;
            RightCamera = RightCamera + 18;
        }

        if (PlayerPos.x <= LeftCamera)//左移動する処理
        {
            
            this.transform.position += new Vector3(-18, 0, 0);
            RightCamera = LeftCamera;
            LeftCamera = LeftCamera - 18;
        }

        if (PlayerPos.y >= UpCamera)//上移動する処理
        {
            
            this.transform.position += new Vector3(0, 10, 0);
            DownCamera = UpCamera;
            UpCamera = UpCamera + 10;
        }

        if (PlayerPos.y <= DownCamera)//下移動する処理
        {
            this.transform.position += new Vector3(0, -10, 0);
            UpCamera = DownCamera;
            DownCamera = DownCamera - 10;
        }
    }
}
