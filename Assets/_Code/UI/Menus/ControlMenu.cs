using System;
using System.Collections.Generic;
using System.Linq;
using TutanDev.Core;
using TutanDev.Core.Types;
using UnityEngine;

namespace TutanDev.UI
{
    public class ControlMenu : MonoBehaviour
    {
        public Action<string> OnTypeSelectorChanged;
        public Action<float> OnRadiusSelectorChanged;
        public Action<ColorReference> OnColorSelectorChanged;

        [SerializeField] Transform typePanel;
        [SerializeField] Transform radiusPanel;
        [SerializeField] Transform colorPanel;

        StringSelector typeSelector;
        RangeFloatUpdater radiusSelector;
        ColorSelector colorSelector;

        AppConfiguration config;

        public void Init(AppConfiguration config)
        {
            this.config = config;

            typeSelector = typePanel.GetComponentInChildren<StringSelector>();
            typeSelector.Init(config.GetAllTypesNames());
            typeSelector.OnOptionSelected += OnFirstTypeSelected;
            typeSelector.OnOptionSelected += OnTypeSelected;

            radiusSelector = radiusPanel.GetComponentInChildren<RangeFloatUpdater>();
            radiusSelector.OnSliderValueVhanged += RadiusSelectorChanged;

            colorSelector = colorPanel.GetComponentInChildren<ColorSelector>();
            colorSelector.OnOptionSelected += ColorSelectorChanged;

            radiusPanel.gameObject.SetActive(false);
            colorPanel.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            typeSelector.OnOptionSelected -= OnFirstTypeSelected;
            typeSelector.OnOptionSelected -= OnTypeSelected;
            radiusSelector.OnSliderValueVhanged -= RadiusSelectorChanged;
            colorSelector.OnOptionSelected -= ColorSelectorChanged;
        }
        public void RadiusSelectorChanged(float newRadius)
        {
            config.GetTypeByName(typeSelector.GetSelectedOption()).selectedRadius = newRadius;
            OnRadiusSelectorChanged(newRadius);
        }

        public void ColorSelectorChanged(ColorReference newColor)
        {
            var preset = config.GetPresetByColor(newColor);
            if (preset != null)
            {
                ApplyPresetView(preset);
            }
            else
            {
                config.GetTypeByName(typeSelector.GetSelectedOption()).selectedColor = newColor;
            }
            OnColorSelectorChanged(newColor);
        }

        public void ApplyPresetView(BallPreset preset)
        {
            typeSelector.DeselectAll();
            colorSelector.ApplyFilter(new List<ColorReference> { preset.color });
            radiusSelector.SetFixRadius(preset.radius);
        }

        void OnFirstTypeSelected(string selectedTypeName)
        {
            radiusPanel.gameObject.SetActive(true);
            colorPanel.gameObject.SetActive(true);
            colorSelector.Init(config.GetAllColors());
            typeSelector.OnOptionSelected -= OnFirstTypeSelected;
        }

        void OnTypeSelected(string selectedTypeName)
        {
            BallType selectedType = config.GetTypeByName(selectedTypeName);
            radiusSelector.SetRange(selectedType.minRadius, selectedType.maxRadius, selectedType.selectedRadius);
            colorSelector.ApplyFilter(selectedType.colorPallete.ToList(), selectedType.selectedColor);
            OnTypeSelectorChanged?.Invoke(selectedTypeName);
        }
    }
}