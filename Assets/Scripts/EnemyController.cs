using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum State { Idle, Move, Attack }
    public State currentState = State.Idle;

    public float detectionRadius = 500f;
    public float attackRange = 2f;
    private NavMeshAgent agent;
    private GameObject player;

    public float maxHp = 20;
    public float currentHp;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StateMachine());
    }
    IEnumerator StateMachine() // ���� �ٸ��� �÷��̾�� �Ѹ��̴� �׳� FSM ��ü�� ã�� �־����ϴ�. 
    {
        while (true)
        {
            switch (currentState) 
            {
                case State.Idle:
                    if (player != null && Vector3.Distance(transform.position, player.transform.position) <= detectionRadius)
                        currentState = State.Move;
                    break;

                case State.Move:
                    if (player == null)
                    {
                        currentState = State.Idle;
                        break;
                    }
                    agent.SetDestination(player.transform.position);
                    if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
                        currentState = State.Attack;
                    break;

                case State.Attack:
                    if (player == null || Vector3.Distance(transform.position, player.transform.position) > attackRange)
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
    void Attack()
    {
        Debug.Log(player.name + "�� ����!");
        // ����� �÷��̾� ü�� �ް� �ϴ� ���� �߰�
    }
}
