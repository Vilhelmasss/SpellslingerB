using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardQuickview : MonoBehaviour
{
    public int maxRunes;
    public int lockedRunes;
    public int usedRunes;
    public List<InvRuneData> runeList;
    public InvSpellData referenceSpell;

    public List<Image> runeImages;
    public GameObject spellImage;
    public GameObject fullCard;

    public TextMeshProUGUI usedRunesText;
    public TextMeshProUGUI maxRunesText;


    void Start()
    {
        usedRunesText.text = usedRunes.ToString();
        maxRunesText.text = maxRunes.ToString();
        AdjustRuneIcons();
        SetClosedSlots();
        SendToFullCard();
    }

    public void AdjustRuneIcons()
    {
        for (int i = 0; i < maxRunes; i++)
        {
            if (runeList[i] != null)
            {
                runeImages[i].sprite = runeList[i].icon;
            }
            else
            {
                runeImages[i].sprite = null;
            }
        }
    }

    private void SetClosedSlots()
    {
        for (int i = maxRunes; i < 6; i++)
        {
            runeImages[i].color = Color.black;
        }
    }

    public void SendToFullCard()
    {
        fullCard = GetComponentInParent<FullCardLink>().fullCard;
        fullCard.GetComponentInChildren<CardFull>().cardQuickview = this.gameObject;
        fullCard.GetComponent<CardFull>().ReceiveCardData(this.gameObject);
    }


}
