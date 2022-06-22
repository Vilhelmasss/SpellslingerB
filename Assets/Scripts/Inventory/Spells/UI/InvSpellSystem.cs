using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvSpellSystem : MonoBehaviour
{
    [SerializeField] private Dictionary<InvSpellData, InvSpell> m_spellDictionary;
    [SerializeField] private static InvSpellSystem _instance;
    [SerializeField] private GameObject spellBar;
    [SerializeField] private GameObject spellSlot;
    public List<InvSpell> inventory = new List<InvSpell>();
    public Dictionary<InvSpellData, GameObject> spellSlots;

    public static InvSpellSystem Instance
    {
        get
        {
            // create logic to create the instance
            if (_instance == null)
            {
                GameObject go = new GameObject("InvSpellSystem");
                go.AddComponent<InvSpellSystem>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        inventory = new List<InvSpell>();
        m_spellDictionary = new Dictionary<InvSpellData, InvSpell>();
        _instance = this;
        spellSlots = new Dictionary<InvSpellData, GameObject>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (InvSpell spell in inventory)
            {


            }
        }
    }


    public InvSpell Get(InvSpellData referenceData)
    {
        if (m_spellDictionary.TryGetValue(referenceData, out InvSpell value))
        {
            return value;
        }

        return null;
    }

    public void Add(InvSpellData referenceData)
    {
        if (m_spellDictionary.TryGetValue(referenceData, out InvSpell value))
        {
            value.AddToStack();
            spellSlots[referenceData].GetComponent<SpellSlot>().AdjustQuantity();
        }
        else
        {
            InvSpell newSpell = new InvSpell(referenceData);
            inventory.Add(newSpell);
            m_spellDictionary.Add(referenceData, newSpell);
            GameObject newSpellSlot = Instantiate(spellSlot, spellBar.transform);

            spellSlots.Add(referenceData, newSpellSlot);
            spellSlots[referenceData].gameObject.GetComponent<SpellSlot>().referenceData = referenceData;
            spellSlots[referenceData].GetComponent<SpellSlot>().AdjustQuantity();

            //          newSpellSlot.gameObject.GetComponent<SpellSlot>().spellNameText.text = newSpell.data.name;
            newSpellSlot.gameObject.GetComponent<SpellSlot>().spellNameText.text = m_spellDictionary[referenceData].data.name;
            newSpellSlot.gameObject.GetComponent<SpellSlot>().icon.sprite = m_spellDictionary[referenceData].data.icon;

        }
    }

    public void Remove(InvSpellData referenceData)
    {
        if (m_spellDictionary.TryGetValue(referenceData, out InvSpell value))
        {
            value.RemoveFromStack();

            if (value.stackSize == 0)
            {
                if (CardFull.Instance != null)
                {

                        inventory.Remove(value);
                        m_spellDictionary.Remove(referenceData);
                        Destroy(spellSlots[referenceData].gameObject);
                        spellSlots.Remove(referenceData);
                    
                }
            }
            else
            {
                spellSlots[referenceData].GetComponent<SpellSlot>().AdjustQuantity();

            }
        }
    }
}
