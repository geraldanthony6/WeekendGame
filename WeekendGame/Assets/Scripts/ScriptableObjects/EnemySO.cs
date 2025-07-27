using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField]private float _maxEnemyHealth;
    [SerializeField] private float _strength;
    [SerializeField] private float _defense;

    public string EnemyName;
    public string MoveOneName;
    public string MoveTwoName;
    public string MoveThreeName;
    public string MoveFourName;

    public float GetMaxEnemyHealth()
    {
        return _maxEnemyHealth;
    }
}
