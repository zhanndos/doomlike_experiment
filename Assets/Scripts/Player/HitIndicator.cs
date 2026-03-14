using UnityEngine;
using System.Collections;

public class HitIndicator : MonoBehaviour
{
    public void Show(Vector3 pos)
    {
        StartCoroutine(SphereIndicator(pos));
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.GetComponent<Renderer>().material.color = new Color(1f, 0f, 0.6f);

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
