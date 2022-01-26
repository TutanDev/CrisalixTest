using TMPro;
using TutanDev.References;
using UnityEngine;

namespace TutanDev.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextUpdater : MonoBehaviour
    {
        TMP_Text label;
        StringReference reference;

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
            if (reference)
            {
                Destroy(reference);
            }
        }

        void UpdateText(string a)
        {
            label.text = a.ToString();
        }
    }
}
