using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvRuneSystem : MonoBehaviour
{
    [SerializeField] private Dictionary<InvRuneData, InvRune> m_runeDictionary;
    [SerializeField] private static InvRuneSystem _instance;
    [SerializeField] private GameObject runeBar;
    [SerializeField] private GameObject runeSlot;
    public List<InvRune> inventory = new List<InvRune>();
    public Dictionary<InvRuneData, GameObject> runeSlots;
        
    public static InvRuneSystem Instance
    {
        get
        {
            // create logic to create the instance
            if (_instance == null)
            {
                GameObject go = new GameObject("InvRuneSystem");
                go.AddComponent<InvRuneSystem>();
            }

            return _instance;
        }
    }
    void Awake()
    {   
        inventory = new List<InvRune>();
        m_runeDictionary = new Dictionary<InvRuneData, InvRune>();
        _instance = this;
        runeSlots = new Dictionary<InvRuneData, GameObject>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Got to InvRuneSystem Update Space");
            foreach (InvRune rune in inventory)
            {
                Debug.Log($"RR {rune.data.description}");


            }
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
            runeSlots[referenceData].GetComponent<RuneSlot>().AdjustQuantity();
        }
        else
        {
            InvRune newRune = new InvRune(referenceData);
            inventory.Add(newRune);
            m_runeDictionary.Add(referenceData, newRune);
            GameObject newRuneSlot = Instantiate(runeSlot, runeBar.transform);

            runeSlots.Add(referenceData, newRuneSlot);
            runeSlots[referenceData].gameObject.GetComponent<RuneSlot>().referenceData = referenceData;
            runeSlots[referenceData].GetComponent<RuneSlot>().AdjustQuantity();
            
            newRuneSlot.gameObject.GetComponent<RuneSlot>().runeNameText.text = m_runeDictionary[referenceData].data.name;
            newRuneSlot.gameObject.GetComponent<RuneSlot>().icon.sprite = m_runeDictionary[referenceData].data.icon;
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
                Destroy(runeSlots[referenceData].gameObject);

                runeSlots.Remove(referenceData);
            }
            else
            {
                runeSlots[referenceData].GetComponent<RuneSlot>().AdjustQuantity();

            }
        }
    }
}   
