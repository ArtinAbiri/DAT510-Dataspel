using UnityEngine;
using Weapons;
public class PlayerMeleeAttack : MonoBehaviour
{
    
    public IWeapon weapon { get; set;}
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask enemies;
    
    private Animator anim;
    private float timeBtwnAttackTimer;
    void Start()
    {
        anim = GetComponent<Animator>();
        weapon = gameObject.AddComponent<Fists>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwnAttackTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                Fight();
        }
        else
        {
            timeBtwnAttackTimer -= Time.deltaTime;
        }
    }
    
    private void Fight()
    {
        Debug.Log("player weapon " + weapon);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, weapon.attackRange, enemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Health>().TakeDamage(weapon.attackDamage);
        }
        anim.SetTrigger("fight");
        timeBtwnAttackTimer = weapon.timeBtwnAttack;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, weapon.attackRange);
    }
}
