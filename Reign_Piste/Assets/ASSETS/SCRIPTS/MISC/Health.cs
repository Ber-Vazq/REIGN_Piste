using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
    //fightcontroller will be made sometime soon(before wednesday for sure)
    private FightController fightController;
    
    // Start is called before the first frame update
    //setting the health to max(1 because this game is one hit only babygril)
    void Start()
    {
        currentHealth = maxHealth;
        fightController = FindObjectOfType<FightController>();
    }
    //yoinked the update method, dont need rn
    //gonna add one for taking damage though
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();   
        }
    }
    //die method lmao
    private void Die()
    {
        fightController.ResetRound(); //method that will be added to fight controller script
        //TODO add 'death' animation
        gameObject.SetActive(false);//disable gameobject so that theres no messing with results
    }
}
