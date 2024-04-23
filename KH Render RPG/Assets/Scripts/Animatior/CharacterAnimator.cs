using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    CharacterCombat combat;
    Animator animator;
    NavMeshAgent agent;

    private void Awake()
    {
        combat = GetComponent<CharacterCombat>();
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        combat.OnIdle += OnIdle;
        combat.OnAttack += OnAttack;
        combat.OnHit += OnHit;
        combat.OnDie += OnDie;
    }

    private void Update()
    {
        animator.SetFloat("Walk", agent.velocity.magnitude);
    }
    void OnIdle()
    {
        animator.SetFloat("Walk", 0f);
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnHit()
    {
        animator.SetTrigger("Hit");
    }

    void OnDie()
    {
        animator.SetTrigger("Die");
    }

    private void OnDisable()
    {
        combat.OnIdle -= OnIdle;
        combat.OnAttack -= OnAttack;
        combat.OnHit -= OnHit;
        combat.OnDie -= OnDie;
    }
}
