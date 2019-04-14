using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDeveloper
{
    class Program
    {

        static void Main(string[] args)
        {
            List<String> titulo = new List<String>();
            List<int> duracao = new List<int>();

            List<int> duracaoSelecionada = new List<int>();
            List<String> tituloSelecionado = new List<String>();

            List<string> trilha01 = new List<string>();
            List<string> trilha02 = new List<string>();

            List<string> listaAux = new List<string>();

            MontaTrilha montar = new MontaTrilha();

            string linha = string.Empty;

            
            // CARREEGAR LISTA COM O ARQUIVO DE ENTRADA 
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Entrada.txt"))
                {
                    while((linha = sr.ReadLine()) != null)
                    {
                        string[] aux = linha.Split(';');
                        titulo.Add(aux[0].Trim());
                        duracao.Add(Convert.ToInt32(aux[1].Trim()));
                    }
                   
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro ao ler o arquivo:");
                Console.WriteLine(e.Message);
            }


            // TRILHA 01
            montar.Manha(ref duracao, ref titulo, ref duracaoSelecionada, ref tituloSelecionado);
            trilha01 = montar.FormataSaidaManha(duracaoSelecionada, tituloSelecionado);

            duracaoSelecionada.Clear();
            tituloSelecionado.Clear();

            montar.Tarde(ref duracao, ref titulo, ref duracaoSelecionada, ref tituloSelecionado);
            listaAux = montar.FormataSaidaTarde(duracaoSelecionada, tituloSelecionado);
            trilha01.AddRange(listaAux);


            duracaoSelecionada.Clear();
            tituloSelecionado.Clear();

            // TRILHA 02
            montar.Manha(ref duracao, ref titulo, ref duracaoSelecionada, ref tituloSelecionado);
            trilha02 = montar.FormataSaidaManha(duracaoSelecionada, tituloSelecionado);

            duracaoSelecionada.Clear();
            tituloSelecionado.Clear();

            montar.Tarde(ref duracao, ref titulo, ref duracaoSelecionada, ref tituloSelecionado);
            listaAux = montar.FormataSaidaTarde(duracaoSelecionada, tituloSelecionado);
            trilha02.AddRange(listaAux);



            Console.WriteLine("Trilha 01");
            Console.WriteLine("=========");
            foreach (string n in trilha01)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            Console.WriteLine("Trilha 02");
            Console.WriteLine("=========");
            foreach (string n in trilha02)
            {
                Console.WriteLine(n);
            }


            Console.ReadKey();

        }
    }
}
