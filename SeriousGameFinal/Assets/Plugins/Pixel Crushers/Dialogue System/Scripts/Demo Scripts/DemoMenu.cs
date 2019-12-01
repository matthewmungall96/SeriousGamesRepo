using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem.UnityGUI;

namespace PixelCrushers.DialogueSystem.Demo
{

    /// <summary>
    /// This script provides a rudimentary main menu for the Dialogue System's Demo.
    /// </summary>
    [AddComponentMenu("")] // Use wrapper.
    public class DemoMenu : MonoBehaviour
    {

        [TextArea]
        public string startMessage = "Press Escape for Menu";
        public KeyCode menuKey = KeyCode.Escape;
        public GUISkin guiSkin;
        public bool closeWhenQuestLogOpen = true;


        public UnityEvent onOpen = new UnityEvent();
        public UnityEvent onClose = new UnityEvent();

        public GameObject character;
        private QuestLogWindow questLogWindow = null;
        private bool isMenuOpen = false;
        private Rect windowRect = new Rect(0, 0, 500, 500);
        private ScaledRect scaledRect = ScaledRect.FromOrigin(ScaledRectAlignment.MiddleCenter, ScaledValue.FromPixelValue(300), ScaledValue.FromPixelValue(320));

        void Start()
        {
            if (questLogWindow == null) questLogWindow = FindObjectOfType<QuestLogWindow>();
            if (!string.IsNullOrEmpty(startMessage)) DialogueManager.ShowAlert(startMessage);
        }

        void Update()
        {
            if (Input.GetKeyDown(menuKey) && !DialogueManager.isConversationActive && !IsQuestLogOpen())
            {
                SetMenuStatus(!isMenuOpen);
            }
            // If you want to lock the cursor during gameplay, add ShowCursorOnConversation to the Player,
            // and uncomment the code below:
            //if (!DialogueManager.isConversationActive && !isMenuOpen && !IsQuestLogOpen ()) 
            //{
            //	Screen.lockCursor = true;
            //}
        }

        void OnGUI()
        {
            if (isMenuOpen && !IsQuestLogOpen())
            {
                if (guiSkin != null)
                {
                    GUI.skin = guiSkin;
                }
                windowRect = GUI.Window(0, windowRect, WindowFunction, "Menu");
            }
        }

        private void WindowFunction(int windowID)
        {
            if (GUI.Button(new Rect(10, 50, windowRect.width - 20, 48), "Quest Log"))
            {
                if (closeWhenQuestLogOpen) SetMenuStatus(false);
                OpenQuestLog();
            }

            if (GUI.Button(new Rect(10, 200, windowRect.width - 20, 48), "Return to Main Menu"))
            {
                SetMenuStatus(false);
                ClearSavedGame();
            }
        }

        public void Open()
        {
            SetMenuStatus(true);
        }

        public void Close()
        {
            SetMenuStatus(false);
        }

        private void SetMenuStatus(bool open)
        {
            isMenuOpen = open;
            if (open) windowRect = scaledRect.GetPixelRect();
            Time.timeScale = open ? 0 : 1;
            if (open) onOpen.Invoke(); else onClose.Invoke();
        }

        private bool IsQuestLogOpen()
        {
            return (questLogWindow != null) && questLogWindow.isOpen;
        }

        public void OpenQuestLog()
        {
            if ((questLogWindow != null) && !IsQuestLogOpen())
            {
                questLogWindow.Open();
            }
        }

        private void SaveGame()
        {
            var saveSystem = FindObjectOfType<SaveSystem>();
            if (saveSystem != null)
            {
                SaveSystem.SaveToSlot(1);
            }
            else
            {
                string saveData = PersistentDataManager.GetSaveData();
                PlayerPrefs.SetString("SavedGame", saveData);
                Debug.Log("Save Game Data: " + saveData);
            }
            DialogueManager.ShowAlert("Game saved.");
        }

        private void LoadGame()
        {
            PersistentDataManager.LevelWillBeUnloaded();
            var saveSystem = FindObjectOfType<SaveSystem>();
            if (saveSystem != null)
            {
                if (SaveSystem.HasSavedGameInSlot(1))
                {
                    SaveSystem.LoadFromSlot(1);
                    DialogueManager.ShowAlert("Game loaded.");
                }
                else
                {
                    DialogueManager.ShowAlert("Save a game first.");
                }
            }
            else
            {
                if (PlayerPrefs.HasKey("SavedGame"))
                {
                    string saveData = PlayerPrefs.GetString("SavedGame");
                    Debug.Log("Load Game Data: " + saveData);
                    LevelManager levelManager = FindObjectOfType<LevelManager>();
                    if (levelManager != null)
                    {
                        levelManager.LoadGame(saveData);
                    }
                    else
                    {
                        PersistentDataManager.ApplySaveData(saveData);
                        DialogueManager.SendUpdateTracker();
                    }
                    DialogueManager.ShowAlert("Game loaded.");
                }
                else
                {
                    DialogueManager.ShowAlert("Save a game first.");
                }
            }
        }

        public void ClearSavedGame()
        {
            Destroy(this.character);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("MainMenu");
        }

    }

}
