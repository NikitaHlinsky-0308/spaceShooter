using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // handle to Text
    [SerializeField] private Text _scoreText;
    [SerializeField] private Sprite[] _spritesList;
    [SerializeField] private Image _livesImage;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartGameMessage;
    [SerializeField] private GameManager _gameManager;
     
    // Start is called before the first frame update
    void Start()
    {
        // assign text component to the handle
        _scoreText.text = "SCORE: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _restartGameMessage.gameObject.SetActive(false);
        //_gameManager = GameObject.Find("Game_Maneger").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("_gameManager is NULL");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "SCORE: " + playerScore.ToString();   
    }

    public void UpdateLives(int currentLives)
    {
        // display img
        // give it a new one based on a current lives
        
        _livesImage.sprite = _spritesList[currentLives];

        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }
    public void GameOverSequence()
    {
        _gameManager.GameOver();
        StartCoroutine(GameOverFlickerRuntime());
        _restartGameMessage.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlickerRuntime()
    {
        while(true)
        {
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.3f);  
        }
    }
    
}
