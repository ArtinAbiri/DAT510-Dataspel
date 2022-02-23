using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        public float timeBtwnAttack { get; set; }
        public float attackRange { get; set; }
        public float attackDamage { get; set; }

    }
}
