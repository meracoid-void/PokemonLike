using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase basePokemon, int level)
    {
        Base = basePokemon;
        Level = level;
        HP = MaxHp;

        // Generate Moves
        Moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            if(move.Level <= level)
            {
                Moves.Add(new Move(move.MoveBase));
            }

            if(Moves.Count >= 4)
            {
                break;
            }
        }

    }

    // https://bulbapedia.bulbagarden.net/wiki/Stat
    // TODO: Will need to update this when EV and IVs are in
    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; }
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((Base.MaxHp * Level) / 100f) + 10; }
    }

    public DamageDetails TakeDamage(Move move, Pokemon attacker)
    {
        float critical = 1f;
        if(Random.value * 100f  <= 6.25f)
        {
            critical = 2f;
        }

        float type = TypeChart.GetEffectiveness(move.Base.Type, this.Base.Type1) *
            TypeChart.GetEffectiveness(move.Base.Type, this.Base.Type2);

        var damangeDetails = new DamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            IsFainted = false
        };

        // Damage Calc https://bulbapedia.bulbagarden.net/wiki/Damage#Damage_calculation
        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            damangeDetails.IsFainted = true;
        }
        return damangeDetails;

    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}

public class DamageDetails
{
    public bool IsFainted { get; set; }
    public float Critical { get; set; }
    public float TypeEffectiveness { get; set; }
}
