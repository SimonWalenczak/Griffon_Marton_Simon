using System.Collections.Generic;
using Card;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public List<CardData> CardsInBar = new();

    public int CountGoblins()
    {
        int count = 0;
        foreach (CardData card in CardsInBar)
        {
            if (card.IsGoblin)
            {
                count++;
            }
        }

        return count;
    }

    public int CountCardsByAttribute(Attribute conditionAttribute)
    {
        int count = 0;
        foreach (CardData card in CardsInBar)
        {
            if (card.HasAttribute(conditionAttribute))
            {
                count++;
            }
        }

        return count;
    }
}
