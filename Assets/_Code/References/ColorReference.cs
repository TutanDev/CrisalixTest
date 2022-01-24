using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TutanDev.References
{
    [CreateAssetMenu(menuName = "SO References/Color")]
    public class ColorReference : Reference<Color>
    {
        [SerializeField] Color initialValue;


        private void OnEnable()
        {
            Value = initialValue;
        }
        public override bool Equals(Color t)
        {
            return Value == t;
        }
    }
}
