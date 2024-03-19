using Managers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string PlayerBallObjectName = "PlayerBall";
        
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == PlayerBallObjectName)
        {
            LevelFailed();
        }
        else
        {
            Debug.Log(collision.gameObject.name);
        }
    }

    private void LevelFailed()
    {
        GameManager gameManager = GameManager.Instance;
        MyEventSystem.MyEventSystem.Instance.FailLevel(gameManager.currentlevelNumber);
        gameManager.LevelFailed();
    }
}
