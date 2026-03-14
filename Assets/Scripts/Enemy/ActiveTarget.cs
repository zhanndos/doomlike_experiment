using System.Collections;
using UnityEngine;

public class ActiveTarget : MonoBehaviour, IHittable
{
    public void ReactToHit()
    {
        IKillable killable = GetComponent<IKillable>();
        if (killable != null)
        {
            killable.Die();
        }
    }
    
}
