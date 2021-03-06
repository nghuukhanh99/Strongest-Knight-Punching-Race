using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot1Ctrl : MonoBehaviour
{
    public static Bot1Ctrl Instance;

    public GameObject Bot1;

    public GameObject[] wps;

    public GameObject wpsLast;

    NavMeshAgent agent;

    public float moveSpeed;

    public Animator anim;

    public bool isDie = false;

    public GameObject ScoreBot1;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        setRigidbodyState(true);

        setColliderState(false);

        if (PlayerCtrl.Instance.isPlayerDeath == false)
        {
            if (isDie == false)
            {
                agent = this.GetComponent<NavMeshAgent>();

                int direction = Random.Range(0, wps.Length);

                agent.SetDestination(wps[direction].transform.position);
            }
        }
    }

    
    void Update()
    {
        if(PlayerCtrl.Instance.isPlayerDeath == false)
        {

            if (isDie == false)
            {
                if (agent.remainingDistance < 2)
                {
                    int direction = Random.Range(0, wps.Length);

                    agent.SetDestination(wps[direction].transform.position);
                }

                if (agent.remainingDistance < 2 && ScoreManager.Instance.scoreBot1 >= 30)
                {
                    agent.SetDestination(wpsLast.transform.position);
                }

                bot1Moving();
            }
        }
    }

    public void Die()
    {
        isDie = true;

        GetComponent<Animator>().enabled = false;

        setRigidbodyState(false);

        setColliderState(true);

        ScoreManager.Instance.scoreBot1 -= 5;

        ScoreManager.Instance.scoreBot1Number.text = ScoreManager.Instance.scoreBot1.ToString();

        ScoreBot1.gameObject.SetActive(false);

        Destroy(gameObject, 3f);
    }

    public void bot1Moving()
    {
            anim.SetBool("isRun", true);

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(GameManager.Instance.isGameActive == true)
            {
                if(PlayerCtrl.Instance.isFinish == false)
                {
                    if (PlayerCtrl.Instance.isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.scoreBot1 >= 5)
                        {
                            anim.SetTrigger("isAttack");

                            EnemyScriptTest.Instance.DieWithBot1();
                        }

                        if (ScoreManager.Instance.scoreBot1 < 5 && EnemyScriptTest.Instance.isEnemyDie == false)
                        {
                            EnemyScriptTest.Instance.EnemyAnim.SetBool("isPunching", true);

                            isDie = true;

                            Die();
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            if (GameManager.Instance.isGameActive == true)
            {
                if (PlayerCtrl.Instance.isFinish == false)
                {
                    if (PlayerCtrl.Instance.isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.scoreBot1 >= 5)
                        {
                            anim.SetTrigger("isAttack");

                            EnemyScriptTest2.Instance.DieWithBot1();
                        }

                        if (ScoreManager.Instance.scoreBot1 < 5 && EnemyScriptTest2.Instance.isEnemyDie2 == false)
                        {
                            EnemyScriptTest2.Instance.EnemyAnim2.SetBool("isPunching", true);

                            isDie = true;

                            Die();
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            if (GameManager.Instance.isGameActive == true)
            {
                if (PlayerCtrl.Instance.isFinish == false)
                {
                    if (PlayerCtrl.Instance.isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.scoreBot1 >= 5)
                        {
                            anim.SetTrigger("isAttack");

                            EnemyScriptTest3.Instance.DieWithBot1();
                        }

                        if (ScoreManager.Instance.scoreBot1 < 5 && EnemyScriptTest3.Instance.isEnemyDie3 == false)
                        {
                            EnemyScriptTest3.Instance.EnemyAnim3.SetBool("isPunching", true);

                            isDie = true;

                            Die();
                        }
                    }
                }
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ScoreManager.Instance.increaseBot1Score();

            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Finish Point"))
        {
            Debug.Log("Game Over");

            GameManager.Instance.RestartButton.SetActive(true);

            Time.timeScale = 0;
        }
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
