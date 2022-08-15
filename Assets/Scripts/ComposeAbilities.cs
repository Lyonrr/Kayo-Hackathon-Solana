using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UFE3D;
using UnityEngine;
using UnityEngine.UI;

public class ComposeAbilities : MonoBehaviour
{
    [SerializeField] private bool opponentNoAttacks = false;

    private AbilityButton[] abilityButtons;
    private List<MoveInfo> chosenMoves = new List<MoveInfo>();
    int index = 0;

    void Start()
    {
        abilityButtons = FindObjectsOfType<AbilityButton>();
        InvokeRepeating(nameof(ShuffleArray), 0.5f, 0.5f);
    }

    private IEnumerator StartFight()
    {
        RetrieveMovesFromButtons();
        PrintArrray(chosenMoves.ToArray());
        yield return new WaitForSeconds(1);

        UFE.GetPlayer1ControlsScript().MoveSet.moves = chosenMoves.ToArray();

        if (opponentNoAttacks)
        {
            UFE.GetPlayer2ControlsScript().MoveSet.moves = new MoveInfo[0];
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            MoveInfo[] oneMove = new MoveInfo[1];

            // int randomNumber1 = UnityEngine.Random.Range(0, chosenMoves.Count);
            oneMove[0] = chosenMoves[index];
            UFE.GetPlayer1ControlsScript().MoveSet.moves = oneMove;
            index = (index + 1) % chosenMoves.Count;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ShuffleArray();
        }
    }

    private void ShuffleArray()
    {
        System.Random random = new System.Random();
        UFE.GetPlayer1ControlsScript().MoveSet.moves = chosenMoves.OrderBy(x => random.Next()).ToArray();

        if (!opponentNoAttacks)
        {
            System.Random random2 = new System.Random();
            MoveInfo[] aux = UFE.GetPlayer2ControlsScript().MoveSet.moves;
            UFE.GetPlayer2ControlsScript().MoveSet.moves = aux.OrderBy(x => random2.Next()).ToArray();

        }
    }

    public void OnStartFight()
    {
        StartCoroutine(StartFight());
    }

    private void RetrieveMovesFromButtons()
    {
        foreach (AbilityButton abilityButton in abilityButtons)
        {
            if (abilityButton.AbilityData && abilityButton.AbilityData.Selected)
            {
                foreach (MoveInfo move in abilityButton.AbilityData.Moves)
                {
                    chosenMoves.Add(move);
                }
            }
        }

    }

    private void PrintArrray(MoveInfo[] arr)
    {
        foreach (var attack in arr)
        {
            print(attack.name);
        }
    }
}
