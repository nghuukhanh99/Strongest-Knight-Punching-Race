using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptTest2 : MonoBehaviour
{
    public static EnemyScriptTest2 Instance;

    public GameObject wall2;

    public Animator EnemyAnim2;

    public GameObject ScoreEnemy2;

    public bool isEnemyDie2;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnemyDie2 = false;

        setRigidbodyState(true);

        setColliderState(false);
    }

    public void DieWithPlayer()
    {
        isEnemyDie2 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        wall2.gameObject.SetActive(false);

        ScoreEnemy2.gameObject.SetActive(false);

        ScoreManager.Instance.score -= 5;

        ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();

        Destroy(gameObject, 3f);
    }

    public void DieWithBot1()
    {
        isEnemyDie2 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        Destroy(gameObject, 3f);

        wall2.gameObject.SetActive(false);

        ScoreEnemy2.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot1 -= 5;

        ScoreManager.Instance.scoreBot1Number.text = ScoreManager.Instance.scoreBot1.ToString();
    }

    public void DieWithBot2()
    {
        isEnemyDie2 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        Destroy(gameObject, 3f);

        wall2.gameObject.SetActive(false);

        ScoreEnemy2.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot2 -= 5;

        ScoreManager.Instance.scoreBot2Number.text = ScoreManager.Instance.scoreBot2.ToString();
    }

    void setRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
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
