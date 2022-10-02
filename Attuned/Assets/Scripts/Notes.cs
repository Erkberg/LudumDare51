using ErksUnityLibrary;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Attuned
{
    public class Notes : MonoBehaviour
    {
        public List<Note> allNotes;
        public List<Note> activeNotes;

        public void InitLevel(LevelData data)
        {
            activeNotes = new List<Note>();
            foreach(Note note in allNotes)
            {
                note.SetActive(false);

                if (data.ContainsNote(note.id))
                {
                    note.SetClip(data.GetNoteData(note.id).clip);
                    note.SetActive(true);
                    activeNotes.Add(note);
                }
            }
        }

        public void TriggerWrongNotes(LevelData data, bool firstTime)
        {
            List<Note> pickedNotes = new List<Note>();
            Debug.Log($"change {data.changedPerTick} notes");
            int amount = firstTime ? data.changedPerTick : Random.Range(1, data.changedPerTick + 1);
            
            // tune one correctly again if at max
            if(GetWrongNotesAmount() >= data.maxWrong)
            {
                GetRandomWrongNote().SetDeviationTuned();
                return;
            }
            else
            {
                // or cap limit
                while (amount + GetWrongNotesAmount() > data.maxWrong)
                {
                    amount--;
                }
            }

            for (int i = 0; i < amount; i++)
            {
                Note note = activeNotes.GetRandomItem();
                while(pickedNotes.Contains(note))
                {
                    note = activeNotes.GetRandomItem();
                }
                pickedNotes.Add(note);
            }

            foreach(Note note in pickedNotes)
            {
                note.RandomizeDeviation();
            }
        }

        public void SetSlidersActive(bool active)
        {
            foreach (Note note in activeNotes)
            {
                note.SetSliderActive(active);
            }
        }

        public int GetWrongNotesAmount()
        {
            int amount = 0;

            foreach (Note note in activeNotes)
            {
                if(note.IsWrong())
                {
                    amount++;
                }
            }

            return amount;
        }

        public Note GetRandomWrongNote()
        {
            List<Note> wrongNotes = new List<Note>();
            foreach (Note note in activeNotes)
            {
                if (note.IsWrong())
                {
                    wrongNotes.Add(note);
                }
            }
            return wrongNotes.GetRandomItem();
        }

        public void SetPitchAll(float value)
        {
            foreach (Note note in allNotes)
            {
                note.SetAsPitch(value);
            }
        }
    }
}
