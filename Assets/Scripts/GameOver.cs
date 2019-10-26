using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    [SerializeField] Text TextGameOver;
    [SerializeField] Button ButtonGameOver;

    public void StartGame(){
        SceneManager.LoadScene("Intro");
    }

    void Start () {
        TextGameOver.text = "YOU LOSE. START ALL AGAIN!";
        ButtonGameOver.GetComponentInChildren<Text>().text = "Main Menu";
        ButtonGameOver.onClick.AddListener(delegate { StartGame(); });
    }
	
	// Update is called once per frame
	void Update () {
	}
}