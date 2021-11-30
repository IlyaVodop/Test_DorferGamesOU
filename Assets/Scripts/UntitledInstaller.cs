using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private Snake _snake;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private UiManager _uiManager;
    public override void InstallBindings()
    {
        Container.BindInstance(_gameManager);
        Container.BindInstance(_inputManager);
        Container.BindInstance(_boardManager);
        Container.BindInstance(_scoreManager);
        Container.BindInstance(_snake);
        Container.BindInstance(_soundManager);
        Container.BindInstance(_uiManager);
    }
}