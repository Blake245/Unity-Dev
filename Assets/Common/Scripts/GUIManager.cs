using TMPro;
using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] FloatData score;
    private void Update()
    {
        scoreText.text = score.Value.ToString();
    }
}
