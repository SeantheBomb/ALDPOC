using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Corrupted.Autohands
{

    public class KeyboardBackspaceButton : KeyboardButton
    {
        //public StringVariable inputValue;

        //TMP_Text text;
        //TMP_Text Text
        //{
        //    get
        //    {
        //        if (text == null)
        //            text = GetComponentInChildren<TMP_Text>();
        //        return text;
        //    }
        //}

        protected override void OnKeyPressed()
        {
            Parent.BackspaceListeners();
        }

        private void OnValidate()
        {
            //Text.text = inputValue;
            gameObject.name = $"Keyboard Backspace Button";
        }
    }
}