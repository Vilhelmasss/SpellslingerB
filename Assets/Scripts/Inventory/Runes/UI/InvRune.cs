using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class InvRune 
{
    public InvRuneData data { get; private set; }
    public int stackSize { get; private set; }

    public InvRune(InvRuneData source)
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