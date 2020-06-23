using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtAniversarioWebCore.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int DiasRestantes { get; set; }

        public Pessoa() 
        {

        }

        public Pessoa(String nome, String sobrenome, DateTime data)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = data;
        }

        public int QntosDiasFaltam()
        {
            DateTime today = DateTime.Today;
            DateTime niver = new DateTime(today.Year, DataNascimento.Month, DataNascimento.Day);

            if (niver < today)
            {
                niver = niver.AddYears(1);
            }

            int diasRestantes = (niver - today).Days;
            return diasRestantes;
        }

        
        public int ExibirAniversariantesDoDia()
        {
            var proximoNiver = this.DataNascimento.AddYears(DateTime.Now.Year - this.DataNascimento.Year);
            proximoNiver = (proximoNiver.Date < DateTime.Now.Date) ? proximoNiver.AddYears(1) : proximoNiver;
            var teste = (proximoNiver.Date - DateTime.Now.Date).Days;
            return (proximoNiver - DateTime.Now.Date).Days;
        }
    }
}
