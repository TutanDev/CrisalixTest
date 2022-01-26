using UnityEngine;

namespace TutanDev.Core
{
    [RequireComponent(typeof(Renderer))]
    public class MaterialController : MonoBehaviour
    {
        [SerializeField] References.FloatReference size;
        [SerializeField] References.ColorReference color;
        Renderer myRrenderer;
        MaterialPropertyBlock block;

        void Awake()
        {
            block = new MaterialPropertyBlock();
            myRrenderer = GetComponent<Renderer>();
            myRrenderer.GetPropertyBlock(block);
        }

        private void OnEnable()
        {
            size.OnValueChanged += UpdateBallSize;
            color.OnValueChanged += UpdateColor;
        }

        private void OnDisable()
        {
            size.OnValueChanged -= UpdateBallSize;
            color.OnValueChanged -= UpdateColor;
        }
        void UpdateBallSize(float size)
        {
            block.SetFloat("Radius", size);
            myRrenderer.SetPropertyBlock(block);
        }

        void UpdateColor(Color color)
        {
            block.SetColor("BallColor", color);
            myRrenderer.SetPropertyBlock(block);
        }
    }
}
