using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject Player;
    public GameObject kuriaText;
    public GameObject SubCamera;
    public GameObject TitleButton;
    public GameObject RetryButton;
    public GameObject IsiButton;

    public bool endFlg = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (endFlg == true)
                SceneManager.LoadScene(0);
        }
	}
    

    public void PushButtonTouseki()
    {
        Player.GetComponent<Player_Controller>().Touseki();
    }

    public void Kuria()
    {
        endFlg = true;
        SubCamera.SetActive(true);
        Destroy(Player);
        kuriaText.SetActive(true);
        IsiButton.SetActive(false);
    }

    public void Rakka()
    {
        SubCamera.SetActive(true);
        Destroy(Player);
        IsiButton.SetActive(false);
        RetryButton.SetActive(true);
        TitleButton.SetActive(true);

    }
}
