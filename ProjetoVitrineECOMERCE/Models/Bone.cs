using System.ComponentModel.DataAnnotations;

namespace ProjetoVitrineECOMERCE.Models
{
    public class Bone
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public decimal Desconto { get; set; }

        [Required]
        public string Categoria { get; set; }

        public string Tamanho { get; set; }

        public string Sexo { get; set; }

        public string Marca { get; set; }

        [Url]
        public string UrlImagem { get; set; }
    }
}
