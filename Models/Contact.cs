namespace ProjetoMVC.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Telephone { get; set; } = string.Empty;
        public bool? Active { get; set; }
    }
}
