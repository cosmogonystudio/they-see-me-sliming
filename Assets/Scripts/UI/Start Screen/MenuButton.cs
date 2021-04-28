using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using TMPro;

public abstract class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField]
    [Range(0f, 1f)]
    private float scaleX;
    [SerializeField]
    [Range(0f, 1f)]
    private float scaleY;

    [SerializeField]
    private Vector3 color;

    private TextMeshProUGUI text;

    public abstract void OnPointerClick(PointerEventData eventData);

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 scaleResult = new Vector3(1f + scaleX, 1f + scaleY, 1f);
        transform.DOScale(scaleResult, 0.1f);

        text.color = new Color(color.x / 255f, color.y / 255f, color.z / 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);

        text.color = Color.white;
    }

    void Awake()
    {
        text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
    }

}
