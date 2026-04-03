using System;

namespace API.Entities;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }= null!; // "Grade 10"

    public ICollection<Section> Sections { get; set; } = [];
}
