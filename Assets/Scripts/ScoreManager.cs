using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreManager : MonoBehaviour
{
    [Inject] private Snake _snake;
    [Inject] private GameManager _gameManager;

    public event Action<float> OnGameTimerChanged;
    public event Action<int> OnFoodCountChanged;
    public event Action<int> OnCrystalScoreChanged;

    private const int ScoreForFever = 3;

    public GameObject OnePlusPrefabs;
    public GameObject Anchor;


    private int _foodScore = 0;
    private int _currentScoreForFever = 0;
    private float _gameTimer = 40;
    private int _statisticCrystalScore = 0;

    private void Update()
    {
        _gameTimer = _gameTimer - Time.deltaTime;

        OnGameTimerChanged?.Invoke(Mathf.CeilToInt(_gameTimer));
        if (_gameTimer <= 0)
        {
            _gameManager.Restart();
        }
    }
    public void FoodCountIncrease()
    {
        _foodScore++;
        ResetFeverCount();
        OnFoodCountChanged?.Invoke(_foodScore);
    }

    private void ResetFeverCount()
    {
        _currentScoreForFever = 0;
    }


    public void CrystalIncrease()
    {
        _currentScoreForFever++;
        _statisticCrystalScore++;
        OnCrystalScoreChanged?.Invoke(_statisticCrystalScore);
        if (_currentScoreForFever >= ScoreForFever)
        {
            if (!_snake.FeverMode)
            {

                StartCoroutine(_snake.EnableFeverMode());
                _currentScoreForFever = 0;
                _statisticCrystalScore = 0;
            }
        }
    }


}
