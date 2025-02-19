using UnityEngine;
using UnityEngine.UIElements;

public class NewGameManager : Singleton<NewGameManager>
{
    [SerializeField] Event OnDestroyEvent;
    [SerializeField] IntEvent OnScoreEvent;

    int score = 0;
    int highScore = 0;

    private void Start()
    {
        OnDestroyEvent.Subscribe(OnDestroyed);
        OnScoreEvent.Subscribe(OnAddScore);

        highScore = PlayerPrefs.GetInt("highscore", 0);
        print($"HighScore: {highScore}");
    }
    public void OnDestroyed()
    {
        print("Destroyed");
    }
    public void OnAddScore(int points)
    {
        this.score += points;
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }

        print($"Score {score}");
    }
}
