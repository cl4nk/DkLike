using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour {

    private Text timeLabel;
    private Text scoreLabel;

    public GameObject menuObject;
    public GameObject gameOverObject;

    // Use this for initialization
    void Start () {
        GameManager.Instance.OnPlay += () =>
        {
            menuObject.SetActive(false);
            gameOverObject.SetActive(false);
        };

        GameManager.Instance.OnPause += () =>
        {
            menuObject.SetActive(true);
            gameOverObject.SetActive(false);
        };

        GameManager.Instance.OnGameOver += () =>
        {
            menuObject.SetActive(false);
            gameOverObject.SetActive(true);
        };
    }
	
	// Update is called once per frame
	void Update () {
        timeLabel.text = GameManager.Instance.CurrentTime.ToString("0:00");
        scoreLabel.text = GameManager.Instance.Score.ToString();
    }
}
