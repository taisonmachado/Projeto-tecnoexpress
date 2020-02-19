using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Projeto_Tecnoexpress.Model;

namespace Projeto_Tecnoexpress.Controller
{
    class Controlador
    {
        private List<Modulo> listaModulo; //Guarda a lista de Módulos.
        private List<Funcionalidade> listaFuncionalidade; //Guarda a lista de Funcionalidades.
        
        //Variáveis para leitura/escrita nos arquivos.
        private StreamWriter escrever;
        private StreamReader ler;

        private Modulo modulo;
        private Funcionalidade funcionalidade;
        
        private static int id; //Variável para incrementar o id automaticamente.

        public Controlador()
        {
            listaModulo = new List<Modulo>();
            listaFuncionalidade = new List<Funcionalidade>();

            this.LerModulos();
            this.LerFuncionalidades();
            //Realiza a leitura dos arquivos assim que um objeto da classe Controlador é instanciado.
        }

        //Endereços dos arquivos de texto.
        private string caminhoModulo = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Arquivos\\Modulos.txt");
        private string caminhoFunc = Directory.GetCurrentDirectory().Replace("bin\\Debug\\netcoreapp3.1", "Arquivos\\Funcionalidades.txt");

        
        public void AddModulo(string descricao, bool mod_bas, float valor)
        {
            id++; //incrementando id automaticamente.

            modulo = new Modulo();
            modulo.Id = id;
            modulo.Descricao_mod = descricao;
            modulo.Mod_basico = mod_bas;
            modulo.Valor = valor;

            listaModulo.Add(modulo); //adicionando na lista.

            //Concatena as informações em uma string para ser adicionada no arquivo.
            string adicionar = id + "|" + descricao + "|" + mod_bas + "|" + valor;
            
            escrever = File.AppendText(caminhoModulo);

            escrever.WriteLine(adicionar); //adicionando no arquivo.

            escrever.Close();
        }

        public void AddFuncionalidade(int idMod, string descricao)
        {

            funcionalidade = new Funcionalidade();
            funcionalidade.Id = idMod;
            funcionalidade.Descricao_func = descricao;

            listaFuncionalidade.Add(funcionalidade); //adiciona na lista.

            //Concatena as informações em uma string para ser adicionada no arquivo.
            string adicionar = id + "|" + descricao;

            escrever = File.AppendText(caminhoFunc);

            escrever.WriteLine(adicionar); //adiciona no arquivo.

            escrever.Close();
        }
        
        private void LerModulos()
        {
            ler = File.OpenText(caminhoModulo);
            string conteudo;
            
            while (!ler.EndOfStream) // Laço é repetido até que chegue ao final do arquivo.
            {
                conteudo = ler.ReadLine(); //Realiza a leitura das linhas do arquivo.
                string[] vetor = conteudo.Split("|"); //Divide a string retornada do arquivo.
                
                modulo = new Modulo();
                modulo.Id = int.Parse(vetor[0]);
                modulo.Descricao_mod = vetor[1];
                modulo.Mod_basico = bool.Parse(vetor[2]);
                modulo.Valor = float.Parse(vetor[3]);
                //Passa as informações do arquivo para um objeto da classe Modulo.

                listaModulo.Add(modulo); //Adiciona o objeto na lista.
            }

            id = modulo.Id; //pega id do ultimo elemento do arquivo.
            ler.Close();
            
        }

        private void LerFuncionalidades()
        {
            ler = File.OpenText(caminhoFunc);
            string conteudo;

            while (!ler.EndOfStream) 
            {
                conteudo = ler.ReadLine(); 
                string[] vetor = conteudo.Split("|"); 
                
                funcionalidade = new Funcionalidade();

                funcionalidade.Id = int.Parse(vetor[0]);
                funcionalidade.Descricao_func = vetor[1];

                listaFuncionalidade.Add(funcionalidade); 
            }

            ler.Close();

        }

        
        public void ListarModulosEscolhidos(List<int> idModulo)
        {
            foreach (int i in idModulo) //Percorre a lista de IDs
            {
                Modulo mod = listaModulo.Find(delegate (Modulo m) //Retorna o módulo corresponde ao ID indicado.
                {
                    return m.Id == i;
                });
                
                //Retorna lista de funcionalidades do Módulo.
                List<Funcionalidade> listaFuncMod = listaFuncionalidade.FindAll(delegate (Funcionalidade f)
                {
                    return f.Id == mod.Id;
                });

                Console.WriteLine(mod.Descricao_mod + " | " + mod.Valor);
               
                foreach(Funcionalidade f in listaFuncMod)
                {
                    Console.WriteLine("      " + f.Descricao_func);
                }
            }
        }
        

        public void ListarModulos()
        {
            foreach(Modulo m in listaModulo)
            {
                Console.WriteLine(m.Id + " | " + m.Descricao_mod);
            }
        }

        public float Orcamento(List<int> idModulo)
        {
            float valorTotal = 0; //Guarda o valor total do orçamento.
            bool basico = false; //Verifica se já existe um módulo básico no orçamento.
            
            foreach (int i in idModulo)
            { 
                Modulo mod = listaModulo.Find(delegate (Modulo m)
                {
                    return m.Id == i;
                });

                if (!mod.Mod_basico)
                {
                    valorTotal += mod.Valor;
                }
                else if (!basico)
                {
                    valorTotal += mod.Valor;
                    basico = true;
                }
            }

            return valorTotal;
        }
    }
}
