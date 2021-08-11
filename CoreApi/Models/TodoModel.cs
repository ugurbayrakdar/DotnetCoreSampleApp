using System;

namespace CoreApi.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DoneAt { get; set; }
    }
}