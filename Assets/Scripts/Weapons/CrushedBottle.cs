using UnityEngine;

namespace Weapons
{
    public class CrushedBottle: Weapon
    {
        private void Awake()
        {
            TimeBtwnAttack = 0.5f;
            AttackRange = 0.5f;
            AttackDamage = 5f;
            Evolution = null;
            NHitsToEvolve = -1;
            sprite = Resources.Load<Sprite>("Sprites/Weapons/crushedBottle");
        }
    }
}