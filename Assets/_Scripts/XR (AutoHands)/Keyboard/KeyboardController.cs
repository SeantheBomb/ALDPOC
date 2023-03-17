using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Corrupted.Autohands
{

    public class KeyboardController : CorruptedBehaviour
    {

        public static System.Action<string> OnUpdateText;
        public static System.Action OnBackspace;
        public static System.Action OnClearText;

        [SerializeField]
        string inputValue;



        public void InputValue(string value)
        {
            inputValue = value;
            UpdateListeners();
        }

        [Button]
        public void UpdateListeners()
        {
            OnUpdateText?.Invoke(inputValue);
        }

        [Button]
        public void BackspaceListeners()
        {
            OnBackspace?.Invoke();
        }

        public void ClearTextListeners()
        {
            OnClearText?.Invoke();
        }

    }
}