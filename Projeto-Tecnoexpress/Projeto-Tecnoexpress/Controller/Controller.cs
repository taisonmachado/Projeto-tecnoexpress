using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Projeto_Tecnoexpress.Model;

namespace Projeto_Tecnoexpress.Controller
{
    class Controller
    {
        List<Modulo> listaModulo;
        List<Funcionalidade> listaFuncionalidade;
        StreamWriter escrever;
        StreamReader ler;
        Modulo modulo;
        Funcionalidade funcionalidade;
        private static int id;

        public Controller()
        {
            listaModulo = new List<Modulo>();
            listaFuncionalidade = new List<Funcionalidade>();

            this.LerModulos();
            this.LerFuncionalidades();

        }

        private string caminhoModulo = "C:\\Users\\taiso\\Documents\\GitHub\\Projeto-tecnoexpress\\Projeto-Tecnoexpress\\Projeto-Tecnoexpress\\View\\Modulos.txt";
        private string caminhoFunc = "C:\\Users\\taiso\\Documents\\GitHub\\Projeto-tecnoexpress\\Projeto-Tecnoexpress\\Projeto-Tecnoexpress\\View\\Funcionalidades.txt";

        
        public void AddModulo(string descricao, bool mod_bas, float valor)
        {
            id++; //incrementando id automaticamente.

            modulo = new Modulo();
            modulo.Id = id;
            modulo.Descricao_mod = descricao;
            modulo.Mod_basico = mod_bas;
            modulo.Valor = valor;

            listaModulo.Add(modulo); //adicionando na lista.

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
            
            string adicionar = id + "|" + descricao;

            escrever = File.AppendText(caminhoFunc);

            escrever.WriteLine(adicionar); //adiciona no arquivo.

            escrever.Close();
        }
        
        private void LerModulos()
        {
            ler = File.OpenText(caminhoModulo);
            string conteudo;
            
            while (!ler.EndOfStream)
            {
                conteudo = ler.ReadLine();
                string[] vetor = conteudo.Split("|");
                modulo = new Modulo();
                modulo.Id = int.Parse(vetor[0]);
                modulo.Descricao_mod = vetor[1];
                modulo.Mod_basico = bool.Parse(vetor[2]);
                modulo.Valor = float.Parse(vetor[3]);

                listaModulo.Add(modulo);
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

        public void ListarModulos()
        {
            foreach (Modulo m in listaModulo)
            {
                Console.WriteLine(m.Descricao_mod + " | " + m.Valor);
                List<Funcionalidade> listaFuncMod = listaFuncionalidade.FindAll(delegate (Funcionalidade f)
                {
                    return f.Id == m.Id;
                });
                foreach(Funcionalidade f in listaFuncMod)
                {
                    Console.WriteLine("     " + f.Descricao_func);
                }


            }
        }
    }
}
