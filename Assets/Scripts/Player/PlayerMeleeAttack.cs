using Player;
using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerMeleeAttack : MonoBehaviour
    {
        [SerializeField] private Transform attackPos;
        [SerializeField] private LayerMask enemies;

        private Animator anim;
        private float timeBtwnAttackTimer;
        //private PlayerWeaponManager PlayerWeaponManagerScript;
        public Weapon weapon { get; set; }

        void Awake()
        {
            anim = GetComponent<Animator>();
           
        }

        // Update is called once per frame
        void Update()
        {   
            
            if (timeBtwnAttackTimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                {
                    Fight();
                }
            }
            else
            {
                timeBtwnAttackTimer -= Time.deltaTime;
            }
        }

        private void Fight()
        {

            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, weapon.AttackRange, enemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Health>().TakeDamage(weapon.AttackDamage);
            }

            if (enemiesToDamage.Length > 0)
            {
                weapon.NHitsToEvolve--;    
            }
            
            Debug.Log(weapon.NHitsToEvolve);
            anim.SetTrigger("fight");
            timeBtwnAttackTimer = weapon.TimeBtwnAttack;

        }

        private void OnDrawGizmosSelected()
        {
            if (weapon != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attackPos.position, weapon.AttackRange);
            }
        }
    }
}
