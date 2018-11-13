using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour {

    public GameObject PoiLight;
    Vector3 instPos;
    float time;

	// Use this for initialization
	void Start () {
        instPos = GetComponent<Transform>().position;
        instPos.z = -2;
        Instantiate(PoiLight, instPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time >= 3)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Ground")
        {
            instPos = GetComponent<Transform>().position;
            instPos.z = -2;
            Instantiate(PoiLight, instPos, Quaternion.identity);
        }
        
    }
}
