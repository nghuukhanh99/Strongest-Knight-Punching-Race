using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KneelAnim : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }


    void Update()
    {
        if (PlayerCtrl.Instance.isFinish == true)
        {
            anim.SetBool("isFinish", true);
        }
    }
}
