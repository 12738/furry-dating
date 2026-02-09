using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public new string name;
    public Dialogue dialogue;

    private void Start()
    {
        SpeakTo();
    }
    
    //Triggers Dialogue
    public void SpeakTo()
    {
        DialogueController.Instance.StartDialogue(name, dialogue.rootNode);
    }
}
