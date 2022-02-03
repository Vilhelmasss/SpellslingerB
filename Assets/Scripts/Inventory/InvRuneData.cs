using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Rune Data")]
public class InvRuneData : ScriptableObject
{
    public string id;
    public string displayName;
    public string description;
    public int tier;
    public Sprite icon;
    public GameObject prefab;
    public List<string> tags;
}
