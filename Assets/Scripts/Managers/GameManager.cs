using ScriptableObjects;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private LevelDataLibrary levelDataLibrary;
    
        private static GameManager instance;
            
        public static GameManager Instance
        {
            get
                {
                    if (instance == null)
                    {
                        Debug.LogError("GameManager instance is null.");
                    }
                    return instance;
                }
        }
            
        public LevelDataLibrary LevelDataLibrary => levelDataLibrary;
        public int currentlevelNumber { get; private set; }
            
        private GameObject currentLevelPrefab;
    
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
    
            instance = this;
        }
    
        private void Start()
        {
            currentlevelNumber = 1;
    
            LoadLevel();
        }
    
        public void LevelFailed()
        {
            LoadLevel();
        }
    
        public void LevelCompleted()
        {
            currentlevelNumber += 1;
            if (currentlevelNumber > levelDataLibrary.TotalLevels)
            {
                currentlevelNumber = 1;
            }
            LoadLevel();
        }
            
        private void LoadLevel()
        {
            DestroyExistingLevel();
            currentLevelPrefab = Instantiate(levelDataLibrary.GetLevelData(currentlevelNumber).LevelPrefab);
        }
    
        private void DestroyExistingLevel()
        {
            if (currentLevelPrefab != null)
            {
                Destroy(currentLevelPrefab);
            }
        }
    }
}