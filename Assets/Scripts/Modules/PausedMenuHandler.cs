using UnityEngine;
using UnityEngine.SceneManagement;
using Flower;

namespace Modules
{  
    public class PausedMenuHandler
    {
        private FlowerSystem fs;
        private bool isPaused = false;

        public PausedMenuHandler(FlowerSystem fs)
        {
            this.fs = fs;
        }

        public void TogglePause()
        {
            Debug.Log("Paused Menu Handler");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            isPaused = true;
            Time.timeScale = 0;
            SetupPauseMenu();
        }

        private void ResumeGame()
        {
            isPaused = false;
            Time.timeScale = 1;
            fs.RemoveButtonGroup();
        }

        private void SetupPauseMenu()
        {
            fs.SetupButtonGroup();
            fs.SetupButton("繼續", () => {
                ResumeGame();
            });
            fs.SetupButton("返回主畫面", () => {
                Time.timeScale = 1;
                fs.ReadTextFromResource("Txtfiles/BackToSubMenu");
                fs.RemoveButtonGroup();
                SceneManager.LoadScene("SubMenu");
            });

            fs.SetupButton("重新此場景", () => {
                Time.timeScale = 1;
                fs.RemoveButtonGroup();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }
    }
}
