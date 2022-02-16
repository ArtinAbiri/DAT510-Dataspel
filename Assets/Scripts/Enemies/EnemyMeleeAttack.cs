using System;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private int damage;
    

    //References
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
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
