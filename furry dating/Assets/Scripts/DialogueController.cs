using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private TextMeshProUGUI speakerParagraphs;
    //public GameObject[] buttons;
    public Transform buttonParent;
    public GameObject buttonPrefab;
    private Queue<string> paragraphs = new Queue<string>();

    private bool conversationEnded = false;
    private bool isTyping;

    private string p;

    private Coroutine typeDialogueCoroutine;

    private int typeSpeed = 20;

    private const string HTML_ALPHA = "<color=#00000000>";
    private const float MAX_TYPE_TIME = 0.1f;
    
    public void DisplayNext(DialogueText dialogue)
    {
        // foreach (GameObject button in buttons)
        // {
        //     button.SetActive(false);
        // }
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
                // check for responses
                if (dialogue.responses.Length != 0)
                {
                    foreach (Transform child in buttonParent)
                    {
                        Destroy(child.gameObject);
                    }
                    foreach(DialogueResponses response in dialogue.responses)
                    {
                        GameObject buttonObj = Instantiate(buttonPrefab, buttonParent);
                        buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;
                        buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response));
                    }
                    // for (int i = 0; i < buttons.Length; i++)
                    // {
                    //     buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialogue.responses[i].responseText;
                    //     buttons[i].gameObject.SetActive(true);
                    // }
                }
                else
                //end convo
                {
                    EndConversation();
                    return;
                }
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

    public void SelectResponse(DialogueResponses response)
    {
        if (response.nextDialogue != null)
        {
            DisplayNext(response.nextDialogue);
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
