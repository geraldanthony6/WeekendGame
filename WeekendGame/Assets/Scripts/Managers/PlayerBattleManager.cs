using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleManager : MonoBehaviour
{
    [SerializeField] private PlayerSO _playerData;

    [SerializeField] private float _currentPlayerHealth;

    [SerializeField] private Slider _healthBar;

    [SerializeField] private GameObject _fightPanel;

    [SerializeField] private TextMeshProUGUI[] _moveTexts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BattleManager.Instance.m_StartPlayerTurn.AddListener(DoPlayerTurn);
        BattleManager.Instance.m_EndPlayerTurn.AddListener(EndPlayerTurn);
        
        LoadBasePlayerValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && BattleManager.Instance.GetCurrentTurnState() == TurnEnum.PlayerTurn)
        {
            BattleManager.Instance.m_EndPlayerTurn.Invoke();
        }
    }

    private void LoadBasePlayerValues()
    {
        _currentPlayerHealth = _playerData.GetMaxHealth();
        _healthBar.maxValue = _playerData.GetMaxHealth();
        _healthBar.value = _currentPlayerHealth;
    }

    private void LoadMoveText()
    {
        _moveTexts[0].text = _playerData.MoveOneName;
        _moveTexts[1].text = _playerData.MoveTwoName;
        _moveTexts[2].text = _playerData.MoveThreeName;
        _moveTexts[3].text = _playerData.MoveFourName;
    }

    private void UnloadMoveText()
    {
        foreach (TextMeshProUGUI text in _moveTexts)
        {
            text.text = null;
        }
    }

    private void DealDamageToEnemy(float DamageToDo)
    {
        BattleManager.Instance.GetEnemy().TakeDamage(DamageToDo);
    }
    
    public void HealPlayer(float AmountToHeal)
    {
        _currentPlayerHealth += AmountToHeal;
        _healthBar.value = _currentPlayerHealth;
    }

    public void TakeDamage(float DamageToTake)
    {
        _currentPlayerHealth -= DamageToTake;
        _healthBar.value = _currentPlayerHealth;
    }

    public void ToggleFightPanel(bool ToggleValue)
    {
        if (ToggleValue)
        {
            _fightPanel.SetActive(true);
            LoadMoveText();
        }
        else
        {
            _fightPanel.SetActive(false);
            UnloadMoveText();
        }
    }

    public void DoPlayerTurn()
    {
        Debug.Log("Do Player Turn");
    }

    public void EndPlayerTurn()
    {
        Debug.Log("End Player Turn");
    }

    public void DoMove(int MoveNumberToDo)
    {
        if (BattleManager.Instance.GetCurrentTurnState() == TurnEnum.PlayerTurn)
        {
            switch (MoveNumberToDo)
            {
                case 1:
                    DealDamageToEnemy(10.0f);
                    BattleManager.Instance.m_EndPlayerTurn.Invoke();
                break;
                case 2:
                    DealDamageToEnemy(5.0f);
                    BattleManager.Instance.m_EndPlayerTurn.Invoke();
                break;    
                case 3:
                    HealPlayer(5.0f);
                    BattleManager.Instance.m_EndPlayerTurn.Invoke();
                break;    
                case 4:
                    HealPlayer(10.0f);
                    BattleManager.Instance.m_EndPlayerTurn.Invoke();
                break;        
                default:
                    break;
            }
        }
    }
}
