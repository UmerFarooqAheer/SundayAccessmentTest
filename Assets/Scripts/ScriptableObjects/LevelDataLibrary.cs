using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create/BallRoller/LevelDataLibrary", fileName = "LevelDataLibrary")]
    public class LevelDataLibrary : ScriptableObject
    {
        [SerializeField] private List<LevelData> levelsData;

        public int TotalLevels => levelsData.Count;
        
        public LevelData GetLevelData(int level)
        {
            return levelsData[level - 1];
        }
    }
}
