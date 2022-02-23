using System;
using UnityEngine;

namespace Weapons
{
    public class Bottle : Weapon
    {

        private void Awake()
        {
            TimeBtwnAttack = 1;
            AttackRange = 1f;
            AttackDamage = 1f;
            Evolution = gameObject.AddComponent<CrushedBottle>();
            NHitsToEvolve = 4;
        }

        protected override void Evolve(Weapon evolution)
        {
            base.Evolve(Evolution);
        }
    }
    
}
