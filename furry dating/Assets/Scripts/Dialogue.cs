using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text dialogueText;
    public List<string> dialogueLines = new List<string>(20);
    public int currentLine;
    void Start()
    {
        dialogueText.text = "Hi if you're reading this text works!";
    }

    void Update()
    {
        
    }
}
