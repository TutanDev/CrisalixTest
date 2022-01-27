using TutanDev.UI;
using UnityEngine;

namespace TutanDev.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AppConfiguration config;
        [SerializeField] ControlMenu controlMenu;

        ColorSetter colorSetter;
        FloatSetter radiusSetter;


        private void OnEnable()
        {
            colorSetter = new ColorSetter(config.ballColor);
            radiusSetter = new FloatSetter(config.ballRadius);

            controlMenu.Init(config);
            controlMenu.OnRadiusSelectorChanged += SetBallRadius;
            controlMenu.OnColorSelectorChanged += SetBallColor;
        }

        private void OnDisable()
        {
            controlMenu.OnRadiusSelectorChanged -= SetBallRadius;
            controlMenu.OnColorSelectorChanged -= SetBallColor;
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