using UnityEngine;

namespace TutanDev.UI
{
    public class StringButton : BaseOptionButton<string>
    {
        [SerializeField] TextUpdater stringUpdater;

        public override string GetReference()
        {
            return stringUpdater.GetReference().Value;
        }

        public void SetLabel(string content)
        {
            stringUpdater.Init(content);
        }
    }
}