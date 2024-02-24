using UnityEngine;

namespace Aili.TinyRacing.Race
{
    [AddComponentMenu("Aili/Tiny Racing/Race/Lap Manager")]
    public class LapManager : MonoBehaviour
    {
        [Range(1, 5)]
        public int m_TotalLaps = 1;

        public bool isFinish { get; set; }
        public int currentLap { get; set; }
    }
}
