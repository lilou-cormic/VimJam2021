﻿using PurpleCable;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player _Player = null;
    public static Player Player => Current._Player;

    [SerializeField] MainMenu MainMenu = null;

    [SerializeField] GameObject PausePanel = null;

    private bool _IsPaused = false;
    private bool IsPaused
    {
        get => _IsPaused;

        set
        {
            _IsPaused = value;

            Time.timeScale = (_IsPaused ? 0 : 1);

            if (PausePanel != null)
                PausePanel.gameObject.SetActive(_IsPaused);

            if (_IsPaused)
            {
                EventSystem eventSystem = FindObjectOfType<EventSystem>();

                //HACK
                eventSystem.SetSelectedGameObject(gameObject);

                eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
            }
        }
    }

    public static bool IsGamePaused => Current.IsPaused;

    private static GameManager Current { get; set; }

    private bool _gameIsEnding = false;

    private void Awake()
    {
        Current = this;

        ScoreManager.ResetScore();
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBuilding), 1.5f, 1.25f);
    }

    private void OnDestroy()
    {
        UnPause();

        Current = null;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") || Input.GetButtonDown("Cancel"))
            IsPaused = !IsPaused;
    }

    private void SpawnBuilding()
    {
        if (IsPaused || _gameIsEnding)
            return;

        BuildingCollection.GetBuilding(20);
    }

    public static void Win()
        => Current.StartCoroutine(Current.DoWin());

    private IEnumerator DoWin()
    {
        if (!_gameIsEnding)
        {
            _gameIsEnding = true;

            GetComponent<MusicWithIntro>()?.Stop();
            //MusicManager.PlayWinJingle();

            ScoreManager.SetHighScore();

            yield return new WaitForSeconds(3f);

            MainMenu.LoadScene("Win");
        }
    }

    public static void GameOver()
        => Current.StartCoroutine(Current.DoGameOver());

    public IEnumerator DoGameOver()
    {
        if (!_gameIsEnding)
        {
            _gameIsEnding = true;

            GetComponent<MusicWithIntro>()?.Stop();
            //MusicManager.PlayLoseJingle();

            yield return new WaitForSeconds(0.02f);

            MainMenu.LoadScene("GameOver");
        }
    }

    public void UnPause()
    {
        IsPaused = false;
    }

    public void GoToMenu()
    {
        UnPause();

        MainMenu.GoToMenu();
    }
}