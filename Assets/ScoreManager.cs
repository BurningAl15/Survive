using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager _instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int currentScore;

    [SerializeField] private Animator chainAnimator;
    [SerializeField] private TextMeshProUGUI chainText;
    private int chain;
    
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != null)
            Destroy(this);
        
        scoreText.text = "Score: " + currentScore;
        chainText.text = "";
    }

    public void AddPoints()
    {
        currentScore += 10;
        scoreText.text = "Score: " + currentScore;
        
        chain++;
        chainAnimator.SetTrigger("Chain");
        chainText.text = "x"+chain;
    }

    public void TakePoints()
    {
        currentScore -= 10;
        scoreText.text = "Score: " + currentScore;
        chain=0;
        chainText.text = "";
    }
}
