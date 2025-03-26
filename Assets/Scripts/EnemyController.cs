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
    IEnumerator StateMachine() // 적과 다르게 플레이어는 한명이니 그냥 FSM 자체에 찾기 넣었습니다. 
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
        Debug.Log(player.name + "를 공격!");
        // 여기다 플레이어 체력 달게 하는 뭔가 추가
    }
}
