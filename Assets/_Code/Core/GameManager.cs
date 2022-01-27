using TutanDev.UI;
using UnityEngine;

namespace TutanDev.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AppConfiguration config;
        [SerializeField] ControlMenu controlMenu;
        [SerializeField] Renderer StressBall;

        [SerializeField] Summary summary;
        [SerializeField] StringReference summaryTextRef;

        ColorSetter colorSetter;
        FloatSetter radiusSetter;


        private void OnEnable()
        {
            StressBall.enabled = false;

            colorSetter = new ColorSetter(config.ballColor);
            radiusSetter = new FloatSetter(config.ballRadius);

            controlMenu.Init(config);
            controlMenu.OnTypeSelectorChanged += OnTypeChanged;
            controlMenu.OnRadiusSelectorChanged += SetBallRadius;
            controlMenu.OnColorSelectorChanged += SetBallColor;

            summary.Init(config, controlMenu);
        }

        private void OnDisable()
        {
            controlMenu.OnRadiusSelectorChanged -= SetBallRadius;
            controlMenu.OnColorSelectorChanged -= SetBallColor;
            controlMenu.OnTypeSelectorChanged -= OnTypeChanged;
        }

        void OnTypeChanged(string newType)
        {
            StressBall.enabled = true;
        }

        void SetBallColor(ColorReference input)
        {
            if (input == config.ballColor) return;

            colorSetter.SetValue(input);

            var preset = config.GetPresetByColor(input);
            if (preset != null)
            {
                SetBallRadius(preset.radius * 10);
            }
        }

        void SetBallRadius(float input)
        {
            radiusSetter.SetValue(input * 0.1f);
        }

    }
}