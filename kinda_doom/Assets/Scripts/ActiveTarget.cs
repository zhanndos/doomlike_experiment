using System.Collections;
using UnityEngine;

public class ActiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI ai = this.GetComponent<WanderingAI>(); // скрипт прикрепленный к врагу
        if (ai != null)
        {
            ai.SetAlive(false);
        }
        StartCoroutine(Die());       
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75f, 0, 0);
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
