using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core
{
    public class LevelController: MonoBehaviour
    {
        [SerializeField] private string nextScene;
        [SerializeField] private Text nextSceneText;
        private bool canInteract;
        private void Start()
        {
            nextSceneText.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (canInteract && Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("go to scene: " + nextScene);
                SceneManager.LoadScene(nextScene);
            } 
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                nextSceneText.gameObject.SetActive(true);
                canInteract = true;

            }
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                nextSceneText.gameObject.SetActive(false);
                canInteract = false;
            }
        }
    }
}