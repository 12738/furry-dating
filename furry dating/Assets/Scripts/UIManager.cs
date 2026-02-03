using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    [SerializeField] private Fennec _fennecNPC;
    
    public void OpenOptions()
    {
        _optionsPanel.SetActive(true);
    }
    
    public void CloseOptions()
    {
        _optionsPanel.SetActive(false);
    }

    public void Next()
    {
        _fennecNPC.Interact();
    }
}
