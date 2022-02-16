using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    public int scoreBot1 = 0;

    public int scoreBot2 = 0;

    public TextMeshProUGUI scoreNumber;

    public TextMeshPro scoreBot1Number;

    public TextMeshPro scoreBot2Number;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void increaseScore()
    {
        score++;

        scoreNumber.text = score.ToString();

        if (score == 5)
        {
            PlayerCtrl.Instance.Player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            PlayerCtrl.Instance.moveSpeed += 1f;
        }
        else if(score == 10)
        {
            PlayerCtrl.Instance.Player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            PlayerCtrl.Instance.moveSpeed += 2f;
        }
        else if(score == 15)
        {
            PlayerCtrl.Instance.Player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);

            PlayerCtrl.Instance.moveSpeed += 3f;
        }
    }

    public void increaseBot1Score()
    {
        
            scoreBot1++;

            scoreBot1Number.text = scoreBot1.ToString();

            if (scoreBot1 == 5)
            {
                if (scoreBot1Number != null)
                {
                    Bot1Ctrl.Instance.Bot1.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                }
            }
            else if (scoreBot1 == 10)
            {
                if (scoreBot1Number != null)
                {
                    Bot1Ctrl.Instance.Bot1.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                }
            }
            else if (scoreBot1 == 15)
            {
                if (scoreBot1Number != null)
                {
                    Bot1Ctrl.Instance.Bot1.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                }
            }
    }

    public void increaseBot2Score()
    {

        scoreBot2++;

        scoreBot2Number.text = scoreBot2.ToString();

        if (scoreBot2 == 5)
        {
            if (scoreBot2Number != null)
            {
                Bot2Ctrl.Instance.Bot2.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
        else if (scoreBot2 == 10)
        {
            if (scoreBot2Number != null)
            {
                Bot2Ctrl.Instance.Bot2.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
        else if (scoreBot2 == 15)
        {
            if (scoreBot2Number != null)
            {
                Bot2Ctrl.Instance.Bot2.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
            }
        }
    }

}
