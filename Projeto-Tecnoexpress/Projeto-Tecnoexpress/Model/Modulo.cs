using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Tecnoexpress.Model
{
    class Modulo
    {
        private int id;
        private string descricao_mod;
        private bool mod_basico;
        private float valor;

        public int Id { get => id; set => id = value; }
        public string Descricao_mod { get => descricao_mod; set => descricao_mod = value; }
        public bool Mod_basico { get => mod_basico; set => mod_basico = value; }
        public float Valor { get => valor; set => valor = value; }
    }
}
