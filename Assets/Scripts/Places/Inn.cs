using System.Collections.Generic;
using Card;
using UnityEngine;

public class Inn : MonoBehaviour
{
    public List<CardData> CardsInInn = new();

    public CardData GetCardAt(int cardFloor)
    {
        if (cardFloor < 0 || cardFloor + 1 > CardsInInn.Count)
        {
            return null;
        }

        return CardsInInn[cardFloor];
    }

    public int CountGoblins()
    {
        int count = 0;
        foreach (CardData card in CardsInInn)
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
        foreach (CardData card in CardsInInn)
        {
            if (card.HasAttribute(conditionAttribute))
            {
                count++;
            }
        }

        return count;
    }

    public int GetCardPosition(CardData cardData)
    {
        return CardsInInn.FindIndex(data => data.cardName == cardData.cardName);
    }
}
