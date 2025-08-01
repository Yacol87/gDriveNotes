using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gDriveNotes.Domain.Entities
{
    public class MainNote
    {
        public int Id { get; set; }
        public string NoteContent { get; set; }
        public int NoteArea { get; set; }
        public int SenderId { get; set; }

        public MainNote(int id, string noteContent, int noteArea, int senderId)
        {
            Id = id;
            NoteContent = noteContent;
            NoteArea = noteArea;
            SenderId = senderId;
        }
        public MainNote() { }
    }
}
