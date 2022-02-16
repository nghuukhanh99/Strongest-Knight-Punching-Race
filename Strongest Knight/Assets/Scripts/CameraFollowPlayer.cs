using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform Target;

    public Vector3 Offset;

    public Vector3 Offset2;
    
    void Start()
    {
        
    }


    void Update()
    {
        this.transform.position = Target.position + Offset; 

        if(PlayerCtrl.Instance.isFinish == true)
        {
            this.transform.position = Target.position + Offset2;

            this.transform.rotation = Quaternion.Euler(new Vector3(15f, 140f, 0f));
        }
    }
}
