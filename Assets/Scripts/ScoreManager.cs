using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Goal goal1;
    [SerializeField] private Goal goal2;

    public int score1 = 0;
    public int score2 = 0;

    public delegate void CallbackDelegate();
    public CallbackDelegate onScore1Change;
    public CallbackDelegate onScore2Change;

    private static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ScoreManager instance is null. Ensure it is added to the scene.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        goal1.onBallEnter += AddPointPlayer1;
        goal2.onBallEnter += AddPointPlayer2;
    }

    private void AddPointPlayer1()
    {
        score1 += 1;
        onScore1Change.Invoke();
    }

    private void AddPointPlayer2()
    {
        score2 += 1;
        onScore2Change.Invoke();
    }
}
