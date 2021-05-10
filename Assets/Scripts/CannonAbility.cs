using System.Collections;
using UnityEngine;

public class CannonAbility : SlimeTrigger
{

    public float reach;
    public float height;

    public float launchSpeed;

    Vector3 reachPoint;
    Vector3 heightPoint;

    IEnumerator LerpThatShit(Rigidbody2D target)
    {
        float t = 0f;

        while (t <= 1f)
        {
            Vector3 AB = Vector3.Lerp(target.position, heightPoint, t);
            Vector3 BC = Vector3.Lerp(heightPoint, reachPoint, t);
            Vector3 ABC = Vector3.Lerp(AB, BC, t);

            target.MovePosition(ABC);

            yield return new WaitForEndOfFrame();

            t += 0.004f;
        }

        target.GetComponent<Slime>().Bullet(false);
        target.GetComponent<SlimeCheckGround>().enabled = true;
    }

    protected override void OnSlime(Slime slime)
    {
        slime.GetComponent<SlimeCheckGround>().enabled = false;

        AudioManager.GetInstance().PlayAbility(AbilitySwap.AbilityType.Cannon);

        CalculatePoints(slime.transform);

        slime.Bullet(true);

        StartCoroutine(LerpThatShit(slime.gameObject.GetComponent<Rigidbody2D>()));
    }

    private void CalculatePoints(Transform target)
    {
        reachPoint = target.position;
        reachPoint.x += reach;

        heightPoint = target.position;
        heightPoint.y += height;
        heightPoint.x += reach / 2f;
    }

}
