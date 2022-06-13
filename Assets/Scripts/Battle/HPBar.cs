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

    public IEnumerator SetHPSmooth(float newHP)
    {
        float curHP = _health.transform.localScale.x;
        float changeAmt = curHP - newHP;

        while(curHP - newHP > Mathf.Epsilon)
        {
            curHP -= changeAmt * Time.deltaTime;
            _health.transform.localScale = new Vector3(curHP, 1f);
            yield return null;
        }
        _health.transform.localScale = new Vector3(newHP, 1f);
    }
}
