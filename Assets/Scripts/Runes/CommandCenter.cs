using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCenter : MonoBehaviour
{
    public static CommandCenter Instance { get; set; }

    public Dictionary<string, IRuneInterface> AllRunes = new Dictionary<string, IRuneInterface>();
    
    public List<string> RuneBasicList;
    public List<string> RunePrimary;
    public List<string> RuneUtility;
    public List<string> RuneUltimate;
    public List<string> RuneDash;

    public List<IRuneInterface> RuneList = new List<IRuneInterface>();

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
        //        allRunes.Add("FasterProjectiles", ); 

    }

    public void AllRunesDictionary()
    {
        GameObject ms = new GameObject("Test");
        ms.AddComponent<MoreStacks>();
        
//        IRuneInterface slowerProjectile = new SlowerProjectile();
//        IRuneInterface moreDamage = new MoreDamage();
//        IRuneInterface longerLifespan = new LongerLifespan();     
//        IRuneInterface shorterLifeSpan = new ShorterLifespan();
//        IRuneInterface reduceManaCost = new ReduceManaCost();
//        IRuneInterface increaseManaCost = new IncreasedManaCost();
//        IRuneInterface increaseManaForDamage = new IncreasedManaForDamage();
//        IRuneInterface decreaseCooldown = new DecreaseCooldown();
//        IRuneInterface cooldownsForDamage = new IncreaseCooldownForDamage();
//        IRuneInterface lowerRecast = new LowerRecast();
//        IRuneInterface moreStacks = new MoreStacks();
//        IRuneInterface largerSize = new LargerSize();
//
        AllRunes.Add("MoreStacks", ms.GetComponent<MoreStacks>());
//        AllRunes.Add("SlowerProjectile", slowerProjectile);
//        AllRunes.Add("MoreDamage", moreDamage);
//        AllRunes.Add("LongerLifespan", longerLifespan);
//        AllRunes.Add("ShorterLifespan", shorterLifeSpan);
//        AllRunes.Add("ReduceManaCost", reduceManaCost);
//        AllRunes.Add("IncreaseManaCost", increaseManaCost);
//        AllRunes.Add("IncreaseManaForDamage", increaseManaForDamage);
//        AllRunes.Add("DecreaseCooldown", decreaseCooldown);
//        AllRunes.Add("IncreaseCooldownForDamage", cooldownsForDamage);
//        AllRunes.Add("LowerRecast", lowerRecast);
//        AllRunes.Add("MoreStacks", moreStacks);
//        AllRunes.Add("LargerSize", largerSize);
//        AllRunes.Add("FasterProjectiles", );
    }

    public GameObject Execute(string dictionaryKeyword, GameObject go)
    {
        return AllRunes[dictionaryKeyword].ExecuteAwake(go);
    }


}
