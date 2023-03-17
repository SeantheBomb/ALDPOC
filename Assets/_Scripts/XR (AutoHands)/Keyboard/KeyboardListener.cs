using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Corrupted.Autohands
{

    public abstract class KeyboardListener : CorruptedBehaviour
    {

        public BoolVariable requireFocus;

        public abstract bool IsFocused
        {
            get;
        }


        protected virtual void OnEnable()
        {
            KeyboardController.OnUpdateText += UpdateInputField;
            KeyboardController.OnBackspace += BackspaceInputField;
            KeyboardController.OnClearText += ClearInputField;
        }

        protected virtual void OnDisable()
        {
            KeyboardController.OnUpdateText -= UpdateInputField;
            KeyboardController.OnBackspace -= BackspaceInputField;
            KeyboardController.OnClearText -= ClearInputField;
        }

        protected void UpdateInputField(string value)
        {
            if (requireFocus == false || IsFocused)
            {
                OnUpdateInput(value);
            }
        }

        [Button]
        public void BackspaceInputField()
        {
            if (requireFocus == false || IsFocused)
            {
                OnBackspaceInput();
            }
        }

        public void ClearInputField()
        {
            if (requireFocus == false || IsFocused)
            {
                OnClearInput();
            }
        }

        protected abstract void OnClearInput();


        protected abstract void OnUpdateInput(string input);

        protected abstract void OnBackspaceInput();
    }

}
