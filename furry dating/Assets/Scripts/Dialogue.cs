using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string characterName;
    public DialogueStorage[] dialogueLines;
    public int dialogueIndex = 0;
    public int responseIndex = 0;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI name;
    public GameObject dialogueBox;
    [SerializeReference] private GameObject nextButton;
    [SerializeReference] private GameObject[] buttonResponse;
    
    
    private void Start()
    {
        name.text = characterName;
        textBox.text = dialogueLines[dialogueIndex].lines[dialogueLines[dialogueIndex].lineIndex];
    }
    
    /*
     * When next button is pushed, switch to next dialogue.
     * Should be able to check when the player will need to respond to a dialogue.
     * Depending on the response, display appropriate text.
    */
    public void ProceedText()
    {
        if (dialogueLines[dialogueIndex].isQuestion)
        {
            if (dialogueLines[dialogueIndex].lineIndex + 1 == dialogueLines[dialogueIndex].lines.Length)
            {
                nextButton.SetActive(false);
                foreach (GameObject button in buttonResponse)
                {
                    button.GetComponentInChildren<TextMeshProUGUI>().text = dialogueLines[dialogueIndex].responses[responseIndex];
                    button.gameObject.SetActive(true);
                    responseIndex++;
                }
                responseIndex = 0;
            }
            else
            {
                dialogueLines[dialogueIndex].lineIndex++;
                textBox.text = dialogueLines[dialogueIndex].lines[dialogueLines[dialogueIndex].lineIndex];
            }
        }
        else if (dialogueLines[dialogueIndex].lineIndex + 1 == dialogueLines[dialogueIndex].lines.Length)
        {
            nextButton.SetActive(true);
            textBox.text = dialogueLines[dialogueIndex].lines[dialogueLines[dialogueIndex].lineIndex];
            dialogueLines[dialogueIndex].lineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void SelectResponse1()
    {
        dialogueIndex += 1;
        foreach (GameObject button in buttonResponse)
        {
            button.SetActive(false);
        }
        ProceedText();
    }

    public void SelectResponse2()
    {
        dialogueIndex += 2;
        foreach (GameObject button in buttonResponse)
        {
            button.SetActive(false);
        }
        ProceedText();
    }

    public void SelectResponse3()
    {
        dialogueIndex += 3;
        foreach (GameObject button in buttonResponse)
        {
            button.SetActive(false);
        }
        ProceedText();
    }
    
    /*
     * When there is no dialogue left to read, end the dialogue.
     */
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

}
