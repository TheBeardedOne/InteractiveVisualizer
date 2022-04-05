using UnityEngine;

public enum EOptionCategory 
{
		 Model = 0,
		 Transform = 1,
		 Textures = 2,
		 Lights = 3,
		 Post = 4, 
		 Cam = 5
};


public class OptionsScriptableObject : ScriptableObject
{
		 public string m_OptionName;
		 public EOptionCategory m_OptionCategory;
		 public GameObject m_OptionPrefab;
}
