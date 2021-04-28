using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public abstract class AbilityButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [HideInInspector]
    public AbilitySwap.AbilityType abilityType;

    [SerializeField]
    [Range(0f, 1f)]
    private float scaleX;
    [SerializeField]
    [Range(0f, 1f)]
    private float scaleY;

    private Image mainImage;
    private Image secondaryImage;

    private Color defaultColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.GetInstance().SetAbilityType(abilityType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 scaleResult = new Vector3(1f + scaleX, 1f + scaleY, 1f);
        transform.DOScale(scaleResult, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
    }

    protected virtual void Awake()
    {
        mainImage = GetComponent<Image>();
    }

    void Start()
    {
        secondaryImage = transform.Find("Hotkey").GetComponent<Image>();

        defaultColor = mainImage.color;
    }

    void Update()
    {
        if (GameManager.GetInstance().GetAbilityType() == abilityType)
        {
            mainImage.color = Color.green;
            secondaryImage.color = Color.green;
        }
        else 
        {
            mainImage.color = defaultColor;
            secondaryImage.color = defaultColor;
        }
    }

}
