using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        public new string name;
        public int changedPerTick = 1;
        public int maxWrong = 2;
        public int supportInstrumentId = -1;
        public float duration = 10f;
        public List<NoteData> noteData;

        public NoteData GetNoteData(Note.Id id)
        {
            return noteData.Find(x => x.id == id);
        }

        public bool ContainsNote(Note.Id id)
        {
            return GetNoteData(id) != null;
        }
    }
}
