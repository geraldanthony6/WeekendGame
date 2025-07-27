using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    [SerializeField]private float _maxEnemyHealth;

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
