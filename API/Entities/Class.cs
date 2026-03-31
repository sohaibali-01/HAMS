using System;

namespace API.Entities;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } // "Grade 10"

    public ICollection<Section> Sections { get; set; } = new List<Section>();
}
