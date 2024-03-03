namespace WebApplication_Teste.Models

{
    public class Company
    {
        public int Id { get; set; }
        public string? AvatarUrl { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public int QtdeFuncionarios { get; set; }
        public bool Active { get; set; }
    }

}
