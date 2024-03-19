using Managers;
using UnityEngine;
using ScriptableObjects;

namespace Gameplay
{
    public class BallRoller : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform ballTransform;

        private Rigidbody ballRigidbody;

        private LevelDataLibrary levelDataLibrary;

        private float torqueAmount;
        private bool isPressing = false;

        private Vector3 cameraOffset;
        private Vector3 originalPressPoint = new(-1, -1, -1);

        private void Awake()
        {
            if (ballTransform == null || cameraTransform == null)
            {
                Debug.LogError("Ball or Camera transform not assigned in BallRoller.");
                return;
            }

            levelDataLibrary = GameManager.Instance.LevelDataLibrary;
            ballRigidbody = ballTransform.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (levelDataLibrary == null)
            {
                Debug.LogError("LevelDataLibrary not assigned in BallRoller.");
                return;
            }

            int currentLevelNumber = GameManager.Instance?.currentlevelNumber ?? 1;
            LevelData currentLevelData = levelDataLibrary.GetLevelData(currentLevelNumber);

            torqueAmount = currentLevelData.BallTorque;
            cameraOffset = ballTransform.position - cameraTransform.transform.position;

            MyEventSystem.MyEventSystem.Instance.StartLevel(GameManager.Instance.currentlevelNumber);
        }

        private void FixedUpdate()
        {
            if (isPressing)
            {
                ApplyTorque();
            }
        }

        private void Update()
        {
            HandleInput();
            UpdateCameraPosition();
        }

        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                originalPressPoint = Input.mousePosition;
                isPressing = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isPressing = false;
            }
        }

        private void ApplyTorque()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 diff = (originalPressPoint - mousePosition).normalized;
            Vector3 torqueVector = Vector3.forward * diff.x + Vector3.right * -diff.y;
            ballRigidbody.AddTorque(torqueVector * torqueAmount, ForceMode.VelocityChange);
        }

        private void UpdateCameraPosition()
        {
            cameraTransform.transform.position = ballTransform.position - cameraOffset;
        }
    }
}