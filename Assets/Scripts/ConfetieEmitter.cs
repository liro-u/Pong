using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfetieEmitter : MonoBehaviour
{
    public enum GoalEnum
    {
        Goal1,
        Goal2,
    }

    [SerializeField] private GoalEnum goalSelected = GoalEnum.Goal1;
    public void Start()
    {
        if (goalSelected == GoalEnum.Goal1)
        {
            ScoreManager.Instance.onScore1Change += OnGoal;
        }
        else
        {
            ScoreManager.Instance.onScore2Change += OnGoal;
        }
    }
    public void OnGoal()
    {
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Play();
    }
}
