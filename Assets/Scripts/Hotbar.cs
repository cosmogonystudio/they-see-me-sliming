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
            Highlight(0);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Bridge);
        }
        /*
        else
        if (Input.GetKeyDown(KeyCode.W))
        {
            Highlight(1);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Hook);
        }
        */
        else
        if (Input.GetKeyDown(KeyCode.A))
        {
            Highlight(2);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Cannon);
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            Highlight(3);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Boat);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            Highlight(4);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Wall);
        }
        else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Highlight(5);
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Horn);
        }
    }

    private void Reset()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    private void Highlight(int index)
    {
        Reset();

        buttons[index].SetActive(true);
    }

}
