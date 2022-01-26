using TutanDev.References;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.UI
{
    public sealed class ColorButton : BaseOptionButton<ColorReference>
    {
        [SerializeField] Image colorImage;
        ColorReference color;

        public void SetColor(ColorReference color)
        {
            this.color = color;
            colorImage.color = color.Value;
        }

        public override ColorReference GetReference()
        {
            return color; 
        }
    }
}
