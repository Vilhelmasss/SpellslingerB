using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuneStack : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private TextMeshProUGUI m_label;
    [SerializeField] private GameObject m_stackObj;
    [SerializeField] private TextMeshProUGUI m_stackLabel;

    public void Set(InvRune rune)
    {
        m_icon.sprite = rune.data.icon;
        m_label.text = rune.data.displayName;
        if (rune.stackSize <= 1)
        {
            m_stackObj.SetActive(false);
            return;
        }

        m_label.text = rune.stackSize.ToString();

    }

}
