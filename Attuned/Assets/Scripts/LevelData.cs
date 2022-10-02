using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attuned
{
    [CreateAssetMenu]
    public class LevelData : ScriptableObject
    {
        public int id;
        public int changedPerTick = 1;
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
