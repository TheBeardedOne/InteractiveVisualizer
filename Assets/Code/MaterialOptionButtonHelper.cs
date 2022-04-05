using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This helper class assists in translating the scriptable object data onto the newly created option.
/// The helper also invokes the assigned event when it is interacted with.
/// </summary>
public class MaterialOptionButtonHelper : MonoBehaviour
{
     [SerializeField] private Button m_OptionButton;
     [SerializeField] private RawImage m_OptionImage;
     [SerializeField] private TextMeshProUGUI m_OptionTitle;
		 private MaterialButtonOptionScriptableObject m_OptionData;

     public void ConstructButton(MaterialButtonOptionScriptableObject newData)
		 {
          
          m_OptionImage.texture = newData.m_ButtonImage;
          m_OptionTitle.text = newData.m_OptionName;
          m_OptionData = newData;
          m_OptionButton.onClick.AddListener(OnButtonClicked);
     }

     public void OnButtonClicked()
		 {
          m_OptionData.m_MaterialChangeEvent.Invoke(m_OptionData);
		 }
}
