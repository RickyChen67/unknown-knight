
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARBar : MonoBehaviour
{
    [SerializeField] GameObject armor;

    public void SetAR(float arNormalized)
    {
        armor.transform.localScale = new Vector3 (arNormalized, 1f);
    }
    public IEnumerator SetARSmooth(float newAR)
    {
        float currentHP = armor.transform.localScale.x;
        float changeAmont = currentHP - newAR;

        while (currentHP - newAR > Mathf.Epsilon)
        {
            currentHP -= changeAmont * Time.deltaTime;
            armor.transform.localScale = new Vector3(currentHP, 1f);
            yield return null;
        }
        armor.transform.localScale = new Vector3(newAR, 1f);
    }

}
