using Managers;
using UnityEngine;

public class FinishTarget : MonoBehaviour
{
    private const string PlayerBallObjectName = "PlayerBall";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == PlayerBallObjectName)
        {
            MyEventSystem.MyEventSystem.Instance.CompleteLevel(GameManager.Instance.currentlevelNumber);
            GameManager.Instance.LevelCompleted();
        }
    }
}