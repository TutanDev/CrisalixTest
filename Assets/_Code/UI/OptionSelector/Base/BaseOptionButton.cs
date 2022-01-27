using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TutanDev.UI
{
    public abstract class BaseOptionButton<TRef> : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]Image selectedImage;

        public int index;
        public Action<int> OnClicked;

        private void Awake()
        {
            selectedImage.enabled = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(index);
        }

        public void Select(bool selected)
        {
            selectedImage.enabled = selected;
        }

        public abstract TRef GetReference();
    }
}