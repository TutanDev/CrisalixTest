using TMPro;
using TutanDev.Core;
using UnityEngine;

namespace TutanDev.UI
{
    public class Summary : MonoBehaviour
    {
        [SerializeField] StringReference summary;
        [SerializeField] TMP_Text label;

        AppConfiguration config;
        ControlMenu controlMenu;
        string ballType;
        string color;
        string radius;

        public void Init(AppConfiguration config, ControlMenu menu)
        {
            this.config = config;
            controlMenu = menu;

            controlMenu.OnTypeSelectorChanged += SetType;
            controlMenu.OnColorSelectorChanged += SetColor;
            controlMenu.OnRadiusSelectorChanged += SetRadius;

            summary.OnValueChanged += UpdateText;
        }

        private void OnDisable()
        {
            controlMenu.OnTypeSelectorChanged -= SetType;
            controlMenu.OnColorSelectorChanged -= SetColor;
            controlMenu.OnRadiusSelectorChanged -= SetRadius;

            summary.OnValueChanged -= UpdateText;
        }

        void SetType(string newType)
        {
            ballType = newType;
            UpdateSummary();
        }

        void SetColor(ColorReference newColor)
        {
            var preset = config.GetPresetByColor(newColor);
            if (preset != null)
            {
                summary.Value = preset.name;
            }
            else
            {
                color = newColor.name;
                UpdateSummary();
            }
        }

        void SetRadius(float newRadius)
        {
            radius = (newRadius * 0.1f).ToString();
            UpdateSummary();
        }

        void UpdateSummary()
        {
            summary.Value = $"{ballType} {color} {radius}cm";
        }

        void UpdateText(string text)
        {
            label.text = text.ToString();
        }
    }
}