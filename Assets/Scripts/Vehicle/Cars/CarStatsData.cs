using UnityEngine;

namespace Aili.TinyRacing.Vehicle
{
	[CreateAssetMenu(fileName = "CarStatsData_", menuName = "Aili/Tiny Racing/Vehicle/Car Stats Data")]
	public class CarStatsData : ScriptableObject
	{
		public float m_Mass = 1000f;
		public float m_MaxSpeed = 200f;
		public float m_MaxReverseSpeed = 50f;
		public float m_AccelerationMultiplier = 5f;
		public float m_Acceleration = 500f;
		[Range(1, 45)]
		public int m_MaxTurnAngle = 35, m_MaxTurnAngleMaxSpeed = 10;
		public float m_SteeringSpeed = 0.5f;
		public float m_BrakeForce = 500f;
		public float m_DecelerationMultiplier = 1f;
		public float m_DriftMultiplier = 4f;
		public Vector3 m_CenterOfMass = Vector3.zero;
	}
}
