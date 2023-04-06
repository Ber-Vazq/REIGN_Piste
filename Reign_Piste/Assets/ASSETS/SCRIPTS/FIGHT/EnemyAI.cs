using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    // TODO: add public and private variables
    [Header("Public Variables")]
    public float moveSpeed;
    public float attackDelay;
    public float attackRange = 1f;
    public Transform attackPoint;
    public float attackDamage = 1f;
    public LayerMask attackLayers;    
    public float maxHealth;
    public TextMeshProUGUI enemyScoreTxt;
    public TextMeshProUGUI enemyHealthDot;

    private Rigidbody2D rb;
    private Animator anim;
    private Health health;
    private float moveInput;
    private bool isAttacking = false;
    private float attackTimer = 0f;
    private bool hasAttacked = false;
    private float currentHealth;

    //todo is todone

    // Start is called before the first frame update
    void Start()
    {
       // SOMETHING WILL BE HERE I SWEAR
       // SOMETHING IS BEING PUT HERE
       rb = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       health = GetComponent<Health>();
       currentHealth = maxHealth;
       UpdateHealthDot(health.currentHealth, health.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //SOMETHING ELSE WILL BE HERE
        //SOMETHING IS BEING PUT HERE
        transform.Translate(-1 * moveSpeed * Time.deltaTime, 0, 0); //movement, is being updated
        if (currentHealth <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDelay)
            {
                isAttacking = false;
                attackTimer = 0f;   
            }   
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayers);
            if(attackPoint != null){
                foreach (Collider2D enemy in hitEnemies){
                if (enemy.CompareTag("Player"))
                    {
                        enemy.GetComponent<Health>().TakeDamage(attackDamage);
                    }   
                }
            }
            if (hitEnemies.Length > 0)
            {
                anim.SetTrigger("attack");
                hasAttacked = true;
            }
            else if (hasAttacked && anim.GetCurrentAnimatorStateInfo(0).IsName("attack")&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
                hasAttacked = false;
                anim.Play("idle");
            }
        }
        moveInput = Random.Range(-1f,1f);
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        UpdateHealthDot(health.currentHealth,health.maxHealth);
    }
    //TODO: add methods for attacks and collision detection with player
    //added attack in update method
    void UpdateHealthDot(float currentHealth, float maxHealth){
        float healthRatio = currentHealth/maxHealth;
        Color dotColor = Color.Lerp(Color.red, Color.green, healthRatio);
        if (gameObject.activeSelf == false)//should make it so that when the enemy is destroyed the dot turns red
        {
            dotColor = Color.red;   
        }
        enemyHealthDot.text =  "<color=#" + ColorUtility.ToHtmlStringRGB(dotColor) + ">.</color>"; //setting dot color
    }
}
