using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector3 worldPos;

    public GameObject clickParticle;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Left Mouse Clicked");
            mousePos = Input.mousePosition;
            mousePos.z = 1.5f;
            worldPos = GetComponent<Camera>().ScreenToWorldPoint(mousePos);
            StartCoroutine(SpawnClickImpulse());
        }
    }

    IEnumerator SpawnClickImpulse()
    {
        yield return StartCoroutine("InstantiateClickImpulse", () =>
        {
            Debug.Log("Enemy unfrozen");
        }));
    }

    IEnumerator InstantiateClickImpulse()
    {
        yield return Instantiate(clickParticle, worldPos, Quaternion.identity);
    }
}