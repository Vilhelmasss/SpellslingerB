using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class CardFull : MonoBehaviour
{

    public int maxRunes;
    public int lockedRunes;
    public int usedRunes;
    public List<InvRuneData> runeList;
    public InvSpellData referenceSpell;
    public TextMeshProUGUI spellName;
    public List<GameObject> runeSlots = new List<GameObject>(6);
    public GameObject spellImage;

    public GameObject cardQuickview;

    void Start()
    {
        Time.timeScale = 0f;    
        if (cardQuickview != null)
        {
            runeList = cardQuickview.GetComponent<CardQuickview>().runeList;
        }
    }

    public void RemoveRune(int index)
    {
        if (index < lockedRunes - 1)
        {
            Debug.Log("This rune is locked");
            return;
        }
        if (index >= maxRunes)
        {
            Debug.Log("index out of boundaries");
            return;
        }
        
        runeList[index] = null;
        for (int i = index; i < maxRunes; i++)
        {
            if (runeList[i + 1] == null)
            {
                return;
            }

            runeList[i] = runeList[i + 1];
        }
        usedRunes--;

    }

    public void AdjustRuneIconsToObject()
    {
        for (int i = 0; i < 6; i++)
        {
            runeSlots[i].gameObject.GetComponent<Image>().color = Color.white;  
        }
        for (int i = maxRunes; i < 6 ; i++)
        {
            runeSlots[i].gameObject.GetComponent<Image>().color = Color.black;
        }
    }

    public void AdjustSpellToObject()
    {
        if (spellImage != null)
        {
            cardQuickview.GetComponent<CardQuickview>().spellImage = cardQuickview.GetComponent<CardQuickview>().spellImage;
        }
    }

    public void AdjustSpellName()
    {
        spellName.text = cardQuickview.GetComponent<CardQuickview>().referenceSpell.name;
    }   

    public void ReceiveCardData(GameObject _cardQuickview)
    {
        cardQuickview = _cardQuickview;
        maxRunes = cardQuickview.GetComponent<CardQuickview>().maxRunes;
        usedRunes = cardQuickview.GetComponent<CardQuickview>().usedRunes;
        referenceSpell = _cardQuickview.GetComponent<CardQuickview>().referenceSpell;
        AdjustRuneIconsToObject();
        AdjustSpellToObject();
        AdjustSpellName();
    }

    public void AddRunesToCard()
    {
        for (int i = 0; i < usedRunes; i++)
        {
            runeSlots[i].GetComponent<Image>().sprite = cardQuickview.GetComponent<CardQuickview>().runeImages[i].sprite;
        }
    }
}
