using System;

namespace ObjetoTransferencia
{
    public class Cliente
    {   
        public int IdCiente { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Boolean Sexo { get; set; }
        public decimal LimiteCompra { get; set; }
    }
}
