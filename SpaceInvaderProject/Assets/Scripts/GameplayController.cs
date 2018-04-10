using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

    public GameObject ship;
    public GameObject wave;
    public GameObject cannon;
    public GameObject liveobj;
    public GameObject resBolt;
    public GameObject BOSS;

    public Text scoreText;
    private int score;
    public Text specialShotsText;
    private int numResBolt;
    public Text levelText;
    private int level;
    public int bossLevel;
    private int BossHP;
    public int BossMaxHP;
    public Text VictoryText;
    public Text PercentText;
    public RawImage HPimg;
    public Text BOSSHPText;

    public int loseLiveScore;
    public int clearAllScore;
    public int clearBossScore;

    private int lives;
    public Vector3[] livePos = {
        new Vector3(6.6f, 0.0f, 4.5f),
        new Vector3(7.4f, 0.0f, 4.5f),
        new Vector3(8.2f, 0.0f, 4.5f)
    };
    public GameObject[] players;

    private bool gameOver;
    public Text gameOverText;
    public Text LoseLiveText;

    private bool gamePause;




    // Use this for initialization
    void Start() {
        LoseLiveText.text = "";
        VictoryText.text = "";
        gameOverText.text = "";
        gameOver = false;
        gamePause = false;
        score = 0;
        lives = 3;
        numResBolt = 0;
        level = 1;
        BossHP = BossMaxHP;

        BOSSHPText.text = "";
        PercentText.text = "";
        HPimg.transform.localScale = new Vector3(0.0f, 1.0f, 1.0f);

        UpdateScore();
        InvokeRepeating("GenerateShip", 4.0f, 10.0f);
        InvokeRepeating("GenerateResBolt", 4.0f, 10.0f);
        //GenerateResBolt();
        //GenerateShip();
        GenerateWave();
    }


    void Update() {
        if (gameOver)
        {
            //SceneManager.LoadScene("GameOver");
            GameObject currentwave = GameObject.FindWithTag("Wave");
            Destroy(currentwave);
            gameOverText.text = "Game Over !";
            Invoke("ReturnIntro", 5.0f);

        }

    }

    void GenerateShip() {
        float value = Random.Range(0.0f, 1.0f);
        if (value < 0.4 && gamePause == false)
        {
            Vector3 pos = new Vector3(-8.0f, 0.0f, 3.6f);
            Instantiate(ship, pos, Quaternion.identity);
        }
    }

    public void GenerateWave() {
        gamePause = false;
        Vector3 pos = new Vector3(-3.5f, 0.0f, 1.0f);
        Instantiate(wave, pos, Quaternion.identity);
    }

    public void GenerateResBolt() {
        float value = Random.Range(0.0f, 1.0f);
        if (value < 0.6 && gamePause == false)
        {
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, 0, 90);
            Vector3 pos = new Vector3(Random.Range(-6.5f, 6.5f), 0.0f, 4.0f);
            Instantiate(resBolt, pos, rotation);
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "SCORE  " + score;
    }

    public void LoseLive()
    {
        //game over
        lives -= 1;

        AddScore(loseLiveScore);

        if (lives <= 0)
        {
            Destroy(players[lives]);
            gameOver = true;
            return;
        }

        //Debug.Log(lives);
        Destroy(players[lives]);
        if (level < bossLevel)
            UpdateWaves();
        else
            Invoke("GeneratePlayer", 1.0f);
    }


    public void AddLive()
    {
        if (lives >= 3)
            return;
        lives += 1;
        players[lives-1] = Instantiate(liveobj, livePos[lives - 1], Quaternion.identity);
    }


    void UpdateWaves()
    {
        GameObject currentwave = GameObject.FindWithTag("Wave");
        Destroy(currentwave);
        LoseLiveText.text = "You Lost One Life !";
        gamePause = true;

        GameObject[] deadbodies = GameObject.FindGameObjectsWithTag("deadbody");
        foreach (GameObject deadbody in deadbodies)
        {
            Destroy(deadbody.gameObject);
        }

        Invoke("Destroytext", 4.0f);
        Invoke("GenerateWave", 4.0f);
        Invoke("GeneratePlayer", 4.0f);
        //GenerateWave();
        //GeneratePlayer();
    }

    void Destroytext()
    {
        LoseLiveText.text = "";
    }

    void GeneratePlayer()
    {
        Vector3 pos = new Vector3(0.0f, 0.0f, -3.7f);
        Instantiate(cannon, pos, Quaternion.identity);
    }

    public void AddResBolt()
    {
        numResBolt += 1;
        specialShotsText.text = "FIRE COVER: " + numResBolt;
    }

    public int GetNumResBolt()
    {
        return numResBolt;
    }

    public void LoseResBolt()
    {
        numResBolt -= 1;
        specialShotsText.text = "FIRE COVER: " + numResBolt;
    }

    public void AddLevel()
    {
        level += 1;
        levelText.text = "LEVEL " + level;
    }

    public int GetLevel()
    {
        return level;
    }

    public void GenerateBoss()
    {
        Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
        Instantiate(BOSS, pos, Quaternion.identity);
        levelText.text = "BOSS LEVEL";
        BOSSHPText.text = "Destroyer";
        PercentText.text = "100%";
        HPimg.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        gamePause = true;
    }

    public void BossLoseHP()
    {
        //Victory
        if (BossHP <= 1)
        {
            GameObject currentBoss = GameObject.FindWithTag("BOSS");
            Destroy(currentBoss);
            Destroy(PercentText);
            Destroy(HPimg);
            Destroy(BOSSHPText);
            AddScore(clearBossScore);
            VictoryText.text = "Victory !";

            //gamePause = true;
            Invoke("ReturnIntro", 5.0f);
            return;
        }

        BossHP -= 1;
        PercentText.text = 100.0f * BossHP / BossMaxHP + "%";
        HPimg.transform.localScale -= new Vector3(0.05f, 0.0f, 0.0f);
        //血条
    }

    void ReturnIntro()
    {
        SceneManager.LoadScene("Intro");
    }

}
