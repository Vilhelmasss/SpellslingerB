using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRuneInterface
{
    GameObject ExecuteAwake(GameObject go = null);
    GameObject ExecuteStart(GameObject go = null);
    GameObject ExecuteEnd(GameObject go = null);
    GameObject ExecuteAll(GameObject go = null);

}
