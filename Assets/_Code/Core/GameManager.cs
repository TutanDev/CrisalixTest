using TutanDev.UI;
using UnityEngine;

namespace TutanDev.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AppConfiguration config;
        [SerializeField] ControlMenu controlMenu;
        [SerializeField] Renderer StressBall;

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
        }

        private void OnDisable()
        {
            controlMenu.OnRadiusSelectorChanged -= SetBallRadius;
            controlMenu.OnColorSelectorChanged -= SetBallColor;
        }

        void OnTypeChanged(string newType)
        {
            StressBall.enabled = true;
            controlMenu.OnTypeSelectorChanged -= OnTypeChanged;
        }

        void SetBallColor(ColorReference input)
        {
            colorSetter.SetValue(input);

            if (input == config.GetColorByName("Black"))
            {
                SetBallRadius(50);
                controlMenu.ApplyBlackView(5);
            }
        }

        void SetBallRadius(float input)
        {
            radiusSetter.SetValue(input * 0.1f);
        }

    }
}