using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderOptionHelper : MonoBehaviour
{
		 [SerializeField] private Slider m_OptionSlider;
		 [SerializeField] private TextMeshProUGUI m_OptionTitle;
		 private SliderOptionScriptableObject m_OptionData;


		 public void ConstructSlider(SliderOptionScriptableObject newData)
		 {					
					m_OptionTitle.text = newData.m_OptionName;
					m_OptionData = newData;
					m_OptionSlider.maxValue = newData.m_MaximumValue;
					m_OptionSlider.minValue = newData.m_MinimumValue;
					m_OptionSlider.wholeNumbers = newData.m_UseWholeNumbers;
					newData.m_InitializingEvent.Invoke(this);
					m_OptionSlider.onValueChanged.AddListener(OnSliderChanged);
		 }

		 public void OnSliderChanged(float value)
		 {
					m_OptionData.m_SliderEvent.Invoke(value);
		 }

		 public void InitializeStartingValue(float value)
		 {
					m_OptionSlider.value = value;
		 }
}
