using UnityEngine;

namespace TutanDev.Core
{
    [CreateAssetMenu(menuName = "SO References/String")]
    public class StringReference : Reference<string>
    {
        [SerializeField] string initialValue;

        private void OnEnable()
        {
            Value = initialValue;
        }
        public override bool Equals(string t)
        {
            if (Value == null && t == null) return true;
            return Value != null &&t.CompareTo(Value) == 0;
        }
    }
}