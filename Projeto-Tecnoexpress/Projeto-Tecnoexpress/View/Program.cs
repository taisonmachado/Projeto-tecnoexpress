using System;
using System.IO;
using Projeto_Tecnoexpress.Controller;
using Projeto_Tecnoexpress.Model;

namespace Projeto_Tecnoexpress
{
    class Program
    {
        static void Main(string[] args)
        {
            Projeto_Tecnoexpress.Controller.Controller controller = new Controller.Controller();
            controller.ListarModulos();
        }
    }
}
