﻿namespace FirstCoreMVCApplication.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
