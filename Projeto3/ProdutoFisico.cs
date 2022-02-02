using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    [System.Serializable]
    internal class ProdutoFisico : Produtor, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco,float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete; 
            
       
        
        }

        public void adiocinarEtrada()
        {
            Console.WriteLine($"Digite entrada no estoque do produto:{ nome }" );
            Console.WriteLine("Digite o quanto. que você quer dar entrada:  ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
        }

        public void Exiber()
        {
          
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"frete {frete}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Estoque:{estoque}");
            Console.WriteLine("==================================");
        }

        public void adiocinarSaida()
        {
            Console.WriteLine($"adicionar saida do produto:{ nome }");
            Console.WriteLine("Digite o quanto, que você quer dar baixa:  ");
            int saida = int.Parse(Console.ReadLine());
            Console.WriteLine("saida registrada");
            estoque -= saida;
        }
    }
}
