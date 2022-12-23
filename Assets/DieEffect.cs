using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour
{
    ParticleSystem ptc;

    float time = 0;
    private void Awake()
    {
        ptc = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(CO_Expend());
        
    }

    IEnumerator CO_Expend()
    {
        while(time < 0.5f)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
            yield return new WaitForSecondsRealtime(0.01f);
            time += 0.01f;
        }
        time = 0;
        Destroy(transform.parent.gameObject);
    }
}
