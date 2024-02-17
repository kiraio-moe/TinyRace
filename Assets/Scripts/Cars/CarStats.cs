using UnityEngine;

namespace Aili.MiniRace.Car
{
	[CreateAssetMenu(fileName = "CarStats_", menuName = "Aili/Car/Car Stats")]
	public class CarStats : ScriptableObject
	{
		public float m_MaxSpeed = 200f;
		public float m_MaxReverseSpeed = 50f;
		public float m_AccelerationMultiplier = 5f;
		public int m_MaxSteeringAngle = 45;
		public float m_SteeringSpeed = 0.5f;
		public float m_BrakeForce = 500f;
		public float m_DecelerationMultiplier = 1f;
		public float m_DriftMultiplier = 4f;
		public Vector3 m_CarMassCenter = Vector3.zero;
	}
}
