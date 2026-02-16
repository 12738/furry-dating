using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueStorage
{
    public string[] lines;
    public string[] responses;
    public int lineIndex = 0;
    public bool isQuestion;
    
}
