using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BitwiseOperation
{
    public class PlayerStatus
    {
        private PlayerStatus() { } 
        private static PlayerStatus instance;
        public static PlayerStatus Instance
        {
            get{
                if (instance == null)
                {
                    instance = new PlayerStatus();
                }

                return instance;
            }

        }

        private StatusFlags status = 0;
        private StatusUpdateEvent OnUpdateStatus = new StatusUpdateEvent();

        public void UpdateStatus(byte flags)
        {
            status = (StatusFlags)flags;
            OnUpdateStatus.Invoke(status);
        }

        public void AddStatus(byte add)
        {
            status |= (StatusFlags)add;
            OnUpdateStatus.Invoke(status);
        }

        public void DelStatus(byte del)
        {
            status &= (StatusFlags)~del;
            OnUpdateStatus.Invoke(status);
        }

        public void SetStatusChangedAction(UnityAction<StatusFlags> action)
        {
            OnUpdateStatus.AddListener(action);
        }
    }
}