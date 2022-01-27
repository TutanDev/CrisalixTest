using UnityEngine;

namespace TutanDev.Core
{
    [CreateAssetMenu(menuName = "SO References/Float")]
    public class FloatReference : Reference<float>
    {
        [SerializeField] float initialValue;

        private void OnEnable()
        {
            Value = initialValue;
        }

        public override bool Equals(float t)
        {
            return Value == t;
        }
    }
}