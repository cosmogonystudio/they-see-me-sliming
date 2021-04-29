using UnityEngine;

public class Hotbar : MonoBehaviour
{

    private void Start()
    {
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
