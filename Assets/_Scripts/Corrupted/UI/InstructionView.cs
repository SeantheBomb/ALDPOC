using Corrupted;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionView : CorruptedBehaviour<InstructionView>
{

    public TMP_Text text;

    public void SetText(string text)
    {
        this.text.text = text;
    }



}
