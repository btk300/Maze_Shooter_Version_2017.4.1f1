using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour {
    public Text gameOver;
    public Text gameWin;
	// Use this for initialization
	void Start () {
        gameOver.enabled = false;
        gameWin.enabled = false;

    }
	public void GameOver()
    {
        StartCoroutine(GameOverDelay());
    }

    IEnumerator GameOverDelay()
    {
        gameOver.enabled = true;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Normal", LoadSceneMode.Single);
    }

    public void GameWin()
    {
        gameWin.enabled = true;
    }
}
