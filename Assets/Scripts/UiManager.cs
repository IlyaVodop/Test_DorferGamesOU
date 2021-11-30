using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private GameObject _startMenuPanel;
     public GameObject _uiObject;

    [SerializeField] private Text _gameTimerText;
    [SerializeField] private Text _foodText;
    [SerializeField] private Text _crystalText;

    [SerializeField] private GameObject[] _uiImage;

    [Inject] private ScoreManager _scoreManager;
    [Inject] private SoundManager _soundManager;


    private void Subscribe()
    {
        _scoreManager.OnCrystalScoreChanged += _scoreManager_OnCrystalScoreChanged;
        _scoreManager.OnFoodCountChanged += _scoreManager_OnFoodCountChanged;
        _scoreManager.OnGameTimerChanged += _scoreManager_OnGameTimerChanged;
    }

    private void _scoreManager_OnGameTimerChanged(float obj)
    {
        _gameTimerText.text = obj.ToString();
    }

    private void _scoreManager_OnFoodCountChanged(int obj)
    {
        _foodText.text = obj.ToString();
    }

    private void _scoreManager_OnCrystalScoreChanged(int obj)
    {
        _crystalText.text = obj.ToString();
    }

    private void Unsubscribe()
    {
        _scoreManager.OnCrystalScoreChanged -= _scoreManager_OnCrystalScoreChanged;
        _scoreManager.OnFoodCountChanged -= _scoreManager_OnFoodCountChanged;
        _scoreManager.OnGameTimerChanged -= _scoreManager_OnGameTimerChanged;
    }

    void Start()
    {
        _startBtn.onClick.AddListener(StartButton);
        _exitBtn.onClick.AddListener(ExitButton);
        StartCoroutine(LoadingAnimationCoroutine());

    }

    private void Awake()
    {
        Subscribe();
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        Time.timeScale = 1f;
        _startMenuPanel.SetActive(false);
        _uiObject.SetActive(false);
        _gameTimerText.gameObject.SetActive(true);
        _foodText.gameObject.SetActive(true);
        _crystalText.gameObject.SetActive(true);

        _soundManager.SoundClick();
    }
    private IEnumerator LoadingAnimationCoroutine()
    {
        for (int i = 0; i < _uiImage.Length; i++)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            _uiImage[i].SetActive(true);
        }
    }

}
