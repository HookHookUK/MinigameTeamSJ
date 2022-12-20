using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CO_BeSmall());
    }

    IEnumerator CO_BeSmall()
    {
        float time = 0f;
        while(time < 1f)
        {
            transform.localScale += new Vector3(-0.01f, -0.01f);
            time += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Destroy(gameObject);
    }
}
