using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    BattleUnit playerUnit;
    [SerializeField]
    BattleUnit enemyUnit;
    [SerializeField]
    BattleHUD playerHUD;
    [SerializeField]
    BattleHUD enemyHUD;

    private void Start()
    {
        SetUpBattle();
    }

    public void SetUpBattle()
    {
        playerUnit.Setup();
        playerHUD.SetData(playerUnit.Pokemon);

        enemyUnit.Setup();
        enemyHUD.SetData(enemyUnit.Pokemon);
    }
}
