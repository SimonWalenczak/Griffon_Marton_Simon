﻿using Card;
using UnityEngine;

[CreateAssetMenu(fileName = "Leave Plus Attribute Hate", menuName = "Data/Leave/Leave Plus Attribute Hate", order = 0)]
public class LeavePlusAttributeHate : AbstractLeave
{
    public Attribute HateAttribute;
    
    public override void Execute(CardData card)
    {
        GameManager.Instance.inn.RemoveCard(card);

        GameManager.Instance.inn.RemoveCardWithHateAttribute(HateAttribute);
    }
}