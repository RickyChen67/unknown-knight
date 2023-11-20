using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Battle}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BattleSystem battleSystem;
    public GameState state;

    private void Start()
    {
        playerController.OnEncounter += StartBattle;
        battleSystem.OnBattleEnd += EndBattle;
    }

    private void StartBattle()
    {
        state = GameState.Battle;
        playerController.gameObject.SetActive(false);
        battleSystem.gameObject.SetActive(true);
    }

    private void EndBattle(bool battleWon)
    {
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        playerController.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam)
        {
            playerController.HandleUpdate();
        }
        else if (state == GameState.Battle)
        {
            battleSystem.HandleUpdate();
        }
    }

}
