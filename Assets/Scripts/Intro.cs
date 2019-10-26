using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    [SerializeField] Text TextIntro;
    [SerializeField] Button ButtonStart;

    public void StartGame(){
        SceneManager.LoadScene("Main Game");
    }

    void Start () {
        TextIntro.text = "555";
        ButtonStart.GetComponentInChildren<Text>().text = "Start Game";
        ButtonStart.onClick.AddListener(delegate { StartGame(); });
    }
	
	// Update is called once per frame
	void Update () {
	}
}