using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score1;
    [SerializeField] private TextMeshProUGUI score2;

    public void Start()
    {
        ScoreManager.Instance.onScore1Change += OnScore1Change;
        ScoreManager.Instance.onScore2Change += OnScore2Change;
    }
    public void OnScore1Change()
    {
        score1.text = ScoreManager.Instance.score1.ToString();
    }

    public void OnScore2Change()
    {
        score2.text = ScoreManager.Instance.score2.ToString();
    }
}
