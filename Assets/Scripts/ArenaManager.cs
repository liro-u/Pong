using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] public float topYPosition = 10f;
    [SerializeField] public float bottomYPosition = -10f;

    private static ArenaManager _instance;

    public static ArenaManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ArenaManager instance is null. Ensure it is added to the scene.");
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
}
