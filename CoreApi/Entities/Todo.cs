using System;

namespace CoreApi.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DoneAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}