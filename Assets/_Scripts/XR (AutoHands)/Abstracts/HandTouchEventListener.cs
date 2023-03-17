using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;


namespace Corrupted.Autohands
{
    [RequireComponent(typeof(HandTouchEvent))]
    public abstract class HandTouchEventListener : CorruptedBehaviour
    {

        HandTouchEvent button;

        // Start is called before the first frame update
        public virtual void OnEnable()
        {
            if (button == null)
                button = GetComponent<HandTouchEvent>();
            button.HandStartTouchEvent += OnPressed;
        }

        public virtual void OnDisable()
        {
            button.HandStartTouchEvent -= OnPressed;
        }

        void OnPressed(Hand h)
        {
            OnButtonActivated();
        }

        public abstract void OnButtonActivated();
    }
}
