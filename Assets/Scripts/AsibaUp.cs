using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsibaUp : MonoBehaviour {

    public float x;
    public float y;
    public float x_Max;
    public float y_Max;
    public float x_Min;
    public float y_Min;
    float outTime;
    public float plsTime;

    public GameObject Atama;

    bool onPlayer;
    bool timePlayer;

    // Use this for initialization
    void Start () {
        outTime = 5;
        onPlayer = false;
        timePlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(onPlayer == true)
        {
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            
            if (transform.position.y >= y_Max || transform.position.y <= y_Min)
            {
                onPlayer = false;
                y = y * -1;
                Atama.SetActive(false);
            }
        }
        else
        {
            plsTime += Time.deltaTime;
            if (plsTime >= outTime)
                timePlayer = true;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && (timePlayer == true))
        {
            onPlayer = true;
            Atama.SetActive(true);
            plsTime = 0;
            timePlayer = false;
        }
    }
}
