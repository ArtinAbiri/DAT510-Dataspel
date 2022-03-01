using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class MainMenuController : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject settingsMenu;
 
 
        public void playGame() {
            SceneManager.LoadScene("Level_1");
        }
 
        public void settings() {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
 
        public void back() {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
 
        public void exitGame() {
            Application.Quit();
        }
    }   
}