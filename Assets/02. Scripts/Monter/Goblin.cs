using System;
using UnityEngine;

public class Goblin : Monster
{
    protected override void Init()
    {
        hp = 5f;
        moveSpeed = 3f;
    }
}
