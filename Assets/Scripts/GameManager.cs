using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public enum GameState
    {
        Play,
        Pause,
        GameOver
    }

    private int score;
    public float Score
    {
        get { return score; }
    }
    private int bestScore;

    private float currentTime = 0;
    public float CurrentTime
    {
        get { return currentTime; }
    }
    private float startTime = 0;

    private float startPosY;

    [SerializeField]
    private GameObject  playerPrefab;
    private GameObject playerObj;
    public GameObject PlayerObj
    {
        get
        {
            return playerObj;
        }
    }

    [SerializeField]
    private GameObject startPoint;

    public delegate void StateDelegate();
    public event StateDelegate OnPlay;
    public event StateDelegate OnPause;
    public event StateDelegate OnGameOver;

    private GameState state = GameState.Pause;
    public GameState State
    {
        get { return state; }
        set
        {
            if (state == value)
                return;
            state = value;
            switch (state)
            {
                case GameState.Play:
                    Time.timeScale = 1;
                    if (OnPlay != null)
                        OnPlay();
                    return;
                case GameState.Pause:
                    Time.timeScale = 0;
                    if (OnPause != null)
                        OnPause();
                    return;
                case GameState.GameOver:
                    if (OnGameOver != null)
                        OnGameOver();
                    return;
                default:
                    return;
            }
        }
    }

    private void Awake()
    {
        playerObj = Instantiate(playerPrefab, startPoint.transform.position, startPoint.transform.rotation);
    }

    // Use this for initialization
    void Start ()
    {
        score = 0;
        startTime = Time.time;
        startPosY = startPoint.transform.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = Time.time - startTime;
        score = Mathf.Max((int) (startPosY - playerObj.transform.position.y), score);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
            Pause();
        else
            Play();
    }

    public void Pause ()
    {
        state = GameState.Pause;
    }

    public void Play()
    {
        state = GameState.Play;
    }
}
