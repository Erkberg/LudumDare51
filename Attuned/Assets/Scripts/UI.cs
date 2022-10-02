using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Attuned
{
    public class UI : MonoBehaviour
    {
        public GameObject titleScreen;
        public GameObject ingameUi;
        public GameObject endScreen;

        public TextMeshProUGUI timerText;
        public TextMeshProUGUI wrongNotesText;
        public TextMeshProUGUI stateText;
        public TextMeshProUGUI levelText;

        private const string ListeningStateText = "Listening ...";
        private const string TuningStateText = "Tuning ...";

        private void Update()
        {
            if(Game.inst.IsIngame())
            {
                UpdateWrongNotesText();
            }            
        }

        public void UpdateWrongNotesText()
        {
            if(Game.inst.settings.wrongNotesAmountEnabled)
            {
                wrongNotesText.text = Game.inst.notes.GetWrongNotesAmount().ToString();
            }
            else
            {
                wrongNotesText.text = string.Empty;
            }
        }

        public void SetTimerText(float value)
        {
            timerText.text = value.ToString("0.00");
        }

        public void OnStartButtonClicked()
        {
            Game.inst.hardMode = false;
            titleScreen.SetActive(false);
            ingameUi.SetActive(true);
            Game.inst.OnStartGame();
        }

        public void OnStartHardButtonClicked()
        {
            Game.inst.hardMode = true;
            titleScreen.SetActive(false);
            ingameUi.SetActive(true);
            Game.inst.OnStartGame();
        }

        public void OnWrongAmountToggle(bool value)
        {
            Game.inst.settings.wrongNotesAmountEnabled = value;
        }

        public void OnWrongColorToggle(bool value)
        {
            Game.inst.settings.wrongNotesColorEnabled = value;
        }

        public void SetStateText(bool tuning)
        {
            stateText.text = tuning ? TuningStateText : ListeningStateText;
        }

        public void SetLevelText(string text)
        {
            levelText.text = text;
        }

        public void OnTimeScaleSlider(float value)
        {
            Game.inst.OnTimeChanged(value);
        }

        public void OnEnd()
        {
            ingameUi.SetActive(false);
            endScreen.SetActive(true);
            Game.inst.audio.OnEnd();
        }

        public void OnRestartButtonClicked()
        {
            Game.inst.Restart();
        }
    }
}
