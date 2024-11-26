using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Plus Move Bar To Inn", menuName = "Data/Leave/Leave Plus Move Bar To Inn", order = 0)]
public class LeavePlusMoveBarToInn : AbstractLeave
{
    public override int Execute(CardData card)
    {
        int index = GameManager.Instance.inn.GetCardPosition(card);
        
        CardData tmp = GameManager.Instance.inn.CardsInInn[index];
        GameManager.Instance.inn.CardsInInn[index] = GameManager.Instance.inn.CardsInInn[0];
        GameManager.Instance.inn.CardsInInn[0] = tmp;
        
        GameManager.Instance.inn.RemoveCardAt(0);
        return -1;
    }
}