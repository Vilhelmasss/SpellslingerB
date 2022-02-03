using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Rune Data")]

public class InvItemData : ScriptableObject
{
    public string id;
    public string displayName;
    public string description;
    public int totalSlots;
    public int lockedSlots;
    public int tier;
    public Sprite icon;
    public Sprite iconBar;
    public GameObject prefab;
    public List<string> tags;
}
