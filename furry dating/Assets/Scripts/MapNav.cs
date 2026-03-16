using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapNav : MonoBehaviour
{
    [SerializeReference] private GameObject map;
    [SerializeReference] private GameObject dialogueController;
    [SerializeReference] private GameObject backgroundGO;
    public Image background;

    void Awake()
    {
        background = backgroundGO.GetComponent<Image>();
    }

    public void OpenMap()
    {
        map.SetActive(true);
    }

    public void CloseMap()
    {
        map.SetActive(false);
    }

    public void TransportToLocation(GameObject location)
    {
        switch (location.name)
        {
            case "Bar":
                BarSetup();
                break;
            case "School":
                SchoolSetup();
                break;
            case "Forest":
                ForestSetup();
                break;
        }
    }

    public void BarSetup()
    {
        map.SetActive(false);
        background.tintColor = Color.black;
        
    }

    public void SchoolSetup()
    {
        map.SetActive(false);
    }

    public void ForestSetup()
    {
        map.SetActive(false);
    }
}
