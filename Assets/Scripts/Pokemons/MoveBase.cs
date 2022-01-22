using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create new move")]
public class MoveBase : ScriptableObject
{
    [SerializeField]
    string _name;

    [TextArea]
    [SerializeField]
    string _description;

    [SerializeField]
    PokemonType _type;

    [SerializeField]
    int _power;

    [SerializeField]
    int _accuracy;

    [SerializeField]
    int _pp;

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }

    public PokemonType Type
    {
        get { return _type; }
    }

    public int Power
    {
        get { return _power; }
    }

    public int Accuracy
    {
        get { return _accuracy; }
    }

    public int PP
    {
        get { return _pp; }
    }
}
