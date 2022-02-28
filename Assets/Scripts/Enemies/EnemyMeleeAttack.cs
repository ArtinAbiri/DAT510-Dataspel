using System;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float timeBtwnAttack;

    //References
    private Animator anim;
    private Collider2D other;
    private float timeBtwnAttackTimer;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            other = col;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        other = null;
    }

    private void Update()
    {
        if (timeBtwnAttackTimer <= 0)
        {
            if (other) 
                Fight();
        }
        else
        {
            timeBtwnAttackTimer -= Time.deltaTime;
        }
    }

    private void Fight()
    {
        anim.SetTrigger("meleeAttack");
        other.transform.GetComponent<Health>().TakeDamage(damage);
        timeBtwnAttackTimer = timeBtwnAttack;
    }
}
