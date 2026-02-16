using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string characterName;
    public DialogueStorage[] linesTest;
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
        textBox.text = linesTest[dialogueIndex].lines[linesTest[dialogueIndex].lineIndex];
    }
    
    /*
     * When next button is pushed, switch to next dialogue.
     * Should be able to check when the player will need to respond to a dialogue.
     * Depending on the response, display appropriate text.
    */
    public void ProceedText()
    {
        if (linesTest[dialogueIndex].isQuestion)
        {
            if (linesTest[dialogueIndex].lineIndex + 1 == linesTest[dialogueIndex].lines.Length)
            {
                nextButton.SetActive(false);
                foreach (GameObject button in buttonResponse)
                {
                    button.GetComponentInChildren<TextMeshProUGUI>().text = linesTest[dialogueIndex].responses[responseIndex];
                    button.gameObject.SetActive(true);
                    responseIndex++;
                }
                responseIndex = 0;
            }
            else
            {
                linesTest[dialogueIndex].lineIndex++;
                textBox.text = linesTest[dialogueIndex].lines[linesTest[dialogueIndex].lineIndex];
            }
        }
        else
        {
            EndDialogue();
        }
    }
    
    /*
     * When there is no dialogue left to read, end the dialogue.
     */
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }

}
