using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.UI
{
    public class ColorToggleButton : ToggleButton
    {
        [SerializeField] Image colorImage;

        public void SetColor(Color color)
        {
            colorImage.color = color;
        }

    }
}
