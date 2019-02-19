using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploVortice.Service.DTOs
{
    public class TodoItem
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
