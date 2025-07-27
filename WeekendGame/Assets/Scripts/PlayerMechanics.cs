using TMPro;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    [SerializeField] private PlayerSO _playerData;
    
    [SerializeField] private GameObject _statPanel;

    [SerializeField] private TextMeshProUGUI _availablePointsText;

    [SerializeField] private TextMeshProUGUI _strengthPointsText;
    [SerializeField] private TextMeshProUGUI _defensePointsText;
    [SerializeField] private TextMeshProUGUI _luckPointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ToggleStatChangePanel(bool ToggleValue)
    {
        if (ToggleValue)
        {
            _statPanel.SetActive(true);
            _availablePointsText.text = _playerData.GetAvailableUpgradePoints().ToString();
        }
        else
        {
            _statPanel.SetActive(false);
        }
    }

    public void AddStrength(float ValueToAdd)
    {
        if (_playerData.GetAvailableUpgradePoints() >= 0.0f && _playerData.GetAvailableUpgradePoints() - ValueToAdd >= 0.0f && _playerData.GetStrength() + ValueToAdd >= 0.0f)
        {
            _playerData.AddStrengthPoints(ValueToAdd);
            _playerData.AddAvailableUpgradePoints(-ValueToAdd);
            _strengthPointsText.text = _playerData.GetStrength().ToString();
            _availablePointsText.text = _playerData.GetAvailableUpgradePoints().ToString();
        }
    }
    
    public void AddDefense(float ValueToAdd)
    {
        if (_playerData.GetAvailableUpgradePoints() >= 0.0f && _playerData.GetAvailableUpgradePoints() - ValueToAdd >= 0.0f && _playerData.GetDefense() + ValueToAdd >= 0.0f)
        {
            _playerData.AddDefensePoints(ValueToAdd);
            _playerData.AddAvailableUpgradePoints(-ValueToAdd);
            _defensePointsText.text = _playerData.GetDefense().ToString();
            _availablePointsText.text = _playerData.GetAvailableUpgradePoints().ToString();
        }
    }
    
    public void AddLuck(float ValueToAdd)
    {
        if (_playerData.GetAvailableUpgradePoints() >= 0.0f && _playerData.GetAvailableUpgradePoints() - ValueToAdd >= 0.0f && _playerData.GetLuck() + ValueToAdd >= 0.0f)
        {
            _playerData.AddLuckPoints(ValueToAdd);
            _playerData.AddAvailableUpgradePoints(-ValueToAdd);
            _luckPointsText.text = _playerData.GetLuck().ToString();
            _availablePointsText.text = _playerData.GetAvailableUpgradePoints().ToString();
        }
    }

    public void ResetStats()
    {
        _playerData.ResetAllStats();
        _availablePointsText.text = _playerData.GetAvailableUpgradePoints().ToString();
        _strengthPointsText.text = _playerData.GetStrength().ToString();
        _defensePointsText.text = _playerData.GetDefense().ToString();
        _luckPointsText.text = _playerData.GetLuck().ToString();
    }
}
