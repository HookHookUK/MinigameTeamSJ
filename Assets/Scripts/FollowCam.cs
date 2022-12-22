using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    Transform Pos;
    Vector3 camPos;
    // Start is called before the first frame update
    public void SetPos(GameObject obj)
    {
        if (obj == null) Pos = null;
        else 
        Pos = obj.transform;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Pos != null)
        {
            camPos = new Vector3(Pos.position.x + 5, transform.position.y, -1);
            transform.position = camPos;
        }
    }
}
