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

        public TextMeshProUGUI timerText;
        public TextMeshProUGUI wrongNotesText;

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
    }
}
