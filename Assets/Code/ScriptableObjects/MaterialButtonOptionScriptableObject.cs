using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MaterialButtonObject", menuName = "ScriptableObjects/MaterialButtonObject", order = 1)]
public class MaterialButtonOptionScriptableObject : ButtonOptionScriptableObject
{
     public Material m_OptionMaterial;
     public UnityEvent<MaterialButtonOptionScriptableObject> m_MaterialChangeEvent;
}
