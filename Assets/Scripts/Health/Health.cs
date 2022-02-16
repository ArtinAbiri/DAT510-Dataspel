using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        
            anim.SetTrigger("hurt");
            Debug.Log("Damage taken hurt");
            if (currentHealth <= 0)
            {
            anim.SetBool	("die",true );
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            }
    }

    private void Update()
    {
    }
}
