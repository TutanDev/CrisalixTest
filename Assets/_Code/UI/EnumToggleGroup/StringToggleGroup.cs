using System;
using System.Collections;
using System.Collections.Generic;
using TutanDev.References;
using UnityEngine;

namespace TutanDev.UI
{
    public class StringToggleGroup : MonoBehaviour
    {
        public Action<BallType> OnTypeSelected;

        List<StringToggleButton> buttons;
        StringToggleButton buttonPrefab;
        int selectedIndex = -1;

        List<BallType> model;
        Transform myTransfrom;

        private void Awake()
        {
            myTransfrom = transform;
            buttonPrefab = myTransfrom.GetChild(0).GetComponent<StringToggleButton>();
            buttonPrefab.gameObject.SetActive(false);
        }

        public void Init(List<BallType> data)
        {
            model = data;

            buttons = new List<StringToggleButton>();
            for (int i = 0; i < model.Count; i++)
            {
                var button = Instantiate(buttonPrefab, myTransfrom);
                button.gameObject.SetActive(true);
                button.index = i;
                button.OnClicked += OnButtonSelected;
                button.SetLabel(model[i].name);
                buttons.Add(button);
            }
        }

        void OnButtonSelected(int index)
        {
            if (selectedIndex == index) return;

            if(selectedIndex >=0)
            {
                buttons[selectedIndex].Select(false);
            }

            selectedIndex = index;
            buttons[selectedIndex].Select(true);
            OnTypeSelected?.Invoke(model[selectedIndex]);
        }
    }
}
