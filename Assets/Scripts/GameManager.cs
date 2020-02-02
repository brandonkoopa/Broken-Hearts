using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public PartsDropper partsDropper;
  public RoundManager roundManager;
  public Canvas titleMenu;
  public Canvas gameOverMenu;
  public Canvas winMenu;

  // Start is called before the first frame update
  void Start()
  {
    showTitleMenu();
    roundManager.GameOver += showGameOverMenu;
    roundManager.WinRound += showWinMenu;
  }

  public void StartGame()
  {
    FindObjectOfType<AudioManager>().Play("Music");
    hideTitleMenu();
    roundManager.ResetGame();
    roundManager.EndRound();
  }

  public void showTitleMenu()
  {
    titleMenu.gameObject.SetActive(true);
    gameOverMenu.gameObject.SetActive(false);
  }

  public void hideTitleMenu()
  {
    titleMenu.gameObject.SetActive(false);
  }

  public void showGameOverMenu()
  {
    FindObjectOfType<AudioManager>().Stop("Music");
    FindObjectOfType<AudioManager>().Play("Air Horn");
    gameOverMenu.gameObject.SetActive(true);
    titleMenu.gameObject.SetActive(false);
  }

  public void hideGameOverMenu()
  {
    gameOverMenu.gameObject.SetActive(false);
    roundManager.ResetGame();
    roundManager.EndRound();
  }

  public void showWinMenu()
  {
    FindObjectOfType<AudioManager>().Stop("Music");
    FindObjectOfType<AudioManager>().Play("Ta Da");
    winMenu.gameObject.SetActive(true);
  }

  public void hideWinMenu()
  {
    winMenu.gameObject.SetActive(false);
    roundManager.EndRound();
  }
}
