using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellSlot : MonoBehaviour
{
    public InvSpellData referenceData;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI spellNameText;
    public Image icon;

    public void AdjustQuantity()
    {
        quantityText.text = InvSpellSystem.Instance.Get(referenceData).stackSize.ToString();
    }

    public void RemoveSelf()
    {
        InvSpellSystem.Instance.Remove(referenceData);
    }

}
