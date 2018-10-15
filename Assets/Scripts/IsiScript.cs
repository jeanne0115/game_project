using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsiScript : MonoBehaviour {

    public GameObject Light;
    bool one = false;
    Vector3 pos;
    float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
        if(time >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (one == false)
        {
            pos = GetComponent<Transform>().position;
            pos.z = -1;
            Instantiate(Light, pos, Quaternion.identity);
            one = true;
        }
    }
}
