using TMPro;
using TutanDev.Core;
using UnityEngine;

namespace TutanDev.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextUpdater : MonoBehaviour
    {
        TMP_Text label;
        StringReference reference;
        bool isAsset = false;

        public void Init(string value)
        {
            label = GetComponent<TMP_Text>();
            reference = ScriptableObject.CreateInstance<StringReference>();
            reference.OnValueChanged += UpdateText;
            reference.Value = value;
        }

        public StringReference GetReference()
        {
            return reference;
        }

        private void OnDestroy()
        {
            if (reference && !isAsset)
            {
                Destroy(reference);
            }
        }

        void UpdateText(string text)
        {
            label.text = text.ToString();
        }
    }
}