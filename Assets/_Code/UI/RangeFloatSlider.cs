using TMPro;
using TutanDev.References;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev
{
    public class RangeFloatSlider : MonoBehaviour
    {
        [SerializeField] FloatReference BallRadius;
        [SerializeField] TMP_Text minLabel;
        [SerializeField] TMP_Text maxLabel;
        [SerializeField] Slider slider;

        public void UpdateData(BallType data)
        {
            minLabel.text = data.minRadius.ToString("#.#");
            maxLabel.text = data.maxRadius.ToString("#.#");
            slider.minValue = data.minRadius * 10;
            slider.maxValue = data.maxRadius * 10;
            slider.value = slider.minValue;
        }

        private void Update()
        {
            BallRadius.Value = slider.value;
        }
    }
}
