using System;
using System.Linq;
using TutanDev.Core;
using TutanDev.Core.Types;
using TutanDev.References;
using UnityEngine;

namespace TutanDev.UI
{
    public class ControlMenu : MonoBehaviour
    {
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
            OnRadiusSelectorChanged(newRadius);
        }

        public void ColorSelectorChanged(ColorReference color)
        {
            OnColorSelectorChanged(color);
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
            radiusSelector.SetRange(selectedType.minRadius, selectedType.maxRadius);
            colorSelector.ApplyFilter(selectedType.colorPallete.ToList());
        }
    }
}