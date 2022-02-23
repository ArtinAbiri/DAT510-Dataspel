using UnityEngine;

namespace Weapons
{
    public class Fists : Weapon
    {
        private void Awake()
        {
            TimeBtwnAttack = 1;
            AttackRange = 0.5f;
            AttackDamage = 0f;
            Evolution = null;
            NHitsToEvolve = -1;
        }
    }
}