using TutanDev.References;
using UnityEngine;

namespace TutanDev.Core
{
    public class ColorSetter
    {
        ColorReference reference;

        public ColorSetter(ColorReference reference)
        {
            this.reference = reference;
        }

        public void SetValue(ColorReference colorRef)
        {
            reference.Value = colorRef.Value;
        }

        public void SetValue(Color colorVal)
        {
            reference.Value = colorVal;
        }
    }
}
