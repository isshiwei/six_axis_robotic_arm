using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AxisBtnControl : MonoBehaviour
{
    [System.Serializable]
    public class AxisBtn
    {
        public Button cutBtn;
        public Button addBtn;
        public float inputVal;
    }

    public AxisBtn[] axisBtn;

    public Button restoreBtn;

    private void Awake()
    {
        foreach (var axis in axisBtn)
        {
            // 添加 EventTrigger 组件
            EventTrigger cutTrigger = axis.cutBtn.gameObject.AddComponent<EventTrigger>();

            // 添加按下事件监听器
            EventTrigger.Entry cutPressEntry = new EventTrigger.Entry();
            cutPressEntry.eventID = EventTriggerType.PointerDown;
            cutPressEntry.callback.AddListener((data) => { axis.inputVal = -1; });
            cutTrigger.triggers.Add(cutPressEntry);

            // 添加松开事件监听器
            EventTrigger.Entry cutReleaseEntry = new EventTrigger.Entry();
            cutReleaseEntry.eventID = EventTriggerType.PointerUp;
            cutReleaseEntry.callback.AddListener((data) => { axis.inputVal = 0; });
            cutTrigger.triggers.Add(cutReleaseEntry);
            
            
            // 添加 EventTrigger 组件
            EventTrigger addTrigger = axis.addBtn.gameObject.AddComponent<EventTrigger>();

            // 添加按下事件监听器
            EventTrigger.Entry addPressEntry = new EventTrigger.Entry();
            addPressEntry.eventID = EventTriggerType.PointerDown;
            addPressEntry.callback.AddListener((data) => { axis.inputVal = 1; });
            addTrigger.triggers.Add(addPressEntry);

            // 添加松开事件监听器
            EventTrigger.Entry addReleaseEntry = new EventTrigger.Entry();
            addReleaseEntry.eventID = EventTriggerType.PointerUp;
            addReleaseEntry.callback.AddListener((data) => { axis.inputVal = 0; });
            addTrigger.triggers.Add(addReleaseEntry);
        }
    }
}
