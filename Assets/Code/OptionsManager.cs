using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Cinemachine;

/// <summary>
/// The options manager manages all options across all categories. Most of its methods are static, so that they can be used for Unity Events on the options scriptable objects.
/// </summary>
public class OptionsManager : MonoBehaviour
{
		 public static OptionsManager instance;

		 [SerializeField] private Volume m_PostVolume;
		 [SerializeField] private Transform m_SpawnPosition;
		 [SerializeField] private Light m_DirectionalLight;
		 [SerializeField] private Light m_KeyLight;
		 [SerializeField] private Light m_FillLight;
		 [SerializeField] private Light m_BackLight;
		 [SerializeField] private GameObject m_CurrentModel;
		 [SerializeField] private CinemachineFreeLook m_CinemachineRef;

		 // Post-Processing Effects
		 private FilmGrain m_FilmGrain;
		 private Bloom m_Bloom;
		 private ChromaticAberration m_ChromaticAberration;
		 private ColorAdjustments m_ColorAdjustments;
		 private LensDistortion m_LensDistortion;
		 private MotionBlur m_MotionBlur;
		 
		 ////////////////////////////////////////////////////////////////////////////////		 
		 
		 private void Awake()
		 {
					if (instance == null)
							 instance = this;
					else
							 Destroy(this);

					m_CinemachineRef = Camera.main.GetComponent<CinemachineFreeLook>();					
					InitializePostProcessingEffectsReferences();					
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public void InitializePostProcessingEffectsReferences()
		 {
					m_PostVolume.profile.TryGet<FilmGrain>(out m_FilmGrain);
					m_PostVolume.profile.TryGet<Bloom>(out m_Bloom);
					m_PostVolume.profile.TryGet<ChromaticAberration>(out m_ChromaticAberration);
					m_PostVolume.profile.TryGet<ColorAdjustments>(out m_ColorAdjustments);
					m_PostVolume.profile.TryGet<LensDistortion>(out m_LensDistortion);
					m_PostVolume.profile.TryGet<MotionBlur>(out m_MotionBlur);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void SpawnModelGivenObject(GameObject model)
		 {
					Destroy(instance.m_CurrentModel);
					instance.m_CurrentModel = Instantiate(model, instance.m_SpawnPosition.position, Quaternion.identity, instance.m_SpawnPosition);
					instance.m_CurrentModel.transform.eulerAngles = Vector3.zero;
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 /// <summary>
		 /// Rotate the model, given the value from the slider
		 /// </summary>
		 /// <param name="value"></param>
		 public static void RotateModel(float value)
		 {
					instance.m_CurrentModel.transform.eulerAngles = new Vector3(instance.m_CurrentModel.transform.eulerAngles.x, value * 360, instance.m_CurrentModel.transform.eulerAngles.z);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 /// <summary>
		 /// Scale the model, given the value from the slider
		 /// </summary>
		 /// <param name="value"></param>
		 public static void ScaleModel(float value)
		 {
					instance.m_CurrentModel.transform.localScale = new Vector3(value, value, value);
		 }

		 public static void GetStartingTransformScale(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_CurrentModel.transform.localScale.x);
		 }

		 ////////////////////////////////////////////////////////////////////////////////
		 public static void TransformPositionX(float value)
		 {
					instance.m_CurrentModel.transform.position = new Vector3(value, instance.m_CurrentModel.transform.position.y, instance.m_CurrentModel.transform.position.z);
		 }

		 public static void GetStartingTransformPositionX(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_CurrentModel.transform.position.x);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void TransformPositionZ(float value)
		 {
					instance.m_CurrentModel.transform.position = new Vector3(instance.m_CurrentModel.transform.position.x, instance.m_CurrentModel.transform.position.y, value);
		 }

		 public static void GetStartingTransformPositionZ(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_CurrentModel.transform.position.z);
		 }

		 public static void ChangeCurrentModelMaterial(MaterialButtonOptionScriptableObject data)
		 {
					instance.m_CurrentModel.GetComponent<MeshRenderer>().material = data.m_OptionMaterial;
		 }

		 ////////////////////////////////////////////////////////////////////////////////
		 
		 public static void ChangeDirectionalLightIntensity(float value)
		 {
					instance.m_DirectionalLight.intensity = value;
		 }

		 public static void GetStartingDirectionalLightIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_DirectionalLight.intensity);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeDirectionalLightTemperature(float value)
		 {
					instance.m_DirectionalLight.colorTemperature = value;
		 }

		 public static void GetStartingDirectionalLightTemperature(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_DirectionalLight.colorTemperature);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeKeyLightTemperature(float value)
		 {
					instance.m_KeyLight.colorTemperature = value;
		 }

		 public static void GetStartingKeyLightTemperature(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_KeyLight.colorTemperature);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeKeyLightIntensity(float value)
		 {
					instance.m_KeyLight.intensity = value;
		 }

		 public static void GetStartingKeyLightIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_KeyLight.intensity);
		 }

		 ////////////////////////////////////////////////////////////////////////////////


		 public static void ChangeFillLightTemperature(float value)
		 {
					instance.m_FillLight.colorTemperature = value;
		 }

		 public static void GetStartingFillLightTemperature(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_FillLight.colorTemperature);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeFillLightIntensity(float value)
		 {
					instance.m_FillLight.intensity = value;
		 }

		 public static void GetStartingFillLightIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_FillLight.intensity);
		 }

		 ////////////////////////////////////////////////////////////////////////////////


		 public static void ChangeBackLightTemperature(float value)
		 {
					instance.m_BackLight.colorTemperature = value;
		 }

		 public static void GetStartingBackLightTemperature(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_BackLight.colorTemperature);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeBackLightIntensity(float value)
		 {
					instance.m_BackLight.intensity = value;
		 }

		 public static void GetStartingBackLightIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_BackLight.intensity);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeDirectionalLightRotationY(float value)
		 {
					instance.m_DirectionalLight.transform.eulerAngles = new Vector3(instance.m_DirectionalLight.transform.eulerAngles.x, value * 180, instance.m_DirectionalLight.transform.eulerAngles.z);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeFilmGrainIntensity(float value)
		 {
					instance.m_FilmGrain.intensity.value = value;
		 }

		 public static void GetStartingFilmGrainIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_FilmGrain.intensity.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeBloomIntensity(float value)
		 {
					instance.m_Bloom.intensity.value = value;
		 }

		 public static void GetStartingBloomIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_Bloom.intensity.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeChromaticAberrationIntensity(float value)
		 {
					instance.m_ChromaticAberration.intensity.value = value;
		 }

		 public static void GetStartingChromaticAberrationIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_ChromaticAberration.intensity.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeSaturationValue(float value)
		 {
					instance.m_ColorAdjustments.saturation.value = value;
		 }

		 public static void GetStartingSaturationValue(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_ColorAdjustments.saturation.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeHueShiftValue(float value)
		 {
					instance.m_ColorAdjustments.hueShift.value = value;
		 }

		 public static void GetStartingHueShiftValue(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_ColorAdjustments.hueShift.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeLensDistortionIntensity(float value)
		 {
					instance.m_LensDistortion.intensity.value = value;
		 }

		 public static void GetStartingLensDistortionIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_LensDistortion.intensity.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeMotionBlurIntensity(float value)
		 {
					instance.m_MotionBlur.intensity.value = value;
		 }

		 public static void GetStartingMotionBlurIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_MotionBlur.intensity.value);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeSkyboxLightIntensity(float value)
		 {
					RenderSettings.ambientIntensity = value;
		 }

		 public static void GetStartingSkyboxLightIntensity(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(RenderSettings.ambientIntensity);
		 }

		 ////////////////////////////////////////////////////////////////////////////////

		 public static void ChangeFOV(float value)
		 {
					instance.m_CinemachineRef.m_Lens.FieldOfView = value;
		 }

		 public static void GetStartingFOV(SliderOptionHelper option)
		 {
					option.InitializeStartingValue(instance.m_CinemachineRef.m_Lens.FieldOfView);
		 }

		 ////////////////////////////////////////////////////////////////////////////////
}
