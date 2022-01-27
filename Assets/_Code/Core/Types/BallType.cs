using UnityEngine;

namespace TutanDev.Core.Types
{
    [CreateAssetMenu(menuName = "SO References/BallType")]
    public class BallType : ScriptableObject
    {
        [Tooltip("Minimun radius for the ball")]
        public float minRadius;
        [Tooltip("Maximun radius for the ball")]
        public float maxRadius;
        [Tooltip("Color Options")]
        public ColorReference[] colorPallete;
    }
}