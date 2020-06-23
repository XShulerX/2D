using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour, IObserver
{

    #region Fields

    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _menu;

    private int _score = -1;
    private float _maxHealth = 0;
    private float _currentHealth = 0;

    #endregion


    #region UnityMethods

    private void Start()
    {
        var data = GameObject.FindGameObjectWithTag("Data").GetComponent<CharacterData>();
        data.AddObserver(this);
    }

    private void Update()
    {
        ShowMenu();
    }

    #endregion


    #region Methods

    private void ShowMenu()
    {
        if (Input.GetButton("Cancel"))
        {
            _menu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void CloseMenu()
    {
        _menu.SetActive(false);
        Resume();
    }

    private void Resume()
    {
        Time.timeScale = 1.0f;
    }

    private void SetHealthBar()
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    private void SetScoreText(string text)
    {
        _scoreText.text = $"Score {text}";
    }

    public void LoadScene(int index)
    {
        Resume();
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }
    #endregion

    #region IObsrever

    public void Update(object _object )
    {
        var characterData = (CharacterData)_object;
        if (_maxHealth != characterData.MaxHealth)
        {
            _maxHealth = characterData.MaxHealth;
        }
        if (_currentHealth != characterData.Health)
        {
            _currentHealth = characterData.Health;
            SetHealthBar();
        }
        if(_score != characterData.Score)
        {
            _score = characterData.Score;
            SetScoreText(_score.ToString());
        }
    }

    #endregion
}
