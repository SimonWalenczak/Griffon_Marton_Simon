using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Trigger Number Floor Down Unhappy", menuName = "Data/Leave/Trigger Number Floor Down Unhappy", order = 0)]
public class TriggerNumberFloorDownUnhappy : AbstractLeave
{
    public int FloorDelta;
    
    public override void Execute(CardData card)
    {
        int index = GameManager.Instance.inn.GetCardPosition(card);
        if (index - FloorDelta < 0)
        {
            return;
        }
        
        CardData toRemove = GameManager.Instance.inn.GetCardAt(index - FloorDelta);
        toRemove.LeaveEvent.Execute(card);
        GameManager.Instance.inn.RemoveCard(toRemove);
    }
}