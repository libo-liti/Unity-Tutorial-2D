using UnityEngine;

public class PinBall : MonoBehaviour
{
    public PinBallManager pinBallManager;
    void OnCollisionEnter2D(Collision2D other)
    {
        int score = 0;
        switch (other.gameObject.tag)
        {
            case "Score10":
                score = 10;
                break;
            case "Score30":
                score = 30;
                break;
            case "Score50":
                score = 50;
                break;
        }

        pinBallManager.totalScore += score;
        Debug.Log($"{score}점 획득");

        // if (other.gameObject.CompareTag("Score10"))
        // {
        //     pinBallManager.totalScore += 10;
        //     Debug.Log($"10점 획득 -> 현재 점수 : {pinBallManager.totalScore}");
        // }
        // else if (other.gameObject.CompareTag("Score30"))
        // {
        //     pinBallManager.totalScore += 30;
        //     Debug.Log($"30점 획득 -> 현재 점수 : {pinBallManager.totalScore}");
        // }
        // else if (other.gameObject.CompareTag("Score50"))
        // {
        //     pinBallManager.totalScore += 50;
        //     Debug.Log($"50점 획득 -> 현재 점수 : {pinBallManager.totalScore}");
        // }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log($"게임 종료 -> 총 점수 : {pinBallManager.totalScore}");
        }
    }
}
