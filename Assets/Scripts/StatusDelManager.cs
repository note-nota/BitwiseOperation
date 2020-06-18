using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitwiseOperation
{
    public class StatusDelManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject buttonObject;
        [SerializeField]
        private RectTransform buttonPanelTransform;

        // Start is called before the first frame update
        void Start()
        {
            var clearButton = GameObject.Instantiate<GameObject>(buttonObject, buttonPanelTransform);
            clearButton.GetComponentInChildren<Text>().text = "Clear All";
            clearButton.GetComponentInChildren<Button>().onClick.AddListener(() => DelStatus((StatusFlags)~0));

            foreach (StatusFlags flag in Enum.GetValues(typeof(StatusFlags)))
            {
                if (flag == StatusFlags.None) continue;

                var flagButton = GameObject.Instantiate<GameObject>(buttonObject, buttonPanelTransform);
                flagButton.GetComponentInChildren<Text>().text = flag.ToString();
                flagButton.GetComponentInChildren<Button>().onClick.AddListener(() => DelStatus(flag));
            }
        }

        private void DelStatus(StatusFlags status)
        {
            PlayerStatus.Instance.DelStatus((byte)status);
        }


    }
}