using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    PlayerAbility,
    PlayerItem,
    EnemyMove,
    Attacking,

}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHUD playerHUD;
    [SerializeField] BattleUnit monsterUnit;
    [SerializeField] BattleHUD monsterHUD;
    [SerializeField] BattleDialogBox dialogBox;

    BattleState state;
    int currentAction;
    int currentMove;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.SetUp();
        monsterUnit.SetUp();
        playerHUD.SetData(playerUnit.Monster);
        monsterHUD.SetData(monsterUnit.Monster);
        
        //dialogBox.SetDialog($"You encountered a {monsterUnit.Monster.Stats.Name}.");
        yield return dialogBox.TypeDialog($"You encountered a {monsterUnit.Monster.Stats.Name}.");
        yield return new WaitForSeconds(1);

        PlayerAction();
    }

    private void PlayerAction()
    {
        currentAction = 0;
        state = BattleState.PlayerAction;
        dialogBox.EnableDialogText(true);
        dialogBox.EnableActionSelector(true);
        dialogBox.EnableMoveSelector(false);
        //dialogBox.EnableAbilitySelector(false);
        //dialogBox.EnableItemSelector(false);

        StartCoroutine(dialogBox.TypeDialog("Select an action"));
    }

    private void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
        currentMove = 0;
    }

    IEnumerator PerformPlayerAttack()
    {
        state = BattleState.Attacking;
        yield return dialogBox.TypeDialog($"You attack");
        yield return new WaitForSeconds(1);

        bool isDefeated = monsterUnit.Monster.TakeDamage(playerUnit.Monster);
        monsterHUD.UpdateHP();
        monsterHUD.UpdateAR();
        if (isDefeated)
        {
            yield return dialogBox.TypeDialog($"{monsterUnit.Monster.Stats.Name} has been Defeated");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        yield return dialogBox.TypeDialog("Slime used Tackle");
        yield return new WaitForSeconds(1);
        
        bool isDefeated = playerUnit.Monster.TakeDamage(monsterUnit.Monster);
        playerHUD.UpdateHP();
        playerHUD.UpdateAR();
        if (isDefeated)
        {
            yield return dialogBox.TypeDialog("You have been Defeated");
        }
        else
        {
            PlayerAction();
        }

    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

    private void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            if (currentAction < 1)
                ++currentAction;
        }

        else if (Input.GetKeyDown(KeyCode.W)) { 
            if (currentAction > 0)
            {
                --currentAction;
            }
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space)) {
            switch (currentAction) {
                case 0:
                    PlayerMove();
                    break;
                case 1:
                    Debug.Log("Running from battle");
                    break;
                default: break;
            }
        }
    }

    private void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            if (currentMove < 3)
                ++currentMove;
        }

        else if (Input.GetKeyDown(KeyCode.W)) { 
            if (currentMove > 0)
            {
                --currentMove;
            }
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Monster);

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space)) {
            switch (currentMove)
            {
                case 0:
                    Debug.Log("Attack");
                    dialogBox.EnableMoveSelector(false);
                    dialogBox.EnableDialogText(true);
                    StartCoroutine(PerformPlayerAttack());
                    break;
                case 1:
                    Debug.Log("Select Ability");
                    break;
                case 2:
                    Debug.Log("Select Item");
                    break;
                case 3:
                    PlayerAction();
                    break;
                default: break;
            }
        }
    }
}
