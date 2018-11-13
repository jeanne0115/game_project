using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContllorer : MonoBehaviour {

    float pulmin = 0.1f;
    public float max;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Light>().range += pulmin;
        if (this.gameObject.GetComponent<Light>().range >= max)
            pulmin = pulmin * -1;
        if (this.gameObject.GetComponent<Light>().range <= 0)
            Destroy(gameObject);

        
	}
}
