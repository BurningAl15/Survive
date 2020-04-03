using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public enum GameState
    {
        CHARGE,
        PLAY,
        LOSE,
        END
    }

    public GameState gameState = GameState.CHARGE;
    [SerializeField] private float delay;

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);
    }

    private Coroutine currentCoroutine = null;

    void Start()
    {
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(StartGame(delay));
        }
    }

    IEnumerator StartGame(float _delay)
    {
        yield return StartCoroutine(GameScenesManager._instance.InitialTransition(.5f));
        yield return new WaitForSeconds(_delay);

        gameState = GameState.PLAY;
        currentCoroutine = null;
    }
}
