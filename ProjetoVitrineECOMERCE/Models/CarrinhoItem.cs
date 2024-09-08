using System.ComponentModel.DataAnnotations;

namespace ProjetoVitrineECOMERCE.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }

        public int BoneId { get; set; }

        public Bone Bone { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public decimal PrecoTotal => Bone.Preco * Quantidade;
    }
}
