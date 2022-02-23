using System;
using UnityEngine;

namespace Weapons
{
    public class Bottle : MonoBehaviour, IWeapon
    {
        public float timeBtwnAttack { get; set; }
        public float attackRange { get; set; }
        public float attackDamage { get; set; }

        private void Awake()
        {
            timeBtwnAttack = 0.5f;
            attackRange = 0.5f;
            attackDamage = 1f;
        }
    }
}
