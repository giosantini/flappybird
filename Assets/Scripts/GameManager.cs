using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    public int score { get; internal set; }

    private bool isGameOver = false;

    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

    public float obstacleInterval = 1;
    public float obstacleSpeed = 10;
    public float obstacleOffsetX = 0;

    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    
    void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }

    public bool IsGameActive(){
        return !isGameOver;
    }
    public bool IsGameOver(){
        return isGameOver;
    }
    public void EndGame() {
        isGameOver = true;
        StartCoroutine(ReloadScene(2));
    }
    
    private IEnumerator ReloadScene(float delay) {
        yield return new WaitForSeconds(delay);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
