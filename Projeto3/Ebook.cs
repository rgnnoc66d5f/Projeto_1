using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]
    internal class Ebook : Produtor, IEstoque 
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, string autor, float preco  )
        {
            this.nome = nome;
            this.autor = autor;
            this.preco = preco;
        }

        public void adiocinarEtrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-book, pois é Digital");
            Console.ReadLine();
        }

        public void Exiber()
        {
           
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"vendas Do Produto: {vendas}");
            Console.WriteLine("==================================");
        }

        public void adiocinarSaida()
        {
            Console.WriteLine($"adicionar saida de vendas do produto:{ nome }");
            Console.WriteLine("Digite o quanto, que você quer dar baixa:  ");
            int saida = int.Parse(Console.ReadLine());
            Console.WriteLine("saida registrada");
            vendas -= saida;
        }
    }
}
