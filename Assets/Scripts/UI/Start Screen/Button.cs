using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using TMPro;


public abstract class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] [Range(0,1)] private float scaleX , scaleY;
    [SerializeField] Vector3 color;
    TextMeshProUGUI text;

    public abstract void OnPointerClick(PointerEventData eventData);

    private void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 scaleResult = new Vector3(1 + scaleX, 1 + scaleY, 1);
        transform.DOScale(scaleResult, .1f);
        text.color = new Color(color.x / 255, color.y / 255, color.z / 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1, 1, 1), .1f);
        text.color = Color.white;
    }

}
