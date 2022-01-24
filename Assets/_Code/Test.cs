using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TutanDev
{
    public class Test : MonoBehaviour
    {
        [SerializeField] References.FloatReference aaa;
        [SerializeField] References.ColorReference bbb;

        private void OnEnable()
        {
            transform.GetChild(0).GetComponent<Button>().onClick.AddListener(MAS);
            transform.GetChild(1).GetComponent<Button>().onClick.AddListener(MENOS);
            transform.GetChild(2).GetComponent<Button>().onClick.AddListener(COLOR);
        }

        private void OnDisable()
        {
            transform.GetChild(0).GetComponent<Button>().onClick.RemoveListener(MAS);
            transform.GetChild(1).GetComponent<Button>().onClick.RemoveListener(MENOS);
            transform.GetChild(2).GetComponent<Button>().onClick.RemoveListener(COLOR);
        }

        void MAS()
        {
            aaa.Value += 0.1f;
        }
        void MENOS()
        {
            aaa.Value -= 0.1f;
        }

        void COLOR()
        {
            bbb.Value = Random.ColorHSV();
        }
    }
}
