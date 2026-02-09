using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _optionsPanel;
    
    public void OpenOptions()
    {
        _optionsPanel.SetActive(true);
    }
    
    public void CloseOptions()
    {
        _optionsPanel.SetActive(false);
    }
}
