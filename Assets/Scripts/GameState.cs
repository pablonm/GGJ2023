using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public static Ages previousAge = Ages.Contemporary;
    public static Ages currentAge = Ages.Contemporary;

    public static void SetNextAge(Ages nextAge)
    {
        if (currentAge != nextAge)
        {
            previousAge = currentAge;
            currentAge = nextAge;
        }
    }
}

public enum MiniGameNames {
    RomanEmpire,
}
