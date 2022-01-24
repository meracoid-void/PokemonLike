using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    GameObject _health;


    public void SetHP(float hpNormalized)
    {
        _health.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}
