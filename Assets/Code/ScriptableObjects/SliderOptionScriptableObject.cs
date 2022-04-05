using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SliderOption", menuName = "ScriptableObjects/SliderOption", order = 1)]
public class SliderOptionScriptableObject : OptionsScriptableObject
{
		 public float m_MinimumValue;
		 public float m_MaximumValue;
		 public bool m_UseWholeNumbers;

		 public UnityEvent<SliderOptionHelper> m_InitializingEvent; // Having an initializing event allows the developer to modify in-editor values without having to manually return to the option
		 public UnityEvent<float> m_SliderEvent;
}
