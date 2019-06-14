using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// Input | Output => Entrada | Saída
using System.Runtime.Serialization.Formatters.Binary;

namespace ArquivosCSharp
{
    class Program
    {
        [Serializable]
        class Pessoa
        {
            public int idade;
            public string nome;

            public override string ToString()
            {
                return idade.ToString() + " " + nome;
            }
        }
        [Serializable]
        class Carro
        {
            public string modelo;
            public string marca;

            public override string ToString()
            {
                return modelo + " " + marca;
            }
        }

        static void Main(string[] args)
        {
            // OBS: './' pasta raiz do arquivo executável do projeto
            string caminhoDoArquivo = "./schoolofnet.son";
            string caminhoDoArquivoBinario = "./dados.victor";

            // --------------------------------------------
            // Criação de um arquivo!
            // --------------------------------------------

            if (!File.Exists(caminhoDoArquivo))
            {
                // Vou fazer algo aqui
                File.Create(caminhoDoArquivo);
            }

            // --------------------------------------------
            // Escrever dados em um arquivo de texto
            // --------------------------------------------

            // StreamWriter => Canal de escrita
            /*
            StreamWriter escritor = new StreamWriter(caminhoDoArquivo, append: true);
            escritor.WriteLine("Erik fig");
            escritor.WriteLine("Jackson");
            escritor.WriteLine("Wesley");
            escritor.Close();
            */

            // --------------------------------------------
            // Ler dados de um arquivo de texto
            // --------------------------------------------

            // StreamReader => Canal de leitura

            /*
            StreamReader leitor = new StreamReader(caminhoDoArquivo);
            string conteudoDoArquivo = leitor.ReadToEnd(); //
            leitor.Close();
            Console.Write(conteudoDoArquivo);
            */

            // --------------------------------------------
            // Ler dados de um arquivo de texto || Linha por linha
            // --------------------------------------------

            StreamReader leitor = new StreamReader(caminhoDoArquivo);

            // Até o final do arquivo, leia todas as linhas

            // Enquanto não chegar no final do arquivo
            while (!leitor.EndOfStream)
            {

                // Processo do Read Line
                // 1 - Ler a linha
                // 2 - Retornar os dados da linha
                // 3 - Passar para a próxima linha

                Console.WriteLine(leitor.ReadLine());
            }
            leitor.Close();


            // --------------------------------------------
            // Escrever dados em um arquivo binário
            // --------------------------------------------

            FileStream canalDeEscrita = new FileStream(caminhoDoArquivoBinario,FileMode.OpenOrCreate);
            BinaryFormatter serializador = new BinaryFormatter();

            List<Pessoa> usuarios = new List<Pessoa>();
       
            Pessoa erik = new Pessoa();
            erik.nome = "Erik Fig";
            erik.idade = 38;

            Pessoa leonan = new Pessoa();
            leonan.nome = "Leonan Luppi";
            leonan.idade = 30;

            Pessoa luiz = new Pessoa();
            luiz.nome = "Luiz carlos";
            luiz.idade = 30;

            usuarios.Add(erik);
            usuarios.Add(leonan);
            usuarios.Add(luiz);

            // --- Salvamento em arquivo binário
            serializador.Serialize(canalDeEscrita, usuarios); // Pessoa
            canalDeEscrita.Close();

            // --------------------------------------------
            // Ler dados em um arquivo binário
            // --------------------------------------------


            FileStream canalDeLeitura = new FileStream(caminhoDoArquivoBinario,FileMode.Open);
            BinaryFormatter deserializador = new BinaryFormatter();
            var pessoas = (List<Pessoa>)deserializador.Deserialize(canalDeLeitura);
            foreach(var pessoa in pessoas)
            {
                Console.WriteLine(pessoa.ToString());
            }
            canalDeLeitura.Close();


            // Impede que o programa feche!
            Console.ReadLine();
        }
    }
}
