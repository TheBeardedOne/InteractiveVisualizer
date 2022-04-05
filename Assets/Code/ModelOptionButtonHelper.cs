using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ModelOptionButtonHelper : MonoBehaviour
{
     [SerializeField] private Button m_OptionButton;
     [SerializeField] private RawImage m_OptionImage;
     [SerializeField] private TextMeshProUGUI m_OptionTitle;
     private ModelButtonOptionScriptableObject m_OptionData;

     public void ConstructButton(ModelButtonOptionScriptableObject newData)
     {          
          m_OptionImage.texture = newData.m_ButtonImage;
          m_OptionTitle.text = newData.m_OptionName;
          m_OptionData = newData;
          m_OptionImage.texture = AssetPreview.GetAssetPreview(newData.m_ModelPrefab);
          m_OptionButton.onClick.AddListener(OnButtonClicked);
     }

     public void OnButtonClicked()
     {
          m_OptionData.InvokeEvent();
     }
}
