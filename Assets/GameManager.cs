using System;
using UFE3D;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject winGO;
    [SerializeField] private GameObject loseGO;
    void Start()
    {
        UFE.OnGameEnds += EndOfGame;
    }

    private void EndOfGame(ControlsScript winner, ControlsScript loser)
    {
        canvas.SetActive(true);

        if (winner == UFE.GetPlayer1ControlsScript())
        {
            ShowWinScreen();
            return;
        }
        ShowLoseScreen();
    }

    private void ShowWinScreen()
    {
        winGO.SetActive(true);
    }

    private void ShowLoseScreen()
    {
        loseGO.SetActive(true);
    }



}
