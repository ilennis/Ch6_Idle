using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public enum State { Idle, Move, Attack }
    public State currentState = State.Idle;

    public float detectionRadius = 500f;
    public float attackRange = 2f;
    private NavMeshAgent agent;
    private GameObject target;

    public float maxHp = 100;
    public float currentHp;
    public float attackDamage = 10;
    public float gold = 0;

    public IdleUIManager manager;

    void Start()
    {
        currentHp = maxHp;
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(StateMachine()); // FSM 구현
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.Idle:
                    target = FindNearestEnemy();
                    if (target != null)
                        currentState = State.Move;
                    break;

                case State.Move:
                    if (target == null)
                    {
                        currentState = State.Idle;
                        break;
                    }
                    agent.SetDestination(target.transform.position);
                    if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
                        currentState = State.Attack;
                    break;

                case State.Attack:
                    if (target == null || Vector3.Distance(transform.position, target.transform.position) > attackRange)
                    {
                        currentState = State.Idle;
                        break;
                    }
                    Attack();
                    break;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    public GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance && distance <= detectionRadius)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }
        return nearest;

    }
    void Attack()
    {
        Debug.Log(target.name + "를 공격!");
       // 여기다 체력 달게 하는 뭔가 추가
    }
    void TakeDamage(float damage)
    {
        currentHp -= damage;
    }

    void UpdateUI()
    {
        manager.UpdateUI();
    }
}




