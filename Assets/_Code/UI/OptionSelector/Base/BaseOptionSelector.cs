using System;
using System.Collections.Generic;
using UnityEngine;

namespace TutanDev.UI
{
    public abstract class BaseOptionSelector<TRef, TButton> : MonoBehaviour where TButton : BaseOptionButton<TRef> 
    {
        public Action<TRef> OnOptionSelected;

        protected List<TButton> buttons;
        TButton buttonPrefab;
        int selectedIndex = -1;

        protected List<TRef> options;
        Transform myTransfrom;

        public virtual void Init(List<TRef> data)
        {
            GetButtonPrefab();
            InstantiateAllOptions(data);
        }

        public void ApplyFilter(List<TRef> activeList)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(activeList.Contains(button.GetReference()));
            }

            OnButtonSelected(0);
        }

        void GetButtonPrefab()
        {
            myTransfrom = transform;
            buttonPrefab = myTransfrom.GetChild(0).GetComponent<TButton>();
            buttonPrefab.gameObject.SetActive(false);
        }

        void InstantiateAllOptions(List<TRef> data)
        {
            options = new List<TRef>();
            buttons = new List<TButton>();
            for (int i = 0; i < data.Count; i++)
            {
                options.Add(data[i]);
                var button = Instantiate(buttonPrefab, myTransfrom);
                button.index = i;
                button.OnClicked += OnButtonSelected;
                buttons.Add(button);
            }
        }

        void OnButtonSelected(int index)
        {
            if (selectedIndex == index) return;

            if (selectedIndex >= 0)
            {
                buttons[selectedIndex].Select(false);
            }

            selectedIndex = index;
            buttons[selectedIndex].Select(true);

            OnOptionSelected?.Invoke(options[selectedIndex]);
        }
    }
}