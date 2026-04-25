using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public int day;
    public int timeOfDay;
    public List<NPC> characters  = new List<NPC>();

    /* checks if a character is assigned to an area depending on the day and time
        Needs at least a few steps:
        
        for each character in characters, assign a place they will be. For now this can be random,
        but it would be better if later on they had likelihoods and preferences on locations.
        When location is assigned, place that information in the NPC script.
        
        when the map loads a new scene, check for each character that was assigned to that area
        and make them active. THIS CAN BE DONE IN THE MAP SCRIPT!
        
        (I think in the future it would be better to instantiate these!)
        
        This may also alter depending on the time of day, so after you spend time with someone,
        you will move onto the next time period and the locations will change.
     
     */

    private void Awake()
    {
        AreaCheck();
    }
    
    public void AreaCheck()
    {
        foreach (NPC character in characters)
        {
            /*
             * float areaChance = UnityEngine.Random.Range(0f, 1f);
             * switch(character.name)
             * {
             *      case "Leah":
             *      if (timeOfDay == 0)
             * {
             *      if (areaChance <= .1f)
             *  {
             *      character.location = "Forest";
             *  }else if (areaChance <= .3f)
             *  {
             *      character.location = "School";
             *  }else if (areaChance <= 1f)
             *  {
             *      character.location = "Bar";
             *  }
             * }
             *      else if (timeOfDay == 1)
             * {
             *      if (areaChance <= .1f)
             *  {
             *      character.location = "Forest";
             *  }else if (areaChance <= .3f)
             *  {
             *      character.location = "School";
             *  }else if (areaChance <= 1f)
             *  {
             *      character.location = "Bar";
             *  }
             *      else if (timeOfDay == 2)
             * {
             *      if (areaChance <= .1f)
             *  {
             *      character.location = "Forest";
             *  }else if (areaChance <= .3f)
             *  {
             *      character.location = "School";
             *  }else if (areaChance <= 1f)
             *  {
             *      character.location = "Bar";
             *  }
             * }
             */
            float areaChance = UnityEngine.Random.Range(0f, 1f);
            if (areaChance <= .3f)
            {
                character.location = "Forest";
            }else if (areaChance <= .6f)
            {
                character.location = "School";
            }else if (areaChance <= 1f)
            {
                character.location = "Bar";
            }
        }
    }
}
