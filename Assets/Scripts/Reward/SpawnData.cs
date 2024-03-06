using UnityEngine;

namespace Reward
{
    [CreateAssetMenu (fileName = "NewSpawnData", menuName = "Scriptable Objects/Spawn Data")]
    internal class SpawnData : ScriptableObject
    {
        [field: SerializeReference] public float ShowDuration { get; private set; }
        [field: SerializeReference] public float HideMinDelay { get; private set; }
        [field: SerializeReference] public float HideMaxDelay { get; private set; }
        [field: SerializeReference] public float HideDuration { get; private set; }

        [field: SerializeReference] public int R1 { get; private set; }
        [field: SerializeReference] public int R2 { get; private set; }
    }
}
