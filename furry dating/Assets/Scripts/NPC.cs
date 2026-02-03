using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IInteractable
{
    private void Start()
    {
        Interact();
    }
    public abstract void Interact();
}
