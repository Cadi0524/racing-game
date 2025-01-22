using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   public GameObject[] panels;
   public GameObject[] buttons;
   public GameObject maps;
   public GameObject flight;
   private GameManager gameManager;
   
   void Start()
   {
      panels[0].SetActive(true);
      panels[1].SetActive(false);
      
   }


   public void ClickStartButton()
   {
      panels[0].SetActive(false);
      maps.SetActive(true);
      GameManager.Instance.NewGame();
   }

  public void ClickRestartButton()
   {
      panels[1].SetActive(false);
      panels[0].SetActive(true);
      maps.SetActive(false);
   }

   public void GameOverPanel()
   {
      panels[1].SetActive(true);
   }
}