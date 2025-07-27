using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    
    [SerializeField] private Vector3 EnemySpawnPosition;

    [SerializeField] private TurnEnum CurrentTurnState;

    [SerializeField] private PlayerBattleManager _playerBattleManager;

    [SerializeField] private EnemyBattleManager _enemyBattleManager;

    [SerializeField] private Enemy _enemy;

    [SerializeField] private GameObject _actionPanel;

    [SerializeField] private TextMeshProUGUI _actionText;

    #region Events
    public UnityEvent m_StartPlayerTurn;
    public UnityEvent m_EndPlayerTurn;
    
    public UnityEvent m_StartEnemyTurn;
    public UnityEvent m_EndEnemyTurn; 
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_StartEnemyTurn ??= new UnityEvent();
        m_StartEnemyTurn ??= new UnityEvent();
        m_EndPlayerTurn ??= new UnityEvent();
        m_EndEnemyTurn ??= new UnityEvent();
        
        m_EndPlayerTurn.AddListener(SwitchToEnemyTurn);
        m_EndEnemyTurn.AddListener(SwitchToPlayerTurn);
        
        BattleSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BattleSetup()
    {
        Instantiate(GameManager.Instance.GetEnemyToLoad(), EnemySpawnPosition, Quaternion.identity);
        // Should do some sort of stat check here to see who gets first turn
        CurrentTurnState = TurnEnum.PlayerTurn;
        m_StartPlayerTurn.Invoke();
    }

    private void SwitchToEnemyTurn()
    {
        CurrentTurnState = TurnEnum.EnemyTurn;
        m_StartEnemyTurn.Invoke();
    }
    
    private void SwitchToPlayerTurn()
    {
        CurrentTurnState = TurnEnum.PlayerTurn;
        m_StartPlayerTurn.Invoke();
    }

    public TurnEnum GetCurrentTurnState()
    {
        return CurrentTurnState;
    }

    public PlayerBattleManager GetPlayerBattleManager()
    {
        return _playerBattleManager;
    }
    
    public void SetEnemyBattleManager(EnemyBattleManager newEnemyBattleManager)
    {
        _enemyBattleManager = newEnemyBattleManager;
    }

    public Enemy GetEnemy()
    {
        return _enemy;
    }

    public void SetEnemy(Enemy newEnemy)
    {
        _enemy = newEnemy;
    }

    public void ToggleActionPanel(string ActionUser, string MoveUsed, bool ToggleValue)
    {
        if (ToggleValue)
        {
            _actionPanel.SetActive(true);
            _actionText.text = ActionUser + " uses " + MoveUsed;
        }
        else
        {
            _actionPanel.SetActive(false);
        }
    }

    public void ExitBattle()
    {
        SceneManager.LoadScene("BaseRoomScene");
    }
}
