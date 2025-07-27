using System.Collections;
using UnityEngine;

public class EnemyBattleManager : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BattleManager.Instance.m_StartEnemyTurn.AddListener(DoEnemyTurn);
        BattleManager.Instance.m_EndEnemyTurn.AddListener(EndEnemyTurn);
        BattleManager.Instance.SetEnemyBattleManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && BattleManager.Instance.GetCurrentTurnState() == TurnEnum.EnemyTurn)
        {
            BattleManager.Instance.m_EndEnemyTurn.Invoke();;
        }
    }

    public void DoEnemyTurn()
    {
        Debug.Log("Do Enemy Turn");
        ChooseMove();
    }

    public void EndEnemyTurn()
    {
        Debug.Log("End Enemy Turn");
    }

    private void ChooseMove()
    {
        int randNum = Random.Range(1, 5);
        switch (randNum)
        {
            case 1:
                StartCoroutine(EnemyPunch());
            break;
            case 2:
                StartCoroutine(EnemyKick());
            break;    
            case 3:
                StartCoroutine(EnemyBlock());
            break;    
            case 4:
                StartCoroutine(EnemyHeal());
            break;    
            default:
            break;    
        }
    }

    private void DealDamageToPlayer(float DamageToDeal)
    {
        BattleManager.Instance.GetPlayerBattleManager().TakeDamage(DamageToDeal);
    }

    IEnumerator EnemyPunch()
    {
        yield return new WaitForSeconds(2.0f);
        DealDamageToPlayer(10.0f);
        Debug.Log("Punch Player");
        BattleManager.Instance.m_EndEnemyTurn.Invoke();
    }
    
    IEnumerator EnemyKick()
    {
        yield return new WaitForSeconds(2.0f);
        DealDamageToPlayer(10.0f);
        Debug.Log("Kick Player");
        BattleManager.Instance.m_EndEnemyTurn.Invoke();
    }
    
    IEnumerator EnemyBlock()
    {
        yield return new WaitForSeconds(2.0f);
        _enemy.HealEnemy(10.0f);
        Debug.Log("Enemy Blocked");
        BattleManager.Instance.m_EndEnemyTurn.Invoke();
    }
    
    IEnumerator EnemyHeal()
    {
        yield return new WaitForSeconds(2.0f);
        _enemy.HealEnemy(10.0f);
        Debug.Log("Enemy Healed");
        BattleManager.Instance.m_EndEnemyTurn.Invoke();
    }
    
}
