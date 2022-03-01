using UnityEngine;

namespace Weapons
{
    public class Beercan: Weapon
    {
        private void Awake()
        {
            TimeBtwnAttack = 1;
            AttackRange = 0.5f;
            AttackDamage = 3f;
            Evolution = gameObject.AddComponent<Fists>();;
            NHitsToEvolve = 2;
            sprite = Resources.Load<Sprite>("Sprites/Weapons/beercan");
        }
    }
}