using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacterCollision : MonoBehaviour
{
    public CapsuleCollider characterCollider;

    public CapsuleCollider characterBlockCollider;

    void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockCollider, true);
    }

   
}
