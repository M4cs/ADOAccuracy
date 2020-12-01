using UnityEngine;
namespace ADOAccuracy
{
    class StatsMenu : MonoBehaviour
    {
        bool shouldDisplaySettings;
        int x;
        int y;
        int w = 1000;
        int h = 150;
        void Start()
        {
            x = (Screen.width - w) / 2 + 1;
            y = (Screen.height / 2) - 250 + 1;
            if (PlayerPrefs.HasKey("accX"))
            {
                x = PlayerPrefs.GetInt("accX");
            } else
            {
                PlayerPrefs.SetInt("accX", x);
            }
            if (PlayerPrefs.HasKey("accY"))
            {
                y = PlayerPrefs.GetInt("accY");
            } else
            {
                PlayerPrefs.SetInt("accY", y);
            }
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha8))
            {
                shouldDisplaySettings = !shouldDisplaySettings;
            }
        }
        public void OnGUI()
        {
            if (shouldDisplaySettings)
            {
                GUI.Box(new Rect(10, 10, 250, 150), "Settings");
                GUI.Label(new Rect(10, 20, 230, 100), "X Pos: ");
                x = int.Parse(GUI.TextArea(new Rect(55, 20, 180, 20), x.ToString()));
                GUI.Label(new Rect(10, 40, 230, 100), "Y Pos: ");
                y = int.Parse(GUI.TextArea(new Rect(55, 40, 180, 20), y.ToString()));
                if (GUI.Button(new Rect(10, 60, 230, 20), "Save Settings"))
                {
                    PlayerPrefs.SetInt("accX", x);
                    PlayerPrefs.SetInt("accY", y);
                }
            }
            GUIStyle style = new GUIStyle();
            float acc = FindObjectOfType<ADOBase>().controller.mistakesManager.percentAcc;
            style.fontSize = 50;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = Color.black;
            Rect rect2 = new Rect(x, y, w + 3, h + 3);
            GUI.Label(rect2, "Current Accuracy: " + (acc * 100).ToString() + "%", style);
            switch (acc)
            {
                case float n when (n >= 1):
                    style.normal.textColor = Color.green;
                    break;
                case float n when (n < 1 && n >= 0.90):
                    style.normal.textColor = Color.yellow;
                    break;
                case float n when (n < 0.90):
                    style.normal.textColor = Color.red;
                    break;
                case float n when (n < 0.001):
                    style.normal.textColor = Color.green;
                    break;
                default:
                    style.normal.textColor = Color.green;
                    break;
            }
            Rect rect = new Rect(x, y, w, h);
            GUI.Label(rect, "Current Accuracy: " + (acc * 100).ToString() + "%", style);
            
        }
    }
}
