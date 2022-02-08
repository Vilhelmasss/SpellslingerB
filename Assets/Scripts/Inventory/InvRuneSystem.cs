using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InvRuneSystem : MonoBehaviour
{
    [SerializeField]
    private Dictionary<InvRuneData, InvRune> m_runeDictionary;
    [SerializeField]
//    public List<InvRune> inventory { get; private set; }

    private float tTime = 0f;
    public List<InvRuneData> testItems = new List<InvRuneData>();
    public List<InvRune> inventory = new List<InvRune>();

    void Awake()
    {   
        inventory = new List<InvRune>();
        m_runeDictionary = new Dictionary<InvRuneData, InvRune>();
    }

    void Update()
    {
        tTime += Time.deltaTime;
        if (tTime >= 1)
        {
            tTime = 0;
            int rr = Random.Range(0, testItems.Count);
            Add(testItems[rr]);
        }

        foreach (InvRune rune in inventory)
        {
            Debug.Log($"RR {rune.data}  {rune.stackSize}");
            
        }
    }


    public InvRune Get(InvRuneData referenceData)
    {
        if (m_runeDictionary.TryGetValue(referenceData, out InvRune value))
        {
            return value;
        }

        return null;
    }

    public void Add(InvRuneData referenceData)
    {
        if (m_runeDictionary.TryGetValue(referenceData, out InvRune value))
        {
            value.AddToStack();
        }
        else
        {
            InvRune newRune = new InvRune(referenceData);
            inventory.Add(newRune);
            m_runeDictionary.Add(referenceData, newRune);
        }
    }

    public void Remove(InvRuneData referenceData)
    {
        if (m_runeDictionary.TryGetValue(referenceData, out InvRune value))
        {
            value.RemoveFromStack();
            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                m_runeDictionary.Remove(referenceData);
            }
        }
    }
}   
