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
        

    public List<string> ConflictingTags(List<string> otherTags)
    {
        List<string> conflictingTags = new List<string>();
        foreach (string runeTag in tags)
        {
            foreach (string otherTag in otherTags)
            {
                if (runeTag == otherTag)
                {
                    conflictingTags.Add(runeTag);
                }
            }
        }

        return conflictingTags;
    }

    public override string ToString()
    {
        return $"{id} {displayName} {tier} {tags}";
    }
}
