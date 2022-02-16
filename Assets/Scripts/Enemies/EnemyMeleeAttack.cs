using System;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private BoxCollider2D boxCollider;
    
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        /*
        cooldownTimer += Time.deltaTime;
        
        if (cooldownTimer >= attackCooldown)
        {
            cooldownTimer = 0;
            anim.SetTrigger("meleeAttack");
            playerHealth.TakeDamage(damage);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetTrigger("meleeAttack");
            col.transform.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
