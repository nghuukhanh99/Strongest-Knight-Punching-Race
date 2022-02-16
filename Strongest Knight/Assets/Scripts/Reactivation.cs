using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactivation : MonoBehaviour
{
    public static Reactivation Instance;

    public bool ActivateOnStart = true;

    public float ActivationDelay = 5.0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(true);

        if (ActivateOnStart)
        {
            ActivateDelayed();
        }
    }

    private void AfterDelay()
    {
        gameObject.SetActive(true);

        
    }

    public void ActivateDelayed()
    {
        InvokeRepeating(nameof(AfterDelay), ActivationDelay, 7f);
    }

    public void ActivateDelayed(float customDelay)
    {
        Invoke(nameof(AfterDelay), customDelay);
    }
}
