using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform Pos;
    Vector3 camPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
        camPos = new Vector3(Pos.position.x+5, transform.position.y,-1);
        transform.position = camPos;
    }
}
