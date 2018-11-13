using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asiba : MonoBehaviour {

    public float x;
    public float y;
    public float x_Max;
    public float y_Max;
    public float x_Min;
    public float y_Min;
    float timeCount;

    Vector3 instPos;

    public GameObject Light;
    public GameObject[] Light_pos;

	// Use this for initialization
	void Start () {
        //Debug.Log(transform.position.x);
        //Debug.Log(transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);

        if (transform.position.x >= x_Max || transform.position.x <= x_Min)
            x = x * -1;
        if (transform.position.y >= y_Max || transform.position.y <= y_Min)
            y = y * -1;

        timeCount += Time.deltaTime;
        if(timeCount >= 0.5)
        {
            Instantiating();
            timeCount = 0;
        }
        

	}

    private void Instantiating()
    {
        for (int a = 0; a < Light_pos.Length; a++)
        {
            instPos = Light_pos[a].GetComponent<Transform>().position;
            Instantiate(Light, instPos, Quaternion.identity);
        }

       
    }
}
