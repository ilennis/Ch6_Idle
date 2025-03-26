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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(StateMachine()); // FSM ����
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
        Debug.Log(target.name + "�� ����!");
       // ����� ü�� �ް� �ϴ� ���� �߰�
    }
}




