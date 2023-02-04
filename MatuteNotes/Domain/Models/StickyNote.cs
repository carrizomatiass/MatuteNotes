using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MatuteNotes.Domain.Models
{
    public class StickyNote
    {


        public StickyNote()
        {
            _id = string.Empty;
            _cliente = string.Empty;
            _createdDate = DateTime.Now;
            _editedDate = DateTime.Now;
            _content = string.Empty;
            _completed = false;
            _idUser = string.Empty;
            _priority = false;
            _deleted = false;
            _height = 142;
        }

        private string _id;
        private string _cliente;
        private DateTime _createdDate;
        private DateTime _editedDate;
        private string _content;
        private bool _completed;
        private string _idUser;
        private bool _priority;
        private bool _deleted;
        private int _height;

        [Key]
        public string Id { get => _id; set => _id = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime EditedDate { get => _editedDate; set => _editedDate = value; }
        public string Content { get => _content; set => _content = value; }
        public bool Completed { get => _completed; set => _completed = value; }
        public string IdUser { get => _idUser; set => _idUser = value; }
        public bool Priority { get => _priority; set => _priority = value; }
        public bool Deleted { get => _deleted; set => _deleted = value; }
        public int Height { get => _height; set => _height = value; }

    }
}
