using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using Autohand;

namespace Corrupted.Autohands
{

    [RequireComponent(typeof(HandTouchEvent))]
    public abstract class KeyboardButton : CorruptedBehaviour
    {

        

        private KeyboardController parent;

        public KeyboardController Parent
        {
            get
            {
                if (parent == null)
                    parent = GetComponentInParent<KeyboardController>();
                return parent;
            }
        }

        HandTouchEvent button;
        Hand? pressed;

        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            parent = GetComponentInParent<KeyboardController>();
            button = GetComponent<HandTouchEvent>();
            button.HandStartTouchEvent += (Hand h) => OnKeyPressed();
        }

        public void OnPressed(Hand h)
        {
            if (pressed != null)
                return;
            pressed = h;
            OnKeyPressed();
        }

        public void OnReleased(Hand h)
        {
            if (pressed != h)
                return;
            pressed = null;
        }

        protected abstract void OnKeyPressed();
        
    }
}