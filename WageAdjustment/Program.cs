using System;
using System.Globalization;

using WageAdjustment.Models;

namespace WageAdjustment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Collaborator> collaborators = new List<Collaborator>();

            while (true)
            {
                string option;

                Console.WriteLine("*****************************AJUSTE SALARIAL DE COLABORADORES*****************************");
                Console.WriteLine("Digite uma Opção:");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Consultar Funcionarios");
                Console.WriteLine("3 - Sair");

                option = Console.ReadLine();

                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Digite o nome do funcionário: ");
                        string name = Console.ReadLine();
                        Console.Write("Digite o cargo do funcionário: ");
                        string occupation = Console.ReadLine();
                        Console.Write("Digite o salário do funcionário: ");
                        double currentSalary = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Digite o ano de contratação do funcionário: ");
                        int hiringYear = Convert.ToInt32(Console.ReadLine());

                        Console.Clear();

                        if (hiringYear > 2019) // colaborador novo
                        {
                            Collaborator newCollaborator = new Collaborator(name, occupation, currentSalary, hiringYear);
                            collaborators.Add(newCollaborator);

                            Console.WriteLine("Funcionário novo cadastrado com sucesso!\n");
                        }
                        else // colaborador antigo
                        {
                            CollaboratorOld newCollaborator = new CollaboratorOld(name, occupation, currentSalary, hiringYear);
                            collaborators.Add(newCollaborator);

                            Console.WriteLine("Funcionário antigo cadastrado com sucesso!\n");

                            if (newCollaborator.CurrentSalary > 7000) // colaborador antigo com salário superior a 7k
                            {
                                newCollaborator.SalaryAdjustment(10);
                            }
                            else
                            {
                                Console.WriteLine("Esse colaborador é antigo e possui salário menor ou igual a R$7000,00.");
                                Console.Write("Entre com a porcentagem para ajuste salarial: ");
                                double porcent = Convert.ToDouble(Console.ReadLine());
                                newCollaborator.SalaryAdjustment(porcent);
                                Console.WriteLine();
                            }
                        }

                        break;

                    case "2":
                        Console.WriteLine("==========================================================================================");
                        Console.WriteLine("Lista de colaboradores");
                        collaborators.ForEach(collaborator =>
                            {
                                Console.WriteLine(collaborator.ToString());
                            });
                        Console.WriteLine("==========================================================================================\n");
                        break;

                    case "3":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
        }
    }
}