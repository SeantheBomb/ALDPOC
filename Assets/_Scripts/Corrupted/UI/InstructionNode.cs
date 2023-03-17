using Corrupted;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[NodeWidth(200), NodeTint(102, 0, 102), CreateNodeMenu("UI/Instruction")]
public class InstructionNode : GraphNode
{

    public KeyVariable viewKey;
    public FloatVariable delay;
    public StringVariable text;

    public override IEnumerator PlayNode(SequenceSystemManager director)
    {
        InstructionView.GetInstance(viewKey).SetText(text);
        yield return new WaitForSeconds(delay);
        PlayNextInPath(director);
    }
}
