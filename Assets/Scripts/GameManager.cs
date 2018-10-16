using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject kuriaText;
    public GameObject SubCamera;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void PushButtonTouseki()
    {
        Player.GetComponent<Player_Controller>().Touseki();
    }

    public void Kuria()
    {
        SubCamera.SetActive(true);
        Destroy(Player);
        kuriaText.SetActive(true);
    }
}
