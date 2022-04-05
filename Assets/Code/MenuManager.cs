using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// The MenuManager manages events related to overall menu navigation
/// </summary>
public class MenuManager : MonoBehaviour
{
		 public static MenuManager instance;

		 public UnityEvent m_ModelButtonPressedEvent;
		 public UnityEvent m_TransformButtonPressedEvent;
		 public UnityEvent m_TexturesButtonPressedEvent;
		 public UnityEvent m_LightingButtonPressedEvent;
		 public UnityEvent m_PostEffectsButtonPressedEvent;
		 public UnityEvent m_CameraButtonPressedEvent;
		 public UnityEvent<Animation> m_ToggleOptionsUIPressedEvent;


		 [SerializeField] private GameObject[] m_OptionsListsGameObjects;
		 [SerializeField] private GameObject m_CameraInputEnabledIndicator;
		 [SerializeField] private GameObject m_CameraInputDisabledIndicator;
		 [SerializeField] private ScrollRect m_ScrollRect;

		 private bool m_MenuOpen = false;

		 ////////////////////////////////////////////////////////////////////////////////

		 private void Awake()
		 {
					if (instance == null)
							 instance = this;
					else
							 Destroy(this);

					m_ToggleOptionsUIPressedEvent.AddListener(OnToggleOptionsUI);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 private void OnToggleOptionsUI(Animation anim)
		 {
					if (m_MenuOpen)
							 anim.Play("OptionsIn");
					else
							 anim.Play("OptionsOut");

					m_MenuOpen = !m_MenuOpen;

					m_CameraInputDisabledIndicator.SetActive(m_MenuOpen);
					m_CameraInputEnabledIndicator.SetActive(!m_MenuOpen);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickModelButton()
		 {
					CloseAllOptionsLists();
					m_ModelButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickTransformButton()
		 {
					CloseAllOptionsLists();
					m_TransformButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickTexturesButton()
		 {
					CloseAllOptionsLists();
					m_TexturesButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickLightingButton()
		 {
					CloseAllOptionsLists();
					m_LightingButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickPostEffectsButton()
		 {
					CloseAllOptionsLists();
					m_PostEffectsButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickCameraButton()
		 {
					CloseAllOptionsLists();
					m_CameraButtonPressedEvent.Invoke();
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void OnClickToggleUIButton(Animation anim)
		 {
					m_ToggleOptionsUIPressedEvent.Invoke(anim);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void CloseAllOptionsLists()
		 {
					// Disable all options lists
					foreach (GameObject optionsList in m_OptionsListsGameObjects)
					{
							 optionsList.SetActive(false);
					}
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public bool IsMenuOpen()
		 {
					return m_MenuOpen;
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public GameObject GetOptionsListGivenCategory(EOptionCategory category)
		 {
					return m_OptionsListsGameObjects[((int)category)];
		 }
}
