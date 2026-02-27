using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreLabel;
    [SerializeField] SettingsPopup settings;

    private int _score;

    private void OnEnable()
    { 
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void Start()
    {
        _score = 0;
        scoreLabel.text = _score.ToString();

        settings.Close();
    }
    private void OnEnemyHit()
    {
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
    public void OnOpenSettings()
    {
        settings.Open();
    }

}
