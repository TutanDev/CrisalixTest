using TMPro;
using TutanDev.References;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class TMProTextUpdater : MonoBehaviour
    {
        TMP_Text label;
        StringReference reference;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
            reference = ScriptableObject.CreateInstance<StringReference>();
            reference.OnValueChanged += UpdateText;
        }

        public void Init(string value)
        {
            reference.Value = value;
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
