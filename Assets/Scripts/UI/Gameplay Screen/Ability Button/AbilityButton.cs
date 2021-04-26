using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public abstract class AbilityButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public AbilitySwap.AbilityType abilityType;
    Image mainImage, secondaryImage;
    [SerializeField] [Range(0,1)] private float scaleX, scaleY;
    Color defaultColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<AbilitySwap>().SetAbilityType(abilityType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 scaleResult = new Vector3(1 + scaleX, 1 + scaleY, 1);
        transform.DOScale(scaleResult, .1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1, 1, 1), .1f);
    }

    public virtual void Awake()
    {
        mainImage = GetComponent<Image>();
        secondaryImage = transform.Find("Hotkey").GetComponent<Image>();
        defaultColor = mainImage.color;
    }

    private void Update()
    {
        if(AbilitySwap.currentAbilityType == abilityType)
        {
            mainImage.color = Color.green;
            secondaryImage.color = Color.green;
        } else 
        {
            mainImage.color = defaultColor;
            secondaryImage.color = defaultColor;
        }
    }
}
