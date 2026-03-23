using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapNav : MonoBehaviour
{
    [SerializeReference] private GameObject map;
    [SerializeReference] private GameObject dialogueController;
    [SerializeReference] private List<GameObject> backgroundGO;
    [SerializeReference] private DayManager dayManager;
    //public List<Sprite> backgroundSprites;
    //private Image _background;

    void Start()
    {
        ForestSetup();
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
        backgroundGO[0].SetActive(true);
        backgroundGO[1].SetActive(false);
        backgroundGO[2].SetActive(false);
        foreach (NPC character in dayManager.characters)
        {
            character.prefab.SetActive(false);
            if (character.location == "Bar")
            {
                character.prefab.SetActive(true);
            }
        }
        // _background.tintColor = Color.black;
        // _background.sprite = backgroundSprites[0];
    }

    public void SchoolSetup()
    {
        map.SetActive(false);
        backgroundGO[0].SetActive(false);
        backgroundGO[1].SetActive(true);
        backgroundGO[2].SetActive(false);
        foreach (NPC character in dayManager.characters)
        {
            character.prefab.SetActive(false);
            if (character.location == "School")
            {
                character.prefab.SetActive(true);
            }
        }
        // _background.tintColor = Color.black;
        // _background.sprite = backgroundSprites[1];
    }

    public void ForestSetup()
    {
        map.SetActive(false);
        backgroundGO[0].SetActive(false);
        backgroundGO[1].SetActive(false);
        backgroundGO[2].SetActive(true);
        foreach (NPC character in dayManager.characters)
        {
            character.prefab.SetActive(false);
            if (character.location == "Forest")
            {
                character.prefab.SetActive(true);
            }
        }
        // _background.tintColor = Color.black;
        // _background.sprite = backgroundSprites[2];
    }
}
