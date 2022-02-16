using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptTest : MonoBehaviour
{
    public static EnemyScriptTest Instance;

    public Animator EnemyAnim;

    public GameObject wall1;

    public GameObject ScoreEnemy;

    public bool isEnemyDie;

    private void Awake()
    {
            Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnemyDie = false;

        setRigidbodyState(true);

        setColliderState(false);
    }

    public void DieWithPlayer()
    {
        isEnemyDie = true;

        GetComponent<Animator>().enabled = false;
      
        setRigidbodyState(false);

        setColliderState(true);

        Destroy(gameObject, 3f);

        wall1.gameObject.SetActive(false);

        ScoreEnemy.gameObject.SetActive(false);

        ScoreManager.Instance.score -= 5;

        ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();
    }

    public void DieWithBot1()
    {
        isEnemyDie = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        wall1.gameObject.SetActive(false);

        ScoreEnemy.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot1 -= 5;

        ScoreManager.Instance.scoreBot1Number.text = ScoreManager.Instance.scoreBot1.ToString();

        Destroy(gameObject, 3f);
    }

    public void DieWithBot2()
    {
        isEnemyDie = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        wall1.gameObject.SetActive(false);

        ScoreEnemy.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot2 -= 5;

        ScoreManager.Instance.scoreBot2Number.text = ScoreManager.Instance.scoreBot2.ToString();

        Destroy(gameObject, 3f);
    }


    void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] Colliders = GetComponentsInChildren<Collider>();

        foreach (Collider Collider in Colliders)
        {
            Collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
}
