using System;
using System.Collections.Generic;
using UnityEngine;

namespace ADOAccuracy
{
    public class StatsMenu : MonoBehaviour
    {
        bool shouldDisplaySettings;
        int x;
        int y;
        int hitsX;
        int hitsY;
        int w = 1000;
        int h = 150;
        int fontSize;
        Font myFont;
        bool shouldShowAcc = true;
        public IDictionary<HitMargin, int> hitDict;
        public float currPerc;
        public float currAcc;
        int sW;
        int sH;
        int minimalistEnabled = 0;
        void Start()
        {
            sW = Screen.width / 2 - 150;
            sH = 45;
            hitDict = new Dictionary<HitMargin, int>()
            {
                { HitMargin.EarlyPerfect, 0 },
                { HitMargin.TooEarly, 0 },
                { HitMargin.VeryEarly, 0 },
                { HitMargin.Perfect, 0 },
                { HitMargin.TooLate, 0 },
                { HitMargin.VeryLate, 0 },
                { HitMargin.LatePerfect, 0 },
            };
            x = (Screen.width - w) / 2 + 1;
            y = (Screen.height / 2) - 250 + 1;
            fontSize = 75;
            if (PlayerPrefs.HasKey("accMinEn"))
            {
                minimalistEnabled = PlayerPrefs.GetInt("accMinEn");
            }
            else
            {
                PlayerPrefs.SetInt("accMinEn", minimalistEnabled);
            }
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
            if (PlayerPrefs.HasKey("accHitsX"))
            {
                hitsX = PlayerPrefs.GetInt("accHitsX");
            }
            else
            {
                PlayerPrefs.SetInt("accHitsX", hitsX);
            }
            if (PlayerPrefs.HasKey("accHitsY"))
            {
                hitsY = PlayerPrefs.GetInt("accHitsY");
            }
            else
            {
                PlayerPrefs.SetInt("accHitsY", hitsY);
            }
            if (PlayerPrefs.HasKey("accFontSize"))
            {
                fontSize = PlayerPrefs.GetInt("accFontSize");
            } else
            {
                PlayerPrefs.SetInt("accFontSize", fontSize);
            }
        }

        void LateUpdate()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha8))
            {
                shouldDisplaySettings = !shouldDisplaySettings;
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha7))
            {
                shouldShowAcc = !shouldShowAcc;
            }
        }
        public void OnGUI()
        {
            if (shouldDisplaySettings)
            {
                GUI.Box(new Rect(sW, sH, 250, 220), "Settings");
                GUI.Label(new Rect(sW + 10, sH + 30, 155, 100), "Acc X Pos: " + x.ToString());
                x = (int)GUI.HorizontalSlider(new Rect(sW + 110, sH + 30, 110, 20), x, 0, Screen.width);
                GUI.Label(new Rect(sW + 10, sH + 50, 155, 100), "Acc Y Pos: " + y.ToString());
                y = (int)GUI.HorizontalSlider(new Rect(sW + 110, sH + 50, 110, 20), y, 0, Screen.height);
                GUI.Label(new Rect(sW + 10, sH + 70, 155, 100), "Hits X Pos: " + hitsX.ToString());
                hitsX = (int)GUI.HorizontalSlider(new Rect(sW + 110, sH + 70, 110, 20), hitsX, 0, Screen.width);
                GUI.Label(new Rect(sW + 10, sH + 90, 155, 100), "Hits Y Pos: " + hitsY.ToString());
                hitsY = (int)GUI.HorizontalSlider(new Rect(sW + 110, sH + 90, 110, 20), hitsY, 0, Screen.height);
                GUI.Label(new Rect(sW + 10, sH + 110, 155, 100), "Font Size: " + fontSize.ToString());
                fontSize = (int)GUI.HorizontalSlider(new Rect(sW + 110, sH + 110, 110, 20), fontSize, 0, 100);
                if (GUI.Button(new Rect(sW + 10, sH + 130, 230, 20), minimalistEnabled == 0 ? "Enable Minimalist" : "Disable Minimalist"))
                {
                    if (minimalistEnabled == 0)
                    {
                        minimalistEnabled = 1;
                    } else
                    {
                        minimalistEnabled = 0;
                    }

                }
                if (GUI.Button(new Rect(sW + 10, sH + 150, 230, 20), "Save Settings"))
                {
                    PlayerPrefs.SetInt("accX", x);
                    PlayerPrefs.SetInt("accY", y);
                    PlayerPrefs.SetInt("accHitsX", hitsX);
                    PlayerPrefs.SetInt("accHitsY", hitsY);
                    PlayerPrefs.SetInt("accFontSize", fontSize);
                    PlayerPrefs.SetInt("accMinEn", minimalistEnabled);
                }
                if (GUI.Button(new Rect(sW + 10, sH + 170, 230, 20), "Donate"))
                {
                    System.Diagnostics.Process.Start("https://paypal.me/maxbridgland");
                }
                GUI.Label(new Rect(sW + 10, sH + 190, 230, 20), "Created by macs#0420");
            }
            if (FindObjectOfType<ADOBase>().controller.mistakesManager != null && shouldShowAcc)
            {
                if (myFont == null)
                {
                    myFont = RDString.GetFontDataForLanguage(RDString.language).font;
                }
                GUIStyle style = new GUIStyle();
                style.fontStyle = FontStyle.Bold;
                style.font = myFont;
                style.fontSize = fontSize;
                style.normal.textColor = Color.black;
                Rect rect2 = new Rect(x - 2, y - 2, w + 3, h + 3);
                Rect percRectBG = new Rect(rect2.x, rect2.y - 40, w + 3, h + 3);
                Rect hitsRectBG = new Rect(hitsX - 2, hitsY - 2, w + 3, h + 3);
                foreach (KeyValuePair<HitMargin, int> kp in this.hitDict)
                {
                    switch (kp.Key)
                    {
                        case HitMargin.TooEarly:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += 45;
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Too Early: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.VeryEarly:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 2);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Very Early: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.EarlyPerfect:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 3);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Early Perfect: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.Perfect:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 4);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Perfect: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.LatePerfect:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 5);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Late Perfect: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.VeryLate:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 6);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Very Late: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.TooLate:
                            hitsRectBG.y = hitsY - 2;
                            hitsRectBG.y += (45 * 7);
                            GUI.Label(hitsRectBG, minimalistEnabled == 0 ? "Too Late: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        default:
                            break;
                    }
                }
                GUI.Label(rect2, minimalistEnabled == 0 ? "Accuracy: " + (currAcc * 100).ToString() : (currAcc * 100).ToString() + "%", style);
                GUI.Label(percRectBG, minimalistEnabled == 0 ? "Percentage: " + ((Math.Truncate(currPerc * 100.0) / 100.0)).ToString() + "%" : ((Math.Truncate(currPerc * 100.0) / 100.0)).ToString() + "%", style);
                switch (currAcc)
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
                Rect percRect = new Rect(rect.x, rect.y - 45, w + 3, h + 3);
                GUI.Label(rect, minimalistEnabled == 0 ? "Accuracy: " + (currAcc * 100).ToString() + "%" : (currAcc * 100).ToString() + "%", style);
                Rect hitsRect = new Rect(hitsX, hitsY, w, h);
                style.normal.textColor = Color.green;
                GUI.Label(percRect, minimalistEnabled == 0 ? "Percentage: " + ((Math.Truncate(currPerc * 100.0) / 100.0)).ToString() + "%" : ((Math.Truncate(currPerc * 100.0) / 100.0)).ToString() + "%", style);
                foreach (KeyValuePair<HitMargin, int> kp in this.hitDict)
                {
                    switch (kp.Key)
                    {
                        case HitMargin.TooEarly:
                            style.normal.textColor = Color.red;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += 45;
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Too Early: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.VeryEarly:
                            style.normal.textColor = Color.red;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 2);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Very Early: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.EarlyPerfect:
                            style.normal.textColor = Color.yellow;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 3);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Early Perfect: " + kp.Value.ToString() : ""+ kp.Value.ToString(), style);
                            break;
                        case HitMargin.Perfect:
                            style.normal.textColor = Color.green;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 4);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Perfect: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.LatePerfect:
                            style.normal.textColor = Color.yellow;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 5);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Late Perfect: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.VeryLate:
                            style.normal.textColor = Color.red;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 6);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Very Late: " + kp.Value.ToString() : kp.Value.ToString(), style);
                            break;
                        case HitMargin.TooLate:
                            style.normal.textColor = Color.red;
                            hitsRect.y = hitsY - 2;
                            hitsRect.y += (45 * 7);
                            GUI.Label(hitsRect, minimalistEnabled == 0 ? "Too Late: " + kp.Value.ToString() : ""+ kp.Value.ToString(), style);
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }
    }
}
