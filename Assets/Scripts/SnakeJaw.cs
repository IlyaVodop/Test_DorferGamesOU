using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class SnakeJaw : MonoBehaviour
{

    [Inject] private GameManager _gameManager;
    [Inject] private BoardManager _boardManager;
    [Inject] private ScoreManager _scoreManager;
    [Inject] private SoundManager _soundManager;

    [SerializeField] private SnakeBody _snakeBody;
    [SerializeField] private Snake _snake;

    private const float DotweenTextDuration = 0.5f;

    void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "Mine" || col.tag == "Trap") && !_snake.FeverMode)
        {
            _gameManager.Restart();
            return;
        }

        switch (col.tag)
        {
            case "Food":
                {
                    StartCoroutine(_snakeBody.Ingestion());
                    _scoreManager.FoodCountIncrease();
                    GameObject TextUp = Instantiate(_scoreManager.OnePlusPrefabs, col.transform.position, Quaternion.identity);
                    TextUp.transform.DOMove(_scoreManager.Anchor.transform.position, DotweenTextDuration, false);
                    _soundManager.FoodSound();
                    break;
                }

            case "Crystal":
                _scoreManager.CrystalIncrease();
                _soundManager.SoundCristal();
                break;
            case "BoardLine":
                _boardManager.SelectColorSnake();

                break;
        }
    }
}
