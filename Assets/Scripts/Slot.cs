using Card;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [field: SerializeField] public bool HasCard { get; private set; }
    
    [field: SerializeField] public CardData Card { get; private set; }

    public void PlaceCard(CardData newCard)
    {
        if (HasCard == false)
        {
            Card = newCard;
            HasCard = true;
        }
    }

    public void RemoveCard()
    {
        Card = null;
        HasCard = false;
    }
}