using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create/BallRoller/Level", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private GameObject levelPrefab;
        [SerializeField] private int ballTorque;

        public GameObject LevelPrefab => levelPrefab;
        public int BallTorque => ballTorque;

        // Any further data related to the level can be added. For example, celebrationParticleEffect, sound effect etc.
        // As following,
        // [SerializeField] private ParticleSystem celebrationParticleEffect;
        // public ParticleSystem CelebrationParticleEffect => celebrationParticleEffect;
    }
}