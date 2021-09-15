using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    [SerializeField] private int startCountLives;
    [SerializeField] private MenuController menu;
    private Text lives;
    public int Lives { get; private set; }
    public void ChangeLives(int deltaLives)
    {
        Lives += deltaLives;
        if (Lives < 1)
            menu.GameOver();
        lives.text = Lives.ToString();
    }
    private void Start()
    {
        lives = GetComponent<Text>();
        Lives = startCountLives;
        ChangeLives(0);
    }

}
