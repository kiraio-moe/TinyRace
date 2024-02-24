using UnityEngine;
using TMPro;
using Aili.TinyRacing.Race;

namespace Aili.TinyRacing.UI
{
    [AddComponentMenu("Aili/Tiny Racing/UI/Race UI")]
    public class RaceUI : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI m_LapCountText;

        [Space(10)]
        [SerializeField]
        TextMeshProUGUI m_FinishedText;

        LapManager lapManager;

        void Awake()
        {
            lapManager = FindObjectOfType<LapManager>();
        }

        void LateUpdate()
        {
            m_LapCountText.text = $"Lap: {lapManager.currentLap} / {lapManager.m_TotalLaps}";
            m_FinishedText.gameObject.SetActive(lapManager.isFinish);
        }
    }
}
