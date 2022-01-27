using System.Collections.Generic;

namespace TutanDev.UI
{
    public sealed class StringSelector : BaseOptionSelector<string, StringButton>
    {
        public override void Init(List<string> data)
        {
            base.Init(data);

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].SetLabel(options[i]);
                buttons[i].gameObject.SetActive(true);
            }
        }
    }
}