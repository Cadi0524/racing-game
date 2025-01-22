using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   public GameObject[] panels;
   public GameObject[] buttons;
   public GameObject maps;
   public GameObject flight;
   
   void Start()
   {
      panels[0].SetActive(true);
      panels[1].SetActive(false);
   }


   public void ClickStartButton()
   {
      panels[0].SetActive(false);
      maps.SetActive(true);
      flight.SetActive(true);
   }

  public void ClickRestartButton()
   {
      panels[0].SetActive(true);
      maps.SetActive(false);
      flight.SetActive(false);
      panels[1].SetActive(false);
   }

   public void GameOverPanel()
   {
      panels[1].SetActive(true);
   }
}