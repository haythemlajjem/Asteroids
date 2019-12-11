// script de l'état de scéne 
using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazard1;
    public GameObject enemy;
    public GameObject enemy1;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    
    Text text;



    private bool gameOver;
    private bool restart;
    private int score;
    


    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
    
    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);


            }
        }
        
    }
   
     IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            
            for (int i = 0; i < hazardCount; i++)
            {
                if (i==9)
                {
                    Instantiate(enemy1);
                }
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                Vector3 spawnPosition1 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, -spawnValues.z);
                Quaternion spawnRotation1 = Quaternion.identity;
                Instantiate(hazard1, spawnPosition1, spawnRotation1);
                yield return new WaitForSeconds(spawnWait);
                if (i == 4)
                {
                    Instantiate(enemy);
                }

                if (gameOver)
                {

                    restartText.text = "Restart 'R'";
                    restart = true;
                    break;
                }
            }
                yield return new WaitForSeconds(waveWait);

        }
    }
    //l'ajout du score lors de la mort d'un ennemie 
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
       

        }
    
    // mise à jour du score 
    void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    // affichage de la fin du jeu 

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
        
   
}
 