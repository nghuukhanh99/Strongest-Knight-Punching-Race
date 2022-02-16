using EasyJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl Instance;

    public float moveSpeed;

    [SerializeField] private Joystick joystick;

    public GameObject Player;

    public Rigidbody rb;

    public Animator anim;

    public float rotationSpeed;

    public bool isPlayerDeath = false;

    public bool isFinish = false;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        if(GameManager.Instance.isGameActive == true)
        {
            if (isFinish == false)
            {
                if (isPlayerDeath == false)
                {
                    float xInput = joystick.Horizontal();

                    float zInput = joystick.Vertical();

                    Vector3 movementDirection = new Vector3(xInput, 0f, zInput);

                    movementDirection.Normalize();

                    transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);

                    if (movementDirection != Vector3.zero)
                    {
                        Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                        anim.SetBool("isRunning", true);
                    }
                    else
                    {
                        anim.SetBool("isRunning", false);
                    }
                }
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ScoreManager.Instance.increaseScore();

            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.Instance.isGameActive == true)
            {
                if (isFinish == false)
                {
                    if (isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.score >= 5)
                        {
                                anim.SetTrigger("isAttack");

                                EnemyScriptTest.Instance.DieWithPlayer();
                        }

                        if(ScoreManager.Instance.score < 5 && EnemyScriptTest.Instance.isEnemyDie == false)
                        {
                            isPlayerDeath = true;

                            EnemyScriptTest.Instance.EnemyAnim.SetBool("isPunching", true);

                            anim.SetBool("isDeath", true);

                            StartCoroutine("loadSceneIfDeath");
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            if (GameManager.Instance.isGameActive == true)
            {
                if (isFinish == false)
                {
                    if (isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.score >= 5)
                        {
                            anim.SetTrigger("isAttack");

                            EnemyScriptTest2.Instance.DieWithPlayer();
                        }

                        if (ScoreManager.Instance.score < 5 && EnemyScriptTest2.Instance.isEnemyDie2 == false)
                        {
                            isPlayerDeath = true;

                            EnemyScriptTest2.Instance.EnemyAnim2.SetBool("isPunching", true);

                            anim.SetBool("isDeath", true);

                            StartCoroutine("loadSceneIfDeath");
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            if (GameManager.Instance.isGameActive == true)
            {
                if (isFinish == false)
                {
                    if (isPlayerDeath == false)
                    {
                        if (ScoreManager.Instance.score >= 5)
                        {
                            anim.SetTrigger("isAttack");

                            EnemyScriptTest3.Instance.DieWithPlayer();
                        }

                        if (ScoreManager.Instance.score < 5 && EnemyScriptTest3.Instance.isEnemyDie3 == false)
                        {
                            isPlayerDeath = true;

                            EnemyScriptTest3.Instance.EnemyAnim3.SetBool("isPunching", true);

                            anim.SetBool("isDeath", true);

                            StartCoroutine("loadSceneIfDeath");
                        }
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Bot1"))
        {
            if(isFinish == false)
            {
                if(isPlayerDeath == false)
                {
                    if (ScoreManager.Instance.score >= ScoreManager.Instance.scoreBot1)
                    {
                        anim.SetTrigger("isAttack");

                        Bot1Ctrl.Instance.Die();

                        ScoreManager.Instance.score += 5;

                        ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();
                    }

                    if (ScoreManager.Instance.score < ScoreManager.Instance.scoreBot1 && Bot1Ctrl.Instance.isDie == false)
                    {
                        isPlayerDeath = true;

                        Bot1Ctrl.Instance.anim.SetTrigger("isAttack");

                        anim.SetBool("isDeath", true);

                        StartCoroutine("loadSceneIfDeath");
                    }
                }
            }
        }

        if (other.gameObject.CompareTag("Bot2"))
        {
            if (isFinish == false)
            {
                if (isPlayerDeath == false)
                {
                    if (ScoreManager.Instance.score >= ScoreManager.Instance.scoreBot2)
                    {
                        anim.SetTrigger("isAttack");

                        Bot2Ctrl.Instance.Die();

                        ScoreManager.Instance.score += 5;

                        ScoreManager.Instance.scoreNumber.text = ScoreManager.Instance.score.ToString();
                    }

                    if (ScoreManager.Instance.score < ScoreManager.Instance.scoreBot2 && Bot2Ctrl.Instance.isDie == false)
                    {
                        isPlayerDeath = true;

                        Bot2Ctrl.Instance.anim.SetTrigger("isAttack");

                        anim.SetBool("isDeath", true);

                        StartCoroutine("loadSceneIfDeath");
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish Point"))
        {
            anim.SetBool("isFinish", true);

            isFinish = true;

            rb.isKinematic = true;

            Debug.Log("finish");

            Debug.Log("NextRound");

            StartCoroutine(nextLevel());
        }
    }

    public IEnumerator loadSceneIfDeath()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(0);
    }

    public IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(5f);

        Time.timeScale = 1;

        SceneManager.LoadScene(1);
    }
}
