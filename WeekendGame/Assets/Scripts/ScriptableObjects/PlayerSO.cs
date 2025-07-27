using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [SerializeField]private float _maxPlayerHealth;
    
    public string MoveOneName;
    public string MoveTwoName;
    public string MoveThreeName;
    public string MoveFourName;

    public float GetMaxHealth()
    {
        return _maxPlayerHealth;
    }
}
