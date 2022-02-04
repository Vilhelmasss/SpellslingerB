using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvRuneSystem : MonoBehaviour
{
    private Dictionary<InvRuneData, InvRune> m_itemDictionary;
    public List<InvRune> inventory { get; private set; }

    void Awake()
    {
        inventory = new List<InvRune>();
        m_itemDictionary = new Dictionary<InvRuneData, InvRune>();
    }

    public void Add(InvRuneData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InvRune value))
        {
            value.AddToStack();
        }
        else
        {
            InvRune newRune = new InvRune(referenceData);
            inventory.Add(newRune);
            m_itemDictionary.Add(referenceData, newRune);
        }
    }
}   
