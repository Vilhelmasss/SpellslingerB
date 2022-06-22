using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class CardFull : MonoBehaviour
{

    public static CardFull Instance { get; set; }

    public int maxRunes;
    public int lockedRunes;
    public int usedRunes;
    public InvSpellData referenceSpell;
    public TextMeshProUGUI spellName;
    public List<GameObject> runeSlots = new List<GameObject>(6);
    public GameObject spellImage;
    public Sprite background;
    public CardQuickview CardQuickview;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 0;
    }

    public void RemoveRune(int index)
    {
        Debug.Log($"index: {index} lockedRunes-1: {CardQuickview.lockedRunes-1}");
        if (index < CardQuickview.lockedRunes)
        {
            Debug.Log("This rune is locked");
            return;
        }
        if (index >= CardQuickview.maxRunes)
        {
            Debug.Log("index out of boundaries");
            return;
        }
        if (CardQuickview.runeList[index] == null)
        {
            return;
        }
        InvRuneSystem.Instance.Add(CardQuickview.runeList[index]);
        CardQuickview.runeList[index] = null;
        CardQuickview.runeImages[index].sprite = background;
        CardQuickview.usedRunes--;
        for (int i = index; i < CardQuickview.maxRunes; i++)
        {

            if (CardQuickview.runeList[i + 1] == null)
            {
                break;
            }
            CardQuickview.runeList[i] = CardQuickview.runeList[i + 1];
            CardQuickview.runeList[i + 1] = null;
        }   
        CardQuickview.AdjustRuneIcons();
        ReceiveCardData(CardQuickview);
    }


    public void AdjustRuneIconsToColors()
    {
        for (int i = 0; i < 6; i++)
        {
            Debug.Log("background");
            runeSlots[i].gameObject.GetComponent<Image>().sprite = background;
            runeSlots[i].gameObject.GetComponent<Image>().color = Color.white;  
        }
        for (int i = CardQuickview.maxRunes; i < 6 ; i++)
        {
            runeSlots[i].gameObject.GetComponent<Image>().color = Color.black;
        }
        for (int i = 0; i < CardQuickview.maxRunes; i++)
        {
            runeSlots[i].GetComponent<Image>().sprite = CardQuickview.runeImages[i].sprite;
        }
    }

    public void AdjustSpellToObject()
    {   
        if (spellImage != null)
        {
            spellImage = CardQuickview.spellImage;
        }
    }

    public void AdjustSpellName()
    {
        spellName.text = CardQuickview.referenceSpell.displayName;
    }


    public void ReceiveCardData(CardQuickview _cardQuickview)
    {
        CardQuickview = _cardQuickview;
        AdjustRuneIconsToColors();
        AdjustSpellToObject();
        AdjustSpellName();
        AddRunesToCard();
    }

    public void AddRunesToCard()
    {
        for (int i = 0; i < usedRunes; i++)
        {
            runeSlots[i].GetComponent<Image>().sprite = CardQuickview.runeImages[i].sprite;
        }
    }
}
