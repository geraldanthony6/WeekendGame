using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemEnum _itemEnum;

    [SerializeField] private GameObject EnemyToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRelatedEnemy()
    {
        SceneManager.LoadScene("BattleScene");
        GameManager.Instance.SetEnemyTypeToLoad(EnemyToSpawn);
    }
}
