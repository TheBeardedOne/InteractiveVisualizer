using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MaterialButtonObject", menuName = "VisualizerOption/MaterialButtonObject", order = 2)]
public class MaterialButtonOptionScriptableObject : ButtonOptionScriptableObject
{
     public Material m_OptionMaterial;
     public UnityEvent<MaterialButtonOptionScriptableObject> m_MaterialChangeEvent;
}
