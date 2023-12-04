using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //[SerializeField] Image backgroundImage = null;

    public event Action<bool> OnBattleEnd;

    BattleState state;
    int currentAction;
    int currentMove;
    bool defended;
    int playerActions;
    int monsterActions;

    List<BattleUnit> turnOrder = new List<BattleUnit>(2);

    public void StartBattle(MonsterObject monster)
    {
        StartCoroutine(SetupBattle(monster));
    }

    public IEnumerator SetupBattle(MonsterObject monster)
    {
        playerUnit.SetUp();
        monsterUnit.SetUp(monster);
        playerHUD.SetData(playerUnit.Monster);
        monsterHUD.SetData(monsterUnit.Monster);

        dialogBox.EnableDialogText(true);
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(false);

        if (playerUnit.Monster.Monster.Speed > monsterUnit.Monster.Monster.Speed)
        {
            turnOrder.Add(playerUnit);
            turnOrder.Add(monsterUnit);
        }
        else
        {
            turnOrder.Add(monsterUnit);
            turnOrder.Add(playerUnit);
        }

        //dialogBox.SetDialog($"You encountered a {monsterUnit.Monster.Stats.Name}.");
        yield return dialogBox.TypeDialog($"You encountered a {monsterUnit.Monster.Monster.Name}.");
        yield return new WaitForSeconds(1);

        if (playerUnit.Monster.Monster.Speed >= monsterUnit.Monster.Monster.Speed)
            PlayerAction();
        else
            StartCoroutine(EnemyMove());
    }

    private void PlayerAction()
    {
        currentAction = 0;
        state = BattleState.PlayerAction;
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActionSelector(true);
        dialogBox.EnableMoveSelector(false);
        //dialogBox.EnableAbilitySelector(false);
        //dialogBox.EnableItemSelector(false);

        StartCoroutine(dialogBox.TypeActionDialog());
    }

    private void PlayerMove()
    {
        currentMove = 0;
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerAttack(int action)
    {
        state = BattleState.Attacking;
        if (action == 0)
        {
            yield return dialogBox.TypeDialog($"You attack");
            monsterUnit.Hurt();
        }
        else if (action == 1)
        {
            defended = true;
            yield return dialogBox.TypeDialog($"You defend");
        }
        yield return new WaitForSeconds(1);

        bool isDefeated = false;
        if (action == 0)
        {
            isDefeated = monsterUnit.Monster.TakeDamage(playerUnit.Monster);
        }
        else if (action == 1)
        {
            playerUnit.Monster.DefendAction();
            yield return playerHUD.UpdateAR();
        }
        yield return monsterHUD.UpdateHP();
        yield return monsterHUD.UpdateAR();

        if (isDefeated)
        {
            monsterUnit.Death();
            yield return dialogBox.TypeDialog($"{monsterUnit.Monster.Monster.Name} has been Defeated");

            yield return new WaitForSeconds(1);
            playerUnit.Monster.RestoreAR();
            OnBattleEnd(true);
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        yield return dialogBox.TypeDialog($"{monsterUnit.Monster.Monster.Name} attacks");
        monsterUnit.Attack();
        yield return new WaitForSeconds(1);
        
        bool isDefeated = playerUnit.Monster.TakeDamage(monsterUnit.Monster);
        yield return playerHUD.UpdateHP();
        yield return playerHUD.UpdateAR();
        if (isDefeated)
        {
            yield return dialogBox.TypeDialog("You have been Defeated");

            yield return new WaitForSeconds(1);
            OnBattleEnd(false);
        }
        else
        {
            if (defended)
            {
                playerUnit.Monster.PostDefend();
                defended = false;
                yield return playerHUD.UpdateAR();
            }

            PlayerAction();
        }

    }

    public void HandleUpdate()
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
                    //Application.Quit();
                    OnBattleEnd(false);
                    Debug.Log("Running from battle");
                    break;
                default: break;
            }
        }
    }

    private void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            if (currentMove < 4)
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
                    dialogBox.EnableMoveSelector(false);
                    dialogBox.EnableDialogText(true);
                    StartCoroutine(PerformPlayerAttack(0));
                    break;
                case 1:
                    dialogBox.EnableMoveSelector(false);
                    dialogBox.EnableDialogText(true);
                    StartCoroutine(PerformPlayerAttack(1));
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    PlayerAction();
                    break;
                default: break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerAction();
        }
    }
}
