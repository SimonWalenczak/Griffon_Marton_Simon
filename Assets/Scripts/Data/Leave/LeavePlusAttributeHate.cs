using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Plus Attribute Hate", menuName = "Data/Leave/Leave Plus Attribute Hate", order = 0)]
public class LeavePlusAttributeHate : AbstractLeave
{
    public Attribute HateAttribute;
    
    public override int Execute(CardData card)
    {
        int index = GameManager.Instance.inn.GetCardPosition(card);
        
        GameManager.Instance.inn.RemoveCard(card);

        return GameManager.Instance.inn.RemoveCardWithHateAttribute(HateAttribute, index);
    }
}