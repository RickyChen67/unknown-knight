
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
}
