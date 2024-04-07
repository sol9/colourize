using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UltEvents;
using UnityEngine;
using UnityEngine.Events;

public class inputDelegator : SerializedMonoBehaviour
{
    public List<condition> events;
    
    [Serializable]
    public class condition
    {
        public KeyCode key;
        public type when;

        public UnityEvent @event;
        
        [EnumToggleButtons]
        public enum type
        {
            down,
            hold,
            up,
        }

        private bool _condition => when switch
        {
            type.down => Input.GetKeyDown(key),
            type.hold => Input.GetKey(key),
            type.up => Input.GetKeyUp(key),
            _ => false,
        };

        public void run()
        {
            if (_condition && @event != null)
                @event.Invoke();
        }
    }
    
    private void Update()
    {
        if (events.invalid())
            return;

        events.ForEach(e => e.run());
    }
}
