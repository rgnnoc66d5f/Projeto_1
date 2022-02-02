using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]
    internal class Curso : Produtor, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome,float preco,string autor)
        {
            this.nome = nome;
            this.preco = preco; 
            this.autor = autor; 
        }

        public void adiocinarEtrada()
        {
            Console.WriteLine($"adicionar entrada de vagas do curso:{ nome }");
            Console.WriteLine("Digite quanto. que você quer dar entrada:  ");
            int entrada = int.Parse(Console.ReadLine());
            Console.WriteLine("entrada registrada");
            vagas += entrada;
        }

        public void Exiber()
        {
            
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vagas: {vagas}");
            Console.WriteLine("==================================");
        }

        public void adiocinarSaida()
        {
            Console.WriteLine($"saida de vagas do curso:{ nome }");
            Console.WriteLine("Digite o quanto, que você quer dar baixa:  ");
            int saida = int.Parse(Console.ReadLine());
            Console.WriteLine("saida registrada");
            vagas -= saida;
        }
    }
}
