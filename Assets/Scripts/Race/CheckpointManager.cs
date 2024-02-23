using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aili.TinyRacing.Race
{
    [AddComponentMenu("Aili/Tiny Racing/Race/Checkpoint Manager")]
    public class CheckpointManager : MonoBehaviour
    {
        public List<Checkpoint> m_Checkpoints = new List<Checkpoint>();
        public int currentCheckpoint { get; set; }
    }
}
