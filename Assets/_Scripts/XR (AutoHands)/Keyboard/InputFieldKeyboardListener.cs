using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

namespace Corrupted.Autohands
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputFieldKeyboardListener : KeyboardListener
    {


        [SerializeField]
        int inputPosition;

        TMP_InputField inputField;

        public override bool IsFocused
        {
            get
            {
                if (inputField == null)
                    inputField = GetComponent<TMP_InputField>();
                return inputField.isFocused;
            }
        }

        public override void Start()
        {
            base.Start();
            inputField = GetComponent<TMP_InputField>();
            inputPosition = inputField.caretPosition;
        }





        protected override void OnUpdateInput(string value)
        {
            inputField.text = inputField.text.Insert(inputPosition, value);
            inputPosition += value.Length;
        }

        protected override void OnBackspaceInput()
        {
            if (inputField.text.Length == 0)
            {
                inputPosition = 0;
                return;
            }
            inputField.text = inputField.text.Remove(inputPosition - 1);
            inputPosition--;
            //Debug.Log("KeyboardListener: Set input field to " + inputField.text + ", adding " + value + " at caret position " + inputField.caretPosition);
        }
        protected override void OnClearInput()
        {
            while (inputPosition > 0)
            {
                inputField.text = inputField.text.Remove(inputPosition - 1);
                inputPosition--;
            }
            //Debug.Log("KeyboardListener: Set input field to " + inputField.text + ", adding " + value + " at caret position " + inputField.caretPosition);
        }
    }

}