using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Dominio.Entidades
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O número máximo são de 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "O número máximo são de 500 caracteres")]
        public string Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public string Categoria { get; set; }
    }
}
