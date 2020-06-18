using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitwiseOperation
{
    public class StatusAddManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject buttonObject;
        [SerializeField]
        private RectTransform buttonPanelTransform;

        // Start is called before the first frame update
        void Start()
        {
            var randomButton = GameObject.Instantiate<GameObject>(buttonObject, buttonPanelTransform);
            randomButton.GetComponentInChildren<Text>().text = "Random";
            randomButton.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                AddStatus((StatusFlags)UnityEngine.Random.Range(0, 1 << Enum.GetValues(typeof(StatusFlags)).Length - 1));
            });

            foreach (StatusFlags flag in Enum.GetValues(typeof(StatusFlags)))
            {
                if (flag == StatusFlags.None) continue;

                var flagButton = GameObject.Instantiate<GameObject>(buttonObject, buttonPanelTransform);
                flagButton.GetComponentInChildren<Text>().text = flag.ToString();
                flagButton.GetComponentInChildren<Button>().onClick.AddListener(() => AddStatus(flag));
            }
        }

        private void AddStatus(StatusFlags status)
        {
            PlayerStatus.Instance.AddStatus((byte)status);
        }
    }
}