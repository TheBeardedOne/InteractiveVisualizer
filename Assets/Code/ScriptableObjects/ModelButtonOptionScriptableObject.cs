using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ModelButtonOption", menuName = "ScriptableObjects/ModelButtonOption", order = 1)]
public class ModelButtonOptionScriptableObject : ButtonOptionScriptableObject
{
     public GameObject m_ModelPrefab;
     public UnityEvent<GameObject> m_ModelChangeEvent;

     public void InvokeEvent()
		 {
          m_ModelChangeEvent.Invoke(m_ModelPrefab);
		 }
}
