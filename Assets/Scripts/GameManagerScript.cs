using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawn;
    public GameObject GameOver;
    public GameObject scoreUIText;
    public GameObject timeCounter;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
        
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                GameOver.SetActive(false);

                playButton.SetActive(true);

                break;

            case GameManagerState.Gameplay:

                scoreUIText.GetComponent<GameScoreScrip>().Score = 0;

                playButton.SetActive(false);

                playerShip.GetComponent<PlayerMove>().Init();

                enemySpawn.GetComponent<EnemySpawn>().StartEnemySpawner();

                timeCounter.GetComponent<TimeCounter>().startCounter();

                break;

            case GameManagerState.GameOver:
                timeCounter.GetComponent<TimeCounter>().stopTime();

                enemySpawn.GetComponent<EnemySpawn>().StopEnemySpawner();

                GameOver.SetActive(true);

                Invoke("StartOpeningState",8f);

                break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void StartOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
