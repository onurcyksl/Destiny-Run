using RedBjorn.ProtoTiles.Example;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Dice dice;
    public UnitMove unitMove;

    public Dice getDice()
    {
        return dice;
    }
}
