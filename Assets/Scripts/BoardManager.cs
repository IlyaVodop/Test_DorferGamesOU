using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _board;
    [SerializeField] private Snake _snake;

    private int _boardIndex = 0;

    void Start()
    {
        _snake.SetColor(_board[_boardIndex].GetComponent<MeshRenderer>().material.color);
    }

    public void SelectColorSnake()
    {
        _snake.SetColor(_board[_boardIndex].GetComponent<MeshRenderer>().material.color);
        _boardIndex++;
    }
}
