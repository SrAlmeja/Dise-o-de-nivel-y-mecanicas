using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "NightmareStuio/Variable/booleans")]
public class BooleanVariable : ScriptableObject
{
    public string Name;
    public bool Value;

    public void SetValue(bool value)
    {
        Value = value;
    }
}
