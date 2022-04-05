using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OrbitController : MonoBehaviour
{
		 public float m_FollowChangeSpeed;

		 [HideInInspector]
		 public CinemachineFreeLook m_FreeLookCamera;

		 private string XAxisTag = "Mouse X";
		 private string YAxisTag = "Mouse Y";

		 private float m_MinFollowY = 0.6f;
		 private float m_MaxFollowY = 2f;
		 private float m_CalculatedNewY = 0f;
		 private void Start()
		 {
					m_FreeLookCamera = GetComponent<CinemachineFreeLook>();
					m_FreeLookCamera.m_XAxis.m_InputAxisName = "";
					m_FreeLookCamera.m_YAxis.m_InputAxisName = "";
		 }

		 /// <summary>
		 /// Control Camera Orbit
		 /// </summary>
		 private void Update()
		 {
					if(!MenuManager.instance.IsMenuOpen())
					{
							 if (Input.GetMouseButton(0))
							 {
										m_FreeLookCamera.m_XAxis.m_InputAxisValue = Input.GetAxis(XAxisTag);
										m_FreeLookCamera.m_YAxis.m_InputAxisValue = Input.GetAxis(YAxisTag);
							 }

							 if (Input.GetMouseButtonUp(0))
							 {
										m_FreeLookCamera.m_XAxis.m_InputAxisValue = 0;
										m_FreeLookCamera.m_YAxis.m_InputAxisValue = 0;
							 }

							 if (Input.GetMouseButton(1))
							 {
										m_CalculatedNewY = m_FreeLookCamera.m_Follow.position.y + (Input.GetAxis(YAxisTag) * m_FollowChangeSpeed);

										if (m_CalculatedNewY > m_MinFollowY && m_CalculatedNewY < m_MaxFollowY)
												 m_FreeLookCamera.m_Follow.position += new Vector3(0, Input.GetAxis(YAxisTag) * m_FollowChangeSpeed, 0);
							 }
					}
		 }
}
