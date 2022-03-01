using System;
using UnityEngine;

namespace Drunk
{
    public class Drunkness: MonoBehaviour
    {
        [SerializeField] private float startingDrunkness;
        public float currentDrunkness { get; private set; }
        private Health health;
        private void Awake()
        {
            health = gameObject.GetComponent<Health>();
            currentDrunkness = startingDrunkness;
            InvokeRepeating("SoberUp", 1f, 30f);
        }

        public void Drink(float amount)
        {
            Debug.Log("DRINK " + amount);
            currentDrunkness = Mathf.Clamp(currentDrunkness + amount, 0, 4);
            if (currentDrunkness >= 3.9f)
            {
                Blackout();
            }
        }

        public void SoberUp()
        {
            SoberUp(0.5f);
            health.isInvincible = false;
        }
        private void SoberUp(float amount)
        {   
            
            if (currentDrunkness <= 0)
            {
                Debug.Log("SoberUp damage taken");
                health.TakeDamage(1);
            }
            else
            {
                Debug.Log("SoberUp " + amount);
                currentDrunkness = Mathf.Clamp(currentDrunkness - amount, 0, 4);    
            }
            
        }

        private void Blackout()
        {
            health.TakeDamage(2);
            health.isInvincible = true;
        }
        private void Update()
        {
        }
    }
}