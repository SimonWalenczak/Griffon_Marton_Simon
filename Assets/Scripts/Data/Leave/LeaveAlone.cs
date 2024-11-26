using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Alone", menuName = "Data/Leave/Leave Alone", order = 0)]
public class LeaveAlone : AbstractLeave
{
    public override void Execute(CardData card)
    {
        GameManager.Instance.inn.RemoveCard(card);
    }
}
