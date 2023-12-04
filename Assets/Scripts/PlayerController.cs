using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private Vector2 input;
    private bool moving;
    [SerializeField] private float speed = 1f;

    [SerializeField] private float collisionRadius = 0.1f;
    [SerializeField] private LayerMask solidObjectsLayer;
    [SerializeField] private LayerMask randomEncounterLayer;
    [SerializeField] private List<MonsterObject> monsters;


    public event Action<MonsterObject> OnEncounter;
    public void HandleUpdate()
    {
        if (!moving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (Walkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }

            animator.SetBool("moving", moving);
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        moving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        moving = false;

        CheckForEncounters();
    }

    private bool Walkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, collisionRadius, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, randomEncounterLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                animator.SetBool("isMoving", false);
                OnEncounter(monsters[Random.Range(0, monsters.Count)]);
            }
        }
    }
}
