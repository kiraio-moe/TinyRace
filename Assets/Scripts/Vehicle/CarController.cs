using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aili.TinyRacing.Vehicle
{
	[AddComponentMenu("Aili/Tiny Race/Vehicle/Car Controller")]
	public class CarController : MonoBehaviour
	{
		[Header("PHYSICS")]
		[SerializeField] Rigidbody m_Body;
		
		[Header("WHEELS")]
		[SerializeField] WheelCollider m_FrontLeftWheelCollider;
		[SerializeField] WheelCollider m_FrontRightWheelCollider;
		[SerializeField] WheelCollider m_RearLeftWheelCollider;
		[SerializeField] WheelCollider m_RearRightWheelCollider;
		
		[Space(10)]
		[SerializeField] Transform m_FrontLeftWheelMesh;
		[SerializeField] Transform m_FrontRightWheelMesh;
		[SerializeField] Transform m_RearLeftWheelMesh;
		[SerializeField] Transform m_RearRightWheelMesh;
		
		[Header("STATS")]
		[SerializeField] CarStatsData m_CarStats;
		
		// [Space(10)]
		// [SerializeField, Range(5, 45)] int m_MaxTurnAngle = 30;
		// [SerializeField] float m_Acceleration = 500f;
		// [SerializeField] float m_BrakeForce = 300f;
		
		float currentSpeed;
		float currentAcceleration, currentBreakForce, currentTurnAngle;
		
		void Start()
		{
			m_Body.automaticCenterOfMass = false;
			m_Body.mass = m_CarStats.m_Mass;
			// Adjust center of mass vertically, to help prevent the car from rolling
			m_Body.centerOfMass += Vector3.up * m_CarStats.m_CenterOfMass.y;
		}
		
		void FixedUpdate()
		{
			float hInput = Input.GetAxis("Horizontal");
			float vInput = Input.GetAxis("Vertical");

			// set forward/reverse acceleration
			currentAcceleration = m_CarStats.m_Acceleration * vInput;
			currentBreakForce = Input.GetKey(KeyCode.Space) ? m_CarStats.m_BrakeForce : 0;
			
			// apply acceleration & brake
			m_RearLeftWheelCollider.motorTorque = m_RearRightWheelCollider.motorTorque = currentAcceleration;
			m_FrontLeftWheelCollider.brakeTorque = m_FrontRightWheelCollider.brakeTorque = m_RearLeftWheelCollider.brakeTorque = m_RearRightWheelCollider.brakeTorque = currentBreakForce;
			
			// set steering
			currentTurnAngle = m_CarStats.m_MaxTurnAngle * hInput;
			m_FrontLeftWheelCollider.steerAngle = m_FrontRightWheelCollider.steerAngle = currentTurnAngle;
			
			currentSpeed = Vector3.Dot(transform.forward, m_Body.velocity);
			
			AnimateWheels();
		}

		void AnimateWheels()
		{
			SetWheelTransform(m_FrontLeftWheelCollider, m_FrontLeftWheelMesh);
			SetWheelTransform(m_FrontRightWheelCollider, m_FrontRightWheelMesh);
			SetWheelTransform(m_RearLeftWheelCollider, m_RearLeftWheelMesh);
			SetWheelTransform(m_RearRightWheelCollider, m_RearRightWheelMesh);
			
		}
		
		void SetWheelTransform(WheelCollider wheelCollider, Transform wheelMesh)
		{
			Quaternion rotation;
			Vector3 position;
			wheelCollider.GetWorldPose(out position, out rotation);
			wheelMesh.position = position;
			wheelMesh.rotation = rotation;
		}
	}
}
