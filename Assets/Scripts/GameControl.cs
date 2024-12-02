using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameControl : MonoBehaviour
{
    public static GameControl Instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -3f;
    public TMP_Text scoreText;
    private int score = 0;
    private AudioSource audioSource;
    public AudioClip dieClip;
    public AudioClip scoreClip;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    void Start() { }

    void Update()
    {
        if (!gameOver)
            scrollSpeed -= Time.deltaTime * 0.1f;
        if (gameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKey(KeyCode.Escape)) 
            Application.Quit();
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
        audioSource.PlayOneShot(dieClip);
    }
    public void BirdScored()
    {
        if (gameOver) 
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
        audioSource.PlayOneShot(scoreClip);
    }
}
