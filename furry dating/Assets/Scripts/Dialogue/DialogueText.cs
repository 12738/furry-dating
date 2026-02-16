using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject
{
    [Range(0, 2)] public int SpriteIndex;
    public string speakerName;
    [TextArea(5, 10)]
    public string[] paragraphs;

    public List<DialogueResponses> responses;
}
