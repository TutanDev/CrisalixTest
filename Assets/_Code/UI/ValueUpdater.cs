using UnityEngine;
using UnityEngine.UI;

namespace TutanDev.UI
{
    public class ValueUpdater<T> : MonoBehaviour
    {
        [SerializeField] References.Reference<T> value;
        [SerializeField] Text text;

        private void OnEnable()
        {
            value.OnValueChanged += UpdateText;
            UpdateText(value.Value);
        }
        private void OnDisable()
        {
            value.OnValueChanged -= UpdateText;
        }

        void UpdateText(T a)
        {
            text.text = a.ToString();
        }
    }
}
