using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TutanDev.UI
{
    public class StringToggleButton : ToggleButton
    {
        [SerializeField] TMProTextUpdater stringUpdater;

        public void SetLabel(string content)
        {
            stringUpdater.Init(content);
        }
    }
}
