using UnityEngine;

public class Hotbar : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Bridge");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Bridge);
        }
        else
        if (Input.GetKeyDown(KeyCode.W))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Hook");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Hook);
        }
        else
        if (Input.GetKeyDown(KeyCode.A))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Cannon");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Cannon);
        }
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Boat");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Boat);
        }
        else
        if (Input.GetKeyDown(KeyCode.S))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Wall");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Wall);
        }
        else
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // coloca um hightlight
            Debug.Log("AbilityType.Horn");
            GameManager.GetInstance().SetAbilityType(AbilitySwap.AbilityType.Horn);
        }
    }

}
