using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI speakerParagraphs;
    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded = false;
    private bool isTyping;

    private string p;

    private Coroutine typeDialogueCoroutine;

    private int typeSpeed = 20;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;
    
    public void DisplayNextParagraph(DialogueText dialogue)
    {
        //if nothing is in queue
        if (paragraphs.Count == 0)
        {
            if (!conversationEnded)
            {
                //start convo
                StartConversation(dialogue);
            }
            else if (conversationEnded && !isTyping)
            {
                //end convo
                EndConversation();
                return;
            }
        }
        //if something is in your queue
        if (!isTyping)
        {
            p = paragraphs.Dequeue();
            typeDialogueCoroutine = StartCoroutine(TypeDialogueText(p));
        }
        else
        {
            FinishParagraphEarly();
        }
        
        //update convo
        speakerParagraphs.text = p;

        if (paragraphs.Count == 0)
        {
            conversationEnded = true;
        }
    }
    
    private void StartConversation(DialogueText dialogue)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        
        //update name
        speakerName.text = dialogue.speakerName;
        //add dialogue to queue
        for (int i = 0; i < dialogue.paragraphs.Length; i++)
        {
            paragraphs.Enqueue(dialogue.paragraphs[i]);
        }
    }

    private void EndConversation()
    {
        //clear queue
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;
        
        speakerParagraphs.text = "";
        string originalText = p;
        string displayedText = "";
        int alphaIndex = 0;

        foreach (char c in p.ToCharArray())
        {
            alphaIndex++;
            speakerParagraphs.text = originalText;
            
            displayedText = speakerParagraphs.text.Insert(alphaIndex, HTML_ALPHA);
            speakerParagraphs.text = displayedText;
            
            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }
        
        isTyping = false;
    }

    private void FinishParagraphEarly()
    {
        //stop coroutine
        StopCoroutine(typeDialogueCoroutine);
        
        //finish displaying text
        speakerParagraphs.text = p;
        
        //update isTyping bool
        isTyping = false;
    }
}
