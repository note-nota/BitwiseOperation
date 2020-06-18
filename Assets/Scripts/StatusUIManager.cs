using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitwiseOperation
{
    public class StatusUIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject toggleObject;
        [SerializeField]
        private RectTransform togglesPanelTransform;
        [SerializeField]
        private Text byteText;


        private Dictionary<StatusFlags, Toggle> toggleDictionary = new Dictionary<StatusFlags, Toggle>();

        private void Start()
        {
            foreach (StatusFlags flag in Enum.GetValues(typeof(StatusFlags)))
            {
                if (flag == StatusFlags.None) continue;

                var flagToggle = GameObject.Instantiate<GameObject>(toggleObject, togglesPanelTransform);
                flagToggle.GetComponentInChildren<Text>().text = flag.ToString();
                toggleDictionary.Add(flag, flagToggle.GetComponentInChildren<Toggle>());
            }
            PlayerStatus.Instance.SetStatusChangedAction(UpdateStatus);
        }

        private void UpdateStatus(StatusFlags status)
        {

            byteText.text = ((byte)status).ToString();
            foreach (StatusFlags flag in Enum.GetValues(typeof(StatusFlags)))
            {
                if (flag == StatusFlags.None) continue;

                toggleDictionary[flag].isOn = (status == (status | flag));
            }
        }
    }
}