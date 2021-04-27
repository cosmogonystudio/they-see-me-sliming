using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAbility : SlimeTrigger
{
    [SerializeField] private float reach, height;
    Vector3 reachPoint, heightPoint;
    [SerializeField] private float launchSpeed;


    void CalculatePoints(Transform target)
    {
        reachPoint = target.position;
        reachPoint.x += reach;

        heightPoint = target.position;
        heightPoint.y += height;
        heightPoint.x += reach/2;
    }

    IEnumerator LerpThatShit(Rigidbody2D target)
    {
        float t = 0;
        while(t <= 1)
        {
            Vector3 AB = Vector3.Lerp(target.position, heightPoint, t);
            Vector3 BC = Vector3.Lerp(heightPoint, reachPoint, t);
            Vector3 ABC = Vector3.Lerp(AB, BC, t);

            target.MovePosition(ABC);

            yield return new WaitForEndOfFrame();
            t += 0.005f;
        }

        target.GetComponent<SlimeCheckGround>().enabled = true;
    }

    protected override void OnSlime(Slime slime)
    {
        slime.gameObject.tag = "Untagged";
        slime.gameObject.GetComponent<SlimeCheckGround>().enabled = false;
        CalculatePoints(slime.transform);
        StartCoroutine(LerpThatShit(slime.gameObject.GetComponent<Rigidbody2D>()));
    }    

}
