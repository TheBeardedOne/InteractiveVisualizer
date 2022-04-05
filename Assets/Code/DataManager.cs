using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
		 ////////////////////////////////////////////////////////////////////////////////

		 public void Start()
		 {
					// Populate button options
					PopulateModelButtonOptions();
					PopulateTextureButtonOptions();

					// Populate slider options
					PopulateGivenSliderOptionsIntoCategory(Resources.LoadAll<SliderOptionScriptableObject>("Options/SliderOptions/TransformOptions"), EOptionCategory.Transform);
					PopulateGivenSliderOptionsIntoCategory(Resources.LoadAll<SliderOptionScriptableObject>("Options/SliderOptions/LightingOptions"), EOptionCategory.Lights);
					PopulateGivenSliderOptionsIntoCategory(Resources.LoadAll<SliderOptionScriptableObject>("Options/SliderOptions/PostEffectsOptions"), EOptionCategory.Post);
					PopulateGivenSliderOptionsIntoCategory(Resources.LoadAll<SliderOptionScriptableObject>("Options/SliderOptions/CameraOptions"), EOptionCategory.Cam);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 private void PopulateModelButtonOptions()
		 {
					// Get the options data, and the options list they will go into.
					ModelButtonOptionScriptableObject[] foundButtons = Resources.LoadAll<ModelButtonOptionScriptableObject>("Options/ModelButtonOptions");
					GameObject targetOptionsList = MenuManager.instance.GetOptionsListGivenCategory(EOptionCategory.Model);

					GameObject newButton;
					// Populate the target list
					foreach (ModelButtonOptionScriptableObject buttonData in foundButtons)
					{
							 newButton = Instantiate(buttonData.m_OptionPrefab, targetOptionsList.transform);
							 newButton.GetComponent<ModelOptionButtonHelper>().ConstructButton(buttonData);
					}
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 private void PopulateTextureButtonOptions()
		 {
					// Get the options data, and the options list they will go into.
					MaterialButtonOptionScriptableObject[] foundButtons = Resources.LoadAll<MaterialButtonOptionScriptableObject>("Options/MaterialButtonOptions");
					GameObject targetOptionsList = MenuManager.instance.GetOptionsListGivenCategory(EOptionCategory.Textures);

					GameObject newButton;
					// Populate the target list
					foreach (MaterialButtonOptionScriptableObject buttonData in foundButtons)
					{
							 newButton = Instantiate(buttonData.m_OptionPrefab, targetOptionsList.transform);
							 newButton.GetComponent<MaterialOptionButtonHelper>().ConstructButton(buttonData);
					}
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 private void PopulateGivenSliderOptionsIntoCategory(SliderOptionScriptableObject[] optionsArr, EOptionCategory category)
		 {
					GameObject targetOptionsList = MenuManager.instance.GetOptionsListGivenCategory(category);
					GameObject newSlider;

					// Populate the target list
					foreach (SliderOptionScriptableObject option in optionsArr)
					{
							 newSlider = Instantiate(option.m_OptionPrefab, targetOptionsList.transform);
							 newSlider.GetComponent<SliderOptionHelper>().ConstructSlider(option);
					}
		 }
		 ////////////////////////////////////////////////////////////////////////////////
}
