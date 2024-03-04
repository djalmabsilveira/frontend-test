using System.ComponentModel.DataAnnotations;

namespace WebApplication_Teste.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Url(ErrorMessage = "A URL do avatar não é válida.")]
        public string? AvatarUrl { get; set; }

        [Required(ErrorMessage = "O nome fantasia da empresa é obrigatório.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "A razão social da empresa é obrigatória.")]
        public string? RazaoSocial { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade de funcionários deve ser maior que zero.")]
        public int QtdeFuncionarios { get; set; }

        public bool Active { get; set; }
    }
}
