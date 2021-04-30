using UnityEngine;

public class Hotbar : MonoBehaviour
{

    [Header("[0-Bridge, 1-Hook, 2-Cannon, 3-Boat, 4-Wall, 5-Horn]")]
    [SerializeField]
    private AbilityButton[] abilityButtons;

    public void ResetButtons()
    {
        for (int i = 0; i < abilityButtons.Length; i++)
        {
            abilityButtons[i].ResetButton();
        }
    }

    public void HighlightButton(int index)
    {
        ResetButtons();

        if (index > 0 && index < abilityButtons.Length)
        {
            abilityButtons[index].HighlightButton();
        }
    }

    void Start()
    {
        ResetButtons();

        GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.None);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Bridge);
        }
        else
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Hook);
        }
        else
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Cannon);
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Boat);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Wall);
        }
        else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Horn);
        }
    }

}
