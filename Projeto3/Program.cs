using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Projeto3
{
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu{ Lista = 1, Adicionar, Remover, Entrada , Saida , sair }

        static void Main(string[] args)
        {
           Carregar();
           bool escolheusair= false;
           while (escolheusair == false)
           {
               
                Console.WriteLine("---------------------- Sistema De Estoque -------------------------------------------");
                Console.WriteLine("1-Lista\n2-Adiciornar\n3-Remover\n4-Registro de Entrada\n5-Registro de Saida\n6-Sair");
                string sis = Console.ReadLine();
                int pro = int.Parse(sis);
                Menu esconha = (Menu)pro;
                if (pro > 0 && pro < 7)
                {
                    switch (esconha)
                    {
                        case Menu.Lista:
                            Listagem(); 
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            entrada();
                            break;
                        case Menu.Saida:
                            sair();
                            break;
                        case Menu.sair:
                            escolheusair = true;
                             break;
                    
                    }
                }
                else
                {
                    escolheusair = true;

            
                }            
            Console.Clear();
          
           }
              
        } 
    
         enum OP { Curso = 1, Ebook , ProdutoFisico, Sair  }
         static void Cadastro()
         {
            bool escolheusair = false;
            while (escolheusair == false)
            {
                Console.WriteLine("Cadastros");
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine("1-Curso\n2-Ebook\n3-ProdutoFisico\n4-Sair");
                string sis = Console.ReadLine();
                int pro = int.Parse(sis);
                OP esconha = (OP)pro;
                if (pro > 0 && pro < 5)
                {
                    switch (esconha)
                    {
                        case OP.Curso:
                            cadastraCurso();
                            break;

                        case OP.Ebook:
                            cadastroEbook();
                            break;

                        case OP.ProdutoFisico:
                            cadastraPFisico();
                            break;

                        case OP.Sair:
                            escolheusair = true;
                            break;
                    }
                }
                 
                
                    
                
                else
                {
                    escolheusair = true;

                }
                Console.Clear();
            }
            
         }
       
        static void Listagem()
        {
            Console.WriteLine("Lista de Produto");
            int I = 0;
           
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("id:" + I);
                produto.Exiber();
                I++;  
            }   
             Console.ReadLine();
        }
        
        static void Remover()
        {
            Listagem();
            Console.WriteLine("");
            Console.WriteLine("Digite o id quer você que remover");   
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }

        }
        static void entrada()
        {
            Listagem();
            Console.WriteLine("");
            Console.WriteLine("Digite o id quer você que dar entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].adiocinarEtrada();
                Salvar();
            }

        }
       
        
        
        static void sair()
        {
            Listagem();
            Console.WriteLine("");
            Console.WriteLine("Digite o id quer você que dar baixa");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].adiocinarSaida();
                Salvar();
            }
        }
        static void cadastraPFisico()
        {
            
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("nome:"); 
            string nome = Console.ReadLine();
            Console.WriteLine("preço:");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("frete:");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome,preco,frete);
            produtos.Add(pf);
            Salvar();
            Console.WriteLine("==================================");
            
        }
        static void cadastraCurso()
        {
            Console.WriteLine("Cadastro de Curso:");
            Console.WriteLine("nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("preço:");
            float preco = float.Parse(Console.ReadLine());
            Curso curso = new Curso(nome,preco,autor);
            produtos.Add(curso);
            Salvar();
            Console.WriteLine("==================================");
        }
    
        static void cadastroEbook()
        {
            Console.WriteLine("Cadastro de Curso:");
            Console.WriteLine("nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("preço:");
            float preco = float.Parse(Console.ReadLine());
            Ebook eb = new Ebook(nome,autor,preco);
            produtos.Add(eb);
            Salvar();
            Console.WriteLine("==================================");
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("preduto.dat", FileMode.OpenOrCreate);
            BinaryFormatter codificado = new BinaryFormatter();    
            codificado.Serialize(stream, produtos); 

            stream.Close(); 
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("preduto.dat", FileMode.OpenOrCreate);
            BinaryFormatter codificado = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)codificado.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();  
                }
          
            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }


}
