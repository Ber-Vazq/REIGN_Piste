using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header ("Public Variables")]
    public float moveSpeed = 5.0f;
    public float attackDelay = 0.1f;
    public int attackDamage = 1;
    public int maxHealth = 1;
    //these are pretty self explanatory but regardless, its the move speed, 
    //time delay between attacks, damage output, and health also all the public variables

    private Rigidbody2D rb;  
    private Animator anim; //idk why i had it be so long b4 but thats changed
    private Collider2D hitCollider;
    private Health health;
    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float moveInput;
    //okay cool so this is the characteristics of the player and all that, colliders, animations, and health
    // also the bool for if its attacking, the timer that starts between attacks, and the move input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //rigidbody and animator get good thing its not a gacha game, hah theres an idea for monetization

        hitCollider = transform.Find("HitCollider").GetComponent<Collider2D>();
        hitCollider.enabled = false;
        //this just looks for the collider placed at the end of the weapon in order to be able to 
        //register the attacks

        health = GetComponent<Health>();
        health.currentHealth = maxHealth;
        //gets players health and sets it to max at start of scene
        //hopefully
    }


    void Update()
    {
        //haha if you're looking at the changelog this is about to change so much
        //just found better methods and thought about better things.
       moveInput = Input.GetAxis("Horizontal"); //gets input from player
       rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        // Move the player horizontally
        
        if (isAttacking) //check for an attack and start timer
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDelay) // we gettin a lil fancy with the nested if statements
            //just checking if timer exceeds delay
            {
             isAttacking = false;
             attackTimer = 0f; //ending the attack and resetting timer
             hitCollider.enabled = false;//turning the hitCollider off   
            }
        }
        else
        {
            if (Input.GetButtonDown("Attack"))
            {
                isAttacking = true;
                attackTimer = 0f;
                hitCollider.enabled = true;
                //starting the attack, setting the timer, and activating the hit collider   
            }
        }
        //okay so i'm going to try to make it so that the lunge animation plays 
        //whenever the attack button is pressed, hopefully this works.
        anim.SetBool("isAttacking", isAttacking);

        if (healht.currentHealth <= 0)
        {
            Destroy(gameObject); 
            //just for now, by final show i expect to
            // have a little slump animation thing that will play instead
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Health enemyHealth = collision.GetComponent<Health>();
            enemyHealth.TakeDamage(attackDamage);//to register hits on enemy
            //thats embarrasing you didn't see that
        }
    }
}
