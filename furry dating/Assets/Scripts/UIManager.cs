using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }
    
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void Next()
    {
        //start the next dialogue after this is pressed.
    }
}
