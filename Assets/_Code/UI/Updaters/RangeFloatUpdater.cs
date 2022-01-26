using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.Core
{
    public class RangeFloatUpdater : MonoBehaviour
    {
        public Action<float> OnSliderValueVhanged;

        [SerializeField] TMP_Text minLabel;
        [SerializeField] TMP_Text maxLabel;
        [SerializeField] Slider slider;

        private void OnEnable()
        {
            slider.onValueChanged.AddListener((value) => OnSliderValueVhanged(value));
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveAllListeners();
        }

        public void SetRange(float min, float max)
        {
            minLabel.text = min.ToString("#.#");
            maxLabel.text = max.ToString("#.#");
            slider.minValue = min * 10;
            slider.maxValue = max * 10;
            //slider.value = min;
        }
    }
}
