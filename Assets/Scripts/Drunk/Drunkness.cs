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
           
        }

        public void Drink(float amount)
        {
            Debug.Log("DRINK " + amount);
            currentDrunkness = Mathf.Clamp(currentDrunkness + amount, 0, 4);
        }

        private void Update()
        {
        }
    }
}