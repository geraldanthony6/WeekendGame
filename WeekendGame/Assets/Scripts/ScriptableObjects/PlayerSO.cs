using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Scriptable Objects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    [SerializeField]private float _maxPlayerHealth;
    [SerializeField] private float _strength;
    [SerializeField] private float _defense;
    [SerializeField] private float _luck;
    [SerializeField] private float _availableUpgradePoints;
    
    public string MoveOneName;
    public string MoveTwoName;
    public string MoveThreeName;
    public string MoveFourName;

    public float GetMaxHealth()
    {
        return _maxPlayerHealth;
    }

    public float GetStrength()
    {
        return _strength; 
    }

    public float GetDefense()
    {
        return _defense;
    }

    public float GetLuck()
    {
        return _luck;
    }

    public float GetAvailableUpgradePoints()
    {
        return _availableUpgradePoints;
    }
    
    public void AddStrengthPoints(float ValueToAdd)
    {
        _strength += ValueToAdd;
    }
    
    public void AddDefensePoints(float ValueToAdd)
    {
        _defense += ValueToAdd;
    }
    
    public void AddLuckPoints(float ValueToAdd)
    {
        _luck += ValueToAdd;
    }

    public void AddAvailableUpgradePoints(float ValueToAdd)
    {
        _availableUpgradePoints += ValueToAdd;
    }

    public void ResetAllStats()
    {
        _strength = 0;
        _defense = 0;
        _luck = 0;
        _availableUpgradePoints = 30;
    }
}
