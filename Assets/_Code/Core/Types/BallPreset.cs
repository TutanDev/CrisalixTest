using UnityEngine;

namespace TutanDev.Core.Types
{
    [CreateAssetMenu(menuName = "SO References/BallPreset")]
    public class BallPreset : ScriptableObject
    {
        public float radius;
        public ColorReference color;
    }
}
