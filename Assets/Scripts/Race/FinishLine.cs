using UnityEngine;
using WSWhitehouse.TagSelector;

namespace Aili.TinyRacing.Race
{
    [AddComponentMenu("Aili/Tiny Racing/Race/Finish Line")]
    public class FinishLine : MonoBehaviour
    {
        [SerializeField, TagSelector]
        string m_TriggerWith = "Player";

        LapManager lapManager;
        CheckpointManager checkpointManager;
        BoxCollider boxCollider;

        void Awake()
        {
            lapManager = FindObjectOfType<LapManager>();
            checkpointManager = FindObjectOfType<CheckpointManager>();
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(m_TriggerWith))
            {
                if (checkpointManager.currentCheckpoint == checkpointManager.m_Checkpoints.Count)
                {
                    lapManager.currentLap++;

                    if (lapManager.currentLap == lapManager.m_TotalLaps)
                    {
                        lapManager.isFinish = true;
                        Debug.Log("RACE FINISHED!");
                    }
                    else
                        checkpointManager.currentCheckpoint = 0;
                }
            }
        }
    }
}
