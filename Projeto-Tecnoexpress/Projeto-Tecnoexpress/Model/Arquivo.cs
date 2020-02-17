using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projeto_Tecnoexpress.Model
{
    class Arquivo
    {
        private StreamWriter escrever;
        private StreamReader ler;

        private string conteudo;

        public string LerConteudo(string caminho)
        {
            ler = File.OpenText(caminho);
            conteudo = ler.ReadLine();
            ler.Close();
            return conteudo;
        }

        public void AddConteudo(string modulo, string caminho)
        {
            escrever = File.AppendText(caminho);
            escrever.Close();
        }
    }
}
