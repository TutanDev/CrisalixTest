using System;
using UnityEngine;

namespace TutanDev.Core
{
    public abstract class Reference<T> : ScriptableObject
    {
        public Action<T> OnValueChanged;
        private T value;
        public T Value
        {
            get => value;
            set
            {
                if (Equals(value)) return;
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }
        public abstract bool Equals(T t);
    }
}