using System.Collections.Generic;
using TutanDev.Core;

namespace TutanDev.UI
{
    public class ColorSelector : BaseOptionSelector<ColorReference, ColorButton>
    {

        public override void Init(List<ColorReference> data)
        {
            base.Init(data);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetColor(options[i]);
            }
        }
    }
}