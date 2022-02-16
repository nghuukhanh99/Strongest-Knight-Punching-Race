using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    public int maxHP = 5;

    int currentHP;

    Animator EnemyAnim;

    public GameObject ScoreEnemy;

    public GameObject CollisionBlocker;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //currentHP = maxHP;

        EnemyAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        //currentHP -= damage;

        //if (currentHP <= 0)
        //{
        //    Die();
        //}
    }

   

    public void Die()
    {
        if (GameManager.Instance.isGameActive == true)
        {
            if (ScoreManager.Instance.score >= 5)
            {
                Debug.Log("Enemy Died!");

                //EnemyAnim.SetBool("isDie", true);

                GetComponent<Collider>().enabled = false;

                GetComponent<CapsuleCollider>().enabled = false;

                GetComponent<BoxCollider>().enabled = false;

                if(EnemyAnim != null)
                {
                    EnemyAnim.enabled = false;
                }

                CollisionBlocker.gameObject.SetActive(false);

                ScoreEnemy.gameObject.SetActive(false);

                ScoreManager.Instance.score -= 5;

                ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();

                StartCoroutine(DisableObject(gameObject));
            }

            //    if (ScoreManager.Instance.scoreBot1 >= 5)
            //    {
            //        EnemyAnim.SetBool("isDie", true);

            //        GetComponent<Collider>().enabled = false;

            //        this.enabled = false;

            //        ScoreManager.Instance.scoreBot1 -= 5;

            //        ScoreManager.Instance.scoreBot1Number.text = ScoreManager.Instance.scoreBot1.ToString();

            //        Destroy(this.gameObject, 3);
            //    }

            //    if (ScoreManager.Instance.scoreBot2 >= 5)
            //    {
            //        EnemyAnim.SetBool("isDie", true);

            //        GetComponent<Collider>().enabled = false;

            //        this.enabled = false;

            //        ScoreManager.Instance.scoreBot2 -= 5;

            //        ScoreManager.Instance.scoreBot2Number.text = ScoreManager.Instance.scoreBot2.ToString();

            //        Destroy(this.gameObject, 3);
            //    }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        

        //    if (other.gameObject.CompareTag("Bot1"))
        //    {
        //        Debug.Log("Collision with Bot1");
        //        if(ScoreManager.Instance.scoreBot1 < 5)
        //        {
        //            EnemyAnim.SetBool("isPunching", true);

        //            Bot1Ctrl.Instance.anim.SetBool("isDie", true);

        //            Bot1Ctrl.Instance.isDie = true;

        //            Destroy(other.gameObject, 4f);

        //            Debug.Log("is bot1 die");
        //        }
        //    }

        //    if (other.gameObject.CompareTag("Bot2"))
        //    {
        //        Debug.Log("Collision with Bot2");
        //        if (ScoreManager.Instance.scoreBot2 < 5)
        //        {
        //            EnemyAnim.SetBool("isPunching", true);

        //            Bot2Ctrl.Instance.anim.SetBool("isDie", true);

        //            Bot2Ctrl.Instance.isDie = true;

        //            Destroy(other.gameObject, 4f);

        //            Debug.Log("is bot1 die");
        //        }
        //    }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            EnemyAnim.SetBool("isPunching", false);
        }

        if (other.gameObject.CompareTag("Bot1"))
        {
            EnemyAnim.SetBool("isPunching", false);
        }

        if (other.gameObject.CompareTag("Bot2"))
        {
            EnemyAnim.SetBool("isPunching", false);
        }
    }

    public IEnumerator DisableObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

   
}
