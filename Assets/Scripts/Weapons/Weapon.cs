using System;
using System.Security.Cryptography;
using Player;
using UnityEngine;
using Object = System.Object;

namespace Weapons
{
    public abstract class Weapon: MonoBehaviour
    {
        [SerializeField] private PlayerWeaponManager _weaponManager;
        public float TimeBtwnAttack { get; set; }
        public float AttackRange { get; set; }
        public float AttackDamage { get; set; }
        protected Weapon Evolution { get; set; }
        
        public int NHitsToEvolve { get; set; }
        

        protected void Update()
        {
            if (NHitsToEvolve == 0)
                Evolve(Evolution);
        }

        protected virtual void Evolve(Weapon evolution)
        {
            Debug.Log("evolve to: " + evolution);
            _weaponManager.ChangeWeapon(evolution);
            Destroy(gameObject);
        }
    }
}
