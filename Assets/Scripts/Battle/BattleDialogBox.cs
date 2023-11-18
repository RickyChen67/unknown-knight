using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Color highlightColor;
    [SerializeField] float fontSize;
    [SerializeField] int dialogSpeed;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject abilitySelector;
    [SerializeField] GameObject itemSelector;

    [SerializeField] List<TMP_Text> actionTexts;
    [SerializeField] List<TMP_Text> moveTexts;
    [SerializeField] List<TMP_Text> abilityTexts;
    [SerializeField] List<TMP_Text> itemTexts;

    [SerializeField] TMP_Text actionDescription;
    [SerializeField] TMP_Text moveDescription;
    [SerializeField] TMP_Text abilityDescription;
    [SerializeField] TMP_Text itemDescription;

    public void SetDialog(string dialog)
    {
        dialogText.SetText(dialog);
    }

    public IEnumerator TypeDialog(string dialog)
    {
        string dialogString = "";
        dialogText.SetText(dialogString);
        foreach (var letter in dialog.ToCharArray())
        {
            dialogString += letter;
            dialogText.SetText(dialogString);
            yield return new WaitForSeconds(1f/ dialogSpeed);
        }
    }

    public IEnumerator TypeActionDialog()
    {
        string dialogString = "";
        actionDescription.SetText(dialogString);
        foreach (var letter in "Select an action".ToCharArray())
        {
            dialogString += letter;
            actionDescription.SetText(dialogString);
            yield return new WaitForSeconds(1f/ dialogSpeed);
        }
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
        actionDescription.enabled = enabled;
    }
    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDescription.enabled = enabled;
    }
    public void EnableAbilitySelector(bool enabled)
    {
        abilitySelector.SetActive(enabled);
        abilityDescription.enabled = enabled;
    }

    public void EnableItemSelector(bool enabled)
    {
        itemSelector.SetActive(enabled);
        itemDescription.enabled = enabled;
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; i++)
        {
            if (i == selectedAction)
                actionTexts[i].color = highlightColor;
            else
                actionTexts[i].color = Color.black;
        }
    }

    public void UpdateMoveSelection(int selectedAction, MonsterManager player)
    {
        for (int i = 0; i < moveTexts.Count; i++)
        {
            if (i == selectedAction)
                moveTexts[i].color = highlightColor;
            else
                moveTexts[i].color = Color.black;
        }

        if (selectedAction == 0)
        {
            moveDescription.enableAutoSizing = true;
            moveDescription.SetText(player.BasicAttackDescription);
        }
        else
        {
            moveDescription.fontSize = fontSize;
            moveDescription.enableAutoSizing = false;
            if (selectedAction == 1)
                moveDescription.SetText(player.DefendDescription);
            else if (selectedAction == 2)
                moveDescription.SetText("Use an Ability");
            else if (selectedAction == 3)
                moveDescription.SetText("Use an Item");
            else if (selectedAction == 4)
                moveDescription.SetText("Go Back");
        }
    }

    public void SetAbilityNames(List<Abilities> abilities)
    {

    }
}
