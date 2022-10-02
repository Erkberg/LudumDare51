using System.Collections;
using System.Collections.Generic;
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
    }
}
