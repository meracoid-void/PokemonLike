using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new Pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField]
    string name;
    [TextArea]
    [SerializeField]
    string description;

    [SerializeField]
    Sprite frontSprite;
    [SerializeField]
    Sprite backSprite;

    [SerializeField]
    PokemonType type1;
    [SerializeField]
    PokemonType type2;

    //Base Stats
    [SerializeField]
    int maxHp;
    [SerializeField]
    int attack;
    [SerializeField]
    int defense;
    [SerializeField]
    int spAttack;
    [SerializeField]
    int spDefense;
    [SerializeField]
    int speed;

    [SerializeField]
    List<LearnableMoves> learnableMoves;


    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public PokemonType Type1
    {
        get { return type1; }
    }

    public PokemonType Type2
    {
        get { return type2; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpAttack
    {
        get { return spAttack; }
    }

    public int SpDefense
    {
        get { return spDefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public List<LearnableMoves> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField]
    MoveBase moveBase;

    [SerializeField]
    int level;

    public MoveBase MoveBase
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}


public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Poison,
    Steel,
    Ice,
    Fighting,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dark,
    Dragon,
    Fairy
}

public class TypeChart
{
    // From https://pokemondb.net/type
    static float[][] chart =
    {
        //                        NOR FIR WAT ELE GRA PSN STL ICE FIG GND FLY PSY BUG ROC GHO DRK DRA FAI
        /*NOR*/      new float[] {1f, 1f, 1f, 1f, 1f, 1f,0.5f, 1f, 1f, 1f, 1f, 1f, 1f,0.5f, 0f, 1f, 1f, 1f},
        /*FIR*/      new float[] {1f,0.5f,0.5f, 1f,2f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 2f,0.5f, 1f, 1f,0.5f, 1f},
        /*WAT*/      new float[] {1f, 2f,0.5f, 1f,0.5f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f, 1f, 1f,0.5f, 1f},
        /*ELE*/      new float[] {1f, 1f, 2f,0.5f,0.5f, 1f, 1f, 1f, 1f, 0f, 2f, 1f, 1f, 1f, 1f, 1f,0.5f, 1f},
        /*GRA*/      new float[] {1f,0.5f, 2f, 1f,0.5f,0.5f,0.5f, 1f, 1f, 2f,0.5f, 1f,0.5f, 2f, 1f, 1f,0.5f, 1f},
        /*PSN*/      new float[] {1f, 1f, 1f, 1f, 2f,0.5f, 0f, 1f, 1f,0.5f, 1f, 1f, 1f,0.5f,0.5f, 1f, 1f, 2f},
        /*STL*/      new float[] {1f,0.5f,0.5f,0.5f, 1f, 1f,0.5f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 2f},
        /*ICE*/      new float[] {1f,0.5f,0.5f, 1f, 2f, 1f,0.5f,0.5f, 1f, 2f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 1f},
        /*FIG*/      new float[] {2f, 1f, 1f, 1f, 1f,0.5f, 2f, 2f, 1f, 1f,0.5f,0.5f,0.5f, 2f, 0f, 2f, 1f,0.5f},
        /*GND*/      new float[] {1f, 2f, 1f, 2f,0.5f, 2f, 2f, 1f, 1f, 1f, 0f, 1f,0.5f, 2f, 1f, 1f, 1f, 1f},
        /*FLY*/      new float[] {1f, 1f, 1f,0.5f, 2f, 1f,0.5f, 1f, 2f, 1f, 1f, 1f, 2f,0.5f, 1f, 1f, 1f, 1f},
        /*PSY*/      new float[] {1f, 1f, 1f, 1f, 1f, 2f,0.5f, 1f, 2f, 1f, 1f,0.5f, 1f, 1f, 1f, 0f, 1f, 1f},
        /*BUG*/      new float[] {1f,0.5f, 1f, 1f, 2f,0.5f,0.5f, 1f,0.5f, 1f,0.5f, 2f, 1f, 1f,0.5f, 2f,0.5f,0.5f},
        /*ROC*/      new float[] {1f, 2f, 1f, 1f, 1f, 1f,0.5f, 2f,0.5f,0.5f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, 1f},
        /*GHO*/      new float[] {0f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 2f,0.5f, 1f, 1f},
        /*DRK*/      new float[] {1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f,0.5f, 1f, 1f, 2f, 1f, 1f, 2f,0.5f, 1f,0.5f},
        /*DRA*/      new float[] {1f, 1f, 1f, 1f, 1f, 1f,0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 0f},
        /*FAI*/      new float[] {1f,0.5f, 1f, 1f, 1f,0.5f,0.5f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f},
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenseType)
    {
        if(attackType == PokemonType.None || defenseType == PokemonType.None)
        {
            return 1;
        }

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        return chart[row][col];
    }
}