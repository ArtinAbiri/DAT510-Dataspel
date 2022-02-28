using System;
using UnityEngine;

namespace Drunk
{
    public class Drunkness: MonoBehaviour
    {
        [SerializeField] private float startingDrunkness;
        public float currentDrunkness { get; private set; }

        private void Awake()
        {
            currentDrunkness = startingDrunkness;
            InvokeRepeating("SoberUp", 1f, 30f);
        }

        public void Drink(float amount)
        {
            Debug.Log("DRINK " + amount);
            currentDrunkness = Mathf.Clamp(currentDrunkness + amount, 0, 4);
        }

        public void SoberUp()
        {
            SoberUp(0.5f);
        }
        public void SoberUp(float amount)
        {   
            
            if (currentDrunkness <= 0)
            {
                Debug.Log("SoberUp damage taken");
                gameObject.GetComponent<Health>().TakeDamage(1);
            }
            else
            {
                Debug.Log("SoberUp " + amount);
                currentDrunkness = Mathf.Clamp(currentDrunkness - amount, 0, 4);    
            }
            
        }
        private void Update()
        {
        }
    }
}