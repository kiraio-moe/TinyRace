using UnityEngine;
using WSWhitehouse.TagSelector;

namespace Aili.TinyRacing.Race
{
    [AddComponentMenu("Aili/Tiny Racing/Race/Checkpoint")]
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField, Range(1, 500)]
        int m_CheckpointIndex = 1;

        [Space(10)]
        [SerializeField, TagSelector]
        string m_TriggerWith = "Player";

        CheckpointManager checkpointManager;
        BoxCollider boxCollider;

        void Awake()
        {
            checkpointManager = FindObjectOfType<CheckpointManager>();
            boxCollider = GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }

        void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(m_TriggerWith))
            {
                if (checkpointManager.currentCheckpoint == m_CheckpointIndex - 1)
                    checkpointManager.currentCheckpoint = m_CheckpointIndex;
                Debug.Log($"TRIGGER WITH {m_TriggerWith}");
            }
        }
    }
}
