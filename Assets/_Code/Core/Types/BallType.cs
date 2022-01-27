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

        [HideInInspector] public float selectedRadius;
        [HideInInspector] public ColorReference selectedColor;

        private void OnEnable()
        {
            selectedRadius = minRadius * 10.0f;
            selectedColor = colorPallete[0];
        }
    }
}