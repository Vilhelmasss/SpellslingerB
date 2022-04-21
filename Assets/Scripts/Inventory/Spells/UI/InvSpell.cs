using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InvSpell
{
    public InvSpellData data { get; private set; }
    public int stackSize { get; private set; }

    public InvSpell(InvSpellData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()   
    {
        stackSize--;
    }


}