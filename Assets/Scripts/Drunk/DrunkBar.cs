using UnityEngine;
using UnityEngine.UI;

namespace Drunk
{
    public class DrunkBar : MonoBehaviour
    {
        [SerializeField] private Drunkness playerDrunkness;
        [SerializeField] private Image currentDrunkBar;

        private void Update()
        {
            currentDrunkBar.fillAmount = playerDrunkness.currentDrunkness / 4;
        }
    }
}
