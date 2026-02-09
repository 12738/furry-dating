using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueNode
{
    public string dialogueText;
    //public List<string> dialogueLines;
    public List<DialogueResponse> responses;

    // internal bool IsLastNode()
    // {
    //     return responses.Count <= 0;
    // }
}
