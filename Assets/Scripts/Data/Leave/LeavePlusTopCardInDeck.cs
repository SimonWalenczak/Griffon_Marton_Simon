using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Plus Top Card In Deck", menuName = "Data/Leave/Leave Plus Top Card In Deck", order = 0)]
public class LeavePlusTopCardInDeck : AbstractLeave
{
    public override int Execute(CardData card)
    {
        GameManager.Instance.inn.RemoveCard(card);

        GameManager.Instance.deck.DrawCard();
        
        return 0;
    }
}