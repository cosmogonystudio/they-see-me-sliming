using UnityEngine;

public class Hotbar : MonoBehaviour
{

    [SerializeField]
    private GameObject[] buttons;

    private void Start()
    {
        Reset();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetHotKey(AbilitySwap.AbilityType.Bridge);
        }
        else
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetHotKey(AbilitySwap.AbilityType.Hook);
        }
        else
        if (Input.GetKeyDown(KeyCode.A))
        {
            SetHotKey(AbilitySwap.AbilityType.Cannon);
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetHotKey(AbilitySwap.AbilityType.Boat);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetHotKey(AbilitySwap.AbilityType.Wall);
        }
        else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetHotKey(AbilitySwap.AbilityType.Horn);
        }
    }

    private void Reset()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    private void SetHotKey(AbilitySwap.AbilityType abilityType)
    {
        Highlight((int)abilityType);

        GameManager.GetInstance().SetAbilityType(abilityType);
    }

    private void Highlight(int index)
    {
        Reset();

        buttons[index].SetActive(true);
    }

}
