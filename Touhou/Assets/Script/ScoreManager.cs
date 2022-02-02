using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;

    public Text _currentScoreText;
    public int _currentScore = 0;

    public Text _bestScoreText;
    public int _bestScore = 0;

    private void Awake()
    {
       if(Instance == null)
        {
            Instance = this;
        }
    }

    public void addscore(int num)
    {
        _currentScore += num;
        _currentScoreText.text = " " + _currentScore;
    }

    void Start()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _bestScoreText.text = " " + _bestScore;
    }

    void Update()
    {
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
            _bestScoreText.text = " " + _bestScore;

            PlayerPrefs.SetInt("BestScore", _bestScore);
        }
    }
}
