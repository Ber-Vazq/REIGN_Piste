using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public LayerMask groundLayer;
    private Rigidbody2D rb;

    public float attackDelay = 0.1f; // time between attacks
    private bool canAttack = true;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        Vector2 movement = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = movement;
        if (Input.GetButtonDown("Attack")&& canAttack)
        {
                canAttack = false;
                StartCoroutine(ResetAttack());
                animator.SetTrigger("Attack");
                Collider2D[] enemy = Physics2D.OverlapCircleAll(transform.position, attackRange, LayerMask.GetMask("Enemy"));
        }
    }
}