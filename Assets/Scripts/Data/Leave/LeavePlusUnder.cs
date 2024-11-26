using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Plus Under", menuName = "Data/Leave/Leave Plus Under", order = 0)]
public class LeavePlusUnder : AbstractLeave
{
    public override int Execute(CardData card)
    {
        int index = GameManager.Instance.inn.GetCardPosition(card);
        
        GameManager.Instance.inn.RemoveCardAt(index);
        GameManager.Instance.inn.RemoveCardAt(index - 1);

        return 1;
    }
}