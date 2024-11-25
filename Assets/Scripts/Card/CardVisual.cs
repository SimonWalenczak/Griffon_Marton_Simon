using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Card
{
    public class CardVisual : MonoBehaviour
    {
        [SerializeField] private TMP_Text _cardNameText;
        [SerializeField] private SpriteRenderer _cardIllustration;
        [SerializeField] private List<SpriteRenderer> _cardAttributeIcons;
        [SerializeField] private TMP_Text _innConditionText;
        [SerializeField] private SpriteRenderer _barConditionIcon;
        [SerializeField] private TMP_Text _consequenceText;
    
        public void Initialize(CardData data)
        {
            _cardNameText.text = data.cardName;
            _cardIllustration.sprite = data.cardSprite;

            for (int i = 0; i < data.attributes.Count; i++)
            {
                _cardAttributeIcons[i].gameObject.SetActive(true);
            }
        
            _innConditionText.text = data.InnConditionText;
            //_barConditionIcon.sprite = CardAttributeManager.Instance.GetSprite(data.BarCondition);
            //_consequenceText.text = data.LeaveEvent.Description;
        }
    }
}