using System;
using System.Collections.Generic;
using System.IO;
using Projeto_Tecnoexpress.Controller;
using Projeto_Tecnoexpress.Model;

namespace Projeto_Tecnoexpress
{
    class Program
    {
        static void Main(string[] args)
        {

            Controlador controlador = new Controlador();
            String decisao;
            
            do
            {
                Console.WriteLine("Cadastar Módulo [1] | " + "Cadastrar Funcionalidade [2] | " + "Fazer Orçamento [3] | " + "Sair [4]");
                decisao = Console.ReadLine();
                Console.Clear();
                switch (decisao)
                {
                    case "1":
                        bool basico = false; //Ajuda a determinar se o Módulo é básico.

                        Console.WriteLine("Insira uma descrição para o Módulo: ");
                        String descrição = Console.ReadLine();

                        Console.WriteLine("É um Módulo Básico? [S/N]");
                        string mod_Bas = Console.ReadLine();

                        if (mod_Bas == "s" || mod_Bas == "S")
                            basico = true;
                        else if (mod_Bas == "n" || mod_Bas == "N")
                            basico = false;

                        Console.WriteLine("Insira um valor para o Módulo: ");
                        float valor = float.Parse(Console.ReadLine());
                        controlador.AddModulo(descrição, basico, valor);

                        Console.WriteLine("Ação Concluída. Pressione ENTER para continuar.");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case "2":
                        controlador.ListarModulos();
                        Console.WriteLine("Digite o número do Módulo ao qual deseja adicionar uma Funcionalidade: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Insira a descrição da Funcionalidade: ");
                        string descricao = Console.ReadLine();

                        controlador.AddFuncionalidade(id, descricao);

                        Console.WriteLine("Ação Concluída. Pressione ENTER para continuar.");
                        Console.ReadLine();
                        Console.Clear();

                        break;
                    case "3":
                        controlador.ListarModulos();
                        List<int> listaId = new List<int>();
                        do
                        {
                            Console.WriteLine("Insira o número do Módulo que deseja adicionar ao Orçamento: ");
                            int idModulo = int.Parse(Console.ReadLine());

                            listaId.Add(idModulo);

                            Console.WriteLine("Deseja adicionar outro Módulo? [S/N]");
                            decisao = Console.ReadLine();
                        } while (decisao == "S" || decisao == "s");

                        Console.Clear();
                        controlador.ListarModulosEscolhidos(listaId);
                        Console.WriteLine("Total: " + controlador.Orcamento(listaId));
                        break;
                }
            } while (decisao != "4"); //Mantém o console rodando enquanto o usuário não digitar 4.
        }
    }
}
