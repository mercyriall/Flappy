using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        //PlayerPrefs.GetInt("HighScore")
        if (_score > int.Parse(_highScoreText.text))
        {
            PlayerPrefs.SetInt("HighScore", _score);
            //_bridge.SetData(_telegramId, _score.ToString());

            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }
}
