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

                switch (data.attributes[i])
                {
                    case Attribute.Beer:
                        _cardAttributeIcons[i].sprite = GameManager.Instance.SpriteAttributes[0];
                        break;
                    case Attribute.Food:
                        _cardAttributeIcons[i].sprite = GameManager.Instance.SpriteAttributes[1];
                        break;
                    case Attribute.Fight:
                        _cardAttributeIcons[i].sprite = GameManager.Instance.SpriteAttributes[2];
                        break;
                    case Attribute.Noise:
                        _cardAttributeIcons[i].sprite = GameManager.Instance.SpriteAttributes[3];
                        break;
                    case Attribute.Smell:
                        _cardAttributeIcons[i].sprite = GameManager.Instance.SpriteAttributes[4];
                        break;
                }
            }

            switch (data.BarCondition)
            {
                case Attribute.Beer:
                    _barConditionIcon.sprite = GameManager.Instance.SpriteAttributes[0];
                    break;
                case Attribute.Food:
                    _barConditionIcon.sprite = GameManager.Instance.SpriteAttributes[1];
                    break;
                case Attribute.Fight:
                    _barConditionIcon.sprite = GameManager.Instance.SpriteAttributes[2];
                    break;
                case Attribute.Noise:
                    _barConditionIcon.sprite = GameManager.Instance.SpriteAttributes[3];
                    break;
                case Attribute.Smell:
                    _barConditionIcon.sprite = GameManager.Instance.SpriteAttributes[4];
                    break;
            }
            
            _innConditionText.text = data.InnConditionText;
            _consequenceText.text = data.LeaveEvent.Description;
        }
    }
}