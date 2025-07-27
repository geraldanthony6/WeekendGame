using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private GameObject EnemyTypeToLoad;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEnemyToLoad()
    {
        return EnemyTypeToLoad;
    }

    public void SetEnemyTypeToLoad(GameObject NewEnemy)
    {
        EnemyTypeToLoad = NewEnemy;
    }
}
