using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Spell Data")]

public class InvSpellData : ScriptableObject
{
    public string id;
    public string displayName;
    public string description;
    public int tier;
    public Sprite icon;
    public Sprite iconBar;
    public GameObject prefab;
    public List<string> tags;
}
