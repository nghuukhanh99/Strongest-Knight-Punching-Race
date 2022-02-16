using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptTest3 : MonoBehaviour
{
    public static EnemyScriptTest3 Instance;

    public Animator EnemyAnim3;

    public GameObject wall3;

    public GameObject ScoreEnemy3;

    public bool isEnemyDie3;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnemyDie3 = false;

        setRigidbodyState(true);

        setColliderState(false);
    }

    public void DieWithPlayer()
    {
        isEnemyDie3 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        Destroy(gameObject, 3f);

        wall3.gameObject.SetActive(false);

        ScoreEnemy3.gameObject.SetActive(false);

        ScoreManager.Instance.score -= 5;

        ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();
    }

    public void DieWithBot1()
    {
        isEnemyDie3 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        wall3.gameObject.SetActive(false);

        ScoreEnemy3.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot1 -= 5;

        ScoreManager.Instance.scoreBot1Number.text = ScoreManager.Instance.scoreBot1.ToString();

        Destroy(gameObject, 3f);
    }

    public void DieWithBot3()
    {
        isEnemyDie3 = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        wall3.gameObject.SetActive(false);

        ScoreEnemy3.gameObject.SetActive(false);

        ScoreManager.Instance.scoreBot2 -= 5;

        ScoreManager.Instance.scoreBot2Number.text = ScoreManager.Instance.scoreBot2.ToString();

        Destroy(gameObject, 3f);
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
