using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void OnFocusChanged(Interactable newFocus);
    public OnFocusChanged onFocusChanged;

    Camera cam;
    Animator animator;

    PlayerMotor motor;
    CharacterCombat combat;

    public LayerMask movementMask;
    public LayerMask interactionMask;

    public Interactable focus;

    void Start()
    {
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>();
        motor = GetComponent<PlayerMotor>();
        combat = GetComponent<CharacterCombat>();
    }

  
    void Update()
    {
        // float agentVelocity = agent.velocity.sqrMagnitude;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToTarget(hit.point);
                SetFocus(null);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, interactionMask))
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
                // == combat.Attack();
            }
        }

        /*
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                animator.SetFloat("Walk", 0.0f);
            }
        }

        animator.SetFloat("Walk", agentVelocity);
        */
    }

    void SetFocus(Interactable newFocus)
    {
        /*
        if (onFocusChanged != null)
            onFocusChanged(newFocus);
        */
        onFocusChanged?.Invoke(newFocus);

        if (focus != newFocus && focus != null)
        {
            focus.OnDefocused();
        }

        focus = newFocus;

        if(focus != null)
        {
            focus.OnFocused(transform);
        }


    }


}
