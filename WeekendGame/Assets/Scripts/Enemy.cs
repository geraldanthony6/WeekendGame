using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySO _enemyData;

    [SerializeField] private float _currentEnemyHealth;

    [SerializeField] private Slider _enemyHealthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BattleManager.Instance.SetEnemy(this);
        
        LoadBaseEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadBaseEnemyValues()
    {
        _currentEnemyHealth = _enemyData.GetMaxEnemyHealth();
        _enemyHealthBar.maxValue = _enemyData.GetMaxEnemyHealth();
        _enemyHealthBar.value = _currentEnemyHealth;
    }

    public EnemySO GetEnemyData()
    {
        return _enemyData;
    }

    public void TakeDamage(float DamageToTake)
    {
        if (_currentEnemyHealth > 0.0f)
        {
            _currentEnemyHealth -= DamageToTake  - (10.0f * (_enemyData.GetDefense()/50.0f));
            _enemyHealthBar.value = _currentEnemyHealth;
        } else if (_currentEnemyHealth <= 0.0f)
        {
            BattleManager.Instance.m_EnemyDefeatedEnding.Invoke();
        }
    }

    public void HealEnemy(float AmountToHeal)
    {
        _currentEnemyHealth += AmountToHeal;
        _enemyHealthBar.value = _currentEnemyHealth;
    }
}
