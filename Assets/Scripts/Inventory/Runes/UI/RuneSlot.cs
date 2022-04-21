using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuneSlot : MonoBehaviour
{
    public InvRuneData referenceData;
    public TextMeshProUGUI quantityText;
    public TextMeshProUGUI runeNameText;
    public Image icon;

    public void AdjustQuantity()
    {
        quantityText.text = InvRuneSystem.Instance.Get(referenceData).stackSize.ToString();
    }

    public void RemoveSelf()
    {
        InvRuneSystem.Instance.Remove(referenceData);
    }

}
