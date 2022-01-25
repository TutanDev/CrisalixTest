using System.Collections;
using System.Collections.Generic;
using TutanDev.References;
using UnityEngine;

namespace TutanDev.UI
{
    public class ColorToggleCroup : MonoBehaviour
    {
        [SerializeField] ColorReference BallColor;
        List<ColorToggleButton> buttons;
        ColorToggleButton buttonPrefab;
        int selectedIndex = -1;

        BallType model;
        Transform myTransfrom;

        private void Awake()
        {
            myTransfrom = transform;
            buttonPrefab = myTransfrom.GetChild(0).GetComponent<ColorToggleButton>();
            buttonPrefab.gameObject.SetActive(false);
        }

        public void FillButtons(BallType data)
        {
            DestroyChildren();

            model = data;
            if (buttons == null)
            {
                buttons = new List<ColorToggleButton>();
            }
            for (int i = 0; i < model.colorPallete.Length; i++)
            {
                var button = Instantiate(buttonPrefab, myTransfrom);
                button.gameObject.SetActive(true);
                button.index = i;
                button.OnClicked += OnButtonSelected;
                button.SetColor(model.colorPallete[i].Value);
                buttons.Add(button);
            }
        }

        void DestroyChildren()
        {
            if (buttons == null || buttons.Count == 0) return;
            
            buttons.Clear();
            for (int i = 1; i < myTransfrom.childCount; i++)
            {
                Destroy(myTransfrom.GetChild(i).gameObject);
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

            BallColor.Value = model.colorPallete[selectedIndex].Value;
        }
    }
}
