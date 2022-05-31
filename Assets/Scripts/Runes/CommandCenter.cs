using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    public static CommandCenter Instance { get; private set; }


    public Dictionary<string, IRuneInterface> AllRunes = new Dictionary<string, IRuneInterface>();
    
    public List<string> RuneBasicList;
    public List<string> RunePrimary;
    public List<string> RuneUtility;
    public List<string> RuneUltimate;
    public List<string> RuneDash;

    public List<string> RuneList = new List<string>();

    private List<GameObject> runeGameObjects = new List<GameObject>();
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
        AllRunesDictionary();

    }


    public void RuneStringList()
    {
        RuneList.Add("SlowerProjectile");
        RuneList.Add("FasterProjectile");
        RuneList.Add("MoreDamage");
        RuneList.Add("LongerLifespan");
        RuneList.Add("ShorterLifespan");
        RuneList.Add("ReduceManaCost");
        RuneList.Add("IncreaseManaCost");
        RuneList.Add("IncreaseManaForDamage");
        RuneList.Add("DecreaseCooldown");
        RuneList.Add("IncreaseCooldownForDamage");
        RuneList.Add("LowerRecast");
        RuneList.Add("MoreStacks");
        RuneList.Add("LargerSize");


    }

    public void AllRunesDictionary()
    {

        GameObject temp = new GameObject();

        temp.AddComponent<SlowerProjectile>();
        temp.AddComponent<FasterProjectile>();
        temp.AddComponent<MoreDamage>();
        temp.AddComponent<LongerLifespan>();
        temp.AddComponent<ShorterLifespan>();
        temp.AddComponent<ReduceManaCost>();
        temp.AddComponent<IncreasedManaCost>();
        temp.AddComponent<IncreasedManaForDamage>();
        temp.AddComponent<DecreaseCooldown>();
        temp.AddComponent<IncreaseCooldownForDamage>();
        temp.AddComponent<LowerRecast>();
        temp.AddComponent<MoreStacks>();
        temp.AddComponent<LargerSize>();


        AllRunes.Add("SlowerProjectile", temp.GetComponent<SlowerProjectile>());
        AllRunes.Add("FasterProjectile", temp.GetComponent<FasterProjectile>());
        AllRunes.Add("MoreDamage", temp.GetComponent<MoreDamage>());
        AllRunes.Add("LongerLifespan", temp.GetComponent<LongerLifespan>());
        AllRunes.Add("ShorterLifespan", temp.GetComponent<ShorterLifespan>());
        AllRunes.Add("ReduceManaCost", temp.GetComponent<ReduceManaCost>());
        AllRunes.Add("IncreaseManaCost", temp.GetComponent<IncreasedManaCost>());
        AllRunes.Add("IncreaseManaForDamage", temp.GetComponent<IncreasedManaForDamage>());
        AllRunes.Add("DecreaseCooldown", temp.GetComponent<DecreaseCooldown>());
        AllRunes.Add("IncreaseCooldownForDamage", temp.GetComponent<IncreaseCooldownForDamage>());
        AllRunes.Add("LowerRecast", temp.GetComponent<LowerRecast>());
        AllRunes.Add("MoreStacks", temp.GetComponent<MoreStacks>());
        AllRunes.Add("LargerSize", temp.GetComponent<LargerSize>());

    }

    private void AddRune(string dKey)
    {

    }


    public GameObject ExecuteAwake(string dictionaryKeyword, GameObject go)
    {
        return AllRunes[dictionaryKeyword].ExecuteAwake(go);
    }


}
