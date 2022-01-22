using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase _base;
    int _level;
    public int HP { get; set; }

    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase basePokemon, int level)
    {
        _base = basePokemon;
        _level = level;
        HP = basePokemon.MaxHp;

        // Generate Moves
        Moves = new List<Move>();
        foreach(var move in _base.LearnableMoves)
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
        get { return Mathf.FloorToInt((_base.Attack * _level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * _level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * _level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((_base.SpDefense * _level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * _level) / 100f) + 5; }
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((_base.MaxHp * _level) / 100f) + 10; }
    }
}
