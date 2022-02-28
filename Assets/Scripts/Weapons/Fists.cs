using UnityEngine;

namespace Weapons
{
    public class Fists : Weapon
    {
        private void Awake()
        {
            TimeBtwnAttack = 1;
            AttackRange = 0.5f;
            AttackDamage = 1f;
            Evolution = null;
            NHitsToEvolve = -1;
            sprite = Resources.Load<Sprite>("Sprites/Weapons/fists");
            Debug.Log(sprite);
        }
    }
}