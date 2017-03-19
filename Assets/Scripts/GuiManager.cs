using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour {

    [SerializeField]
    private Text timeLabel;
    [SerializeField]
    private Text scoreLabel;

    [SerializeField]
    private GameObject hudObject;
    [SerializeField]
    private GameObject menuObject;
    [SerializeField]
    private GameObject gameOverObject;

    // Use this for initialization
    void Awake () {
        GameManager.Instance.OnPlay += () =>
        {
            hudObject.SetActive(true);
            menuObject.SetActive(false);
            gameOverObject.SetActive(false);
        };

        GameManager.Instance.OnPause += () =>
        {
            hudObject.SetActive(false);
            menuObject.SetActive(true);
            gameOverObject.SetActive(false);
        };

        GameManager.Instance.OnGameOver += () =>
        {
            hudObject.SetActive(false);
            menuObject.SetActive(false);
            gameOverObject.SetActive(true);
        };
    }
	
	// Update is called once per frame
	void Update () {
        timeLabel.text = "Time :" +  GameManager.Instance.CurrentTime.ToString("0.00");
        scoreLabel.text = "Score :" + GameManager.Instance.Score.ToString();
    }
}
