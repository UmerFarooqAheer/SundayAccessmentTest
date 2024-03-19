using GameAnalyticsSDK;
using UnityEngine;

namespace MyEventSystem
{
    public class MyEventSystem : MonoBehaviour
    {
        private static MyEventSystem instance;

        public static MyEventSystem Instance
        {
            get
                {
                    if (instance == null)
                    {
                        Debug.LogError("AnalyticsManager instance is null.");
                    }

                    return instance;
                }
        }

        private void Awake()
        {
            // Improved:Ensure only one instance of the AnalyticsManager exists.
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            try
            {
                GameAnalytics.Initialize();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Failed to initialize GameAnalytics: " + ex.Message);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void StartLevel(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
        }

        public void FailLevel(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
        }

        public void CompleteLevel(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
        }
    }
}
