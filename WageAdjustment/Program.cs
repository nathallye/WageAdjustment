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
                        double currentSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Digite o ano de contratação do funcionário: ");
                        int hiringYear = int.Parse(Console.ReadLine());

                        Console.Clear();

                        if (hiringYear > 2019) // colaborador novo
                        {
                            Collaborator collaborator = new Collaborator(name, occupation, currentSalary, hiringYear);
                            collaborators.Add(collaborator);

                            Console.WriteLine("Funcionário cadastrado com sucesso!\n");
                        }
                        else // colaborador antigo
                        {
                            CollaboratorOld collaborator = new CollaboratorOld(name, occupation, currentSalary, hiringYear);
                            collaborators.Add(collaborator);

                            Console.WriteLine("Funcionário cadastrado com sucesso!");

                            if (collaborator.CurrentSalary > 7000) // colaborador antigo com salário superior a 7k
                            {
                                Console.WriteLine("De acordo com as regras de negócio, esse colaborador irá receber um ajuste salarial de 10%.");
                                collaborator.SalaryAdjustment(10);
                                Console.WriteLine("Novo salário de " + collaborator.Name + ": R$" + collaborator.CurrentSalary.ToString("F2", CultureInfo.InvariantCulture) + "\n");
                            }
                            else // colaborador antigo com salário inferior ou igual a 7k
                            {
                                Console.WriteLine("Esse colaborador é antigo e possui salário menor ou igual a R$7000,00.");
                                Console.Write("Entre com a porcentagem para ajuste salarial: ");
                                double porcent = Convert.ToDouble(Console.ReadLine());
                                collaborator.SalaryAdjustment(porcent);
                                Console.WriteLine("Novo salário de " + collaborator.Name + ": R$" + collaborator.CurrentSalary.ToString("F2", CultureInfo.InvariantCulture) + "\n");
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