using System;

namespace ProjetoStone
{
    class Program
    {
        public static void Main()
        {
            int somatotal = 0;
            string auxiliar;
            int quantidadeDeEmails;

            Console.WriteLine("== Bem vindo ao Programa Teste Stone ==\n\n");
            Console.WriteLine("Lista de Compras\n");

            somatotal = ValorTotalItens();
            if (somatotal != 0)
            {
                Console.Write("Informe a quantidade de emails a serem cadastrados: ");
                auxiliar = Console.ReadLine();
                
                if(int.TryParse(auxiliar, out quantidadeDeEmails) && auxiliar != "0")
                {
                    string[] listaDeEmails = new string[quantidadeDeEmails];
                    ListaEmail(listaDeEmails, quantidadeDeEmails);

                    Console.WriteLine("\nRESULTADO");
                    CalculaResultado(somatotal, listaDeEmails);
                }
                else
                {
                    Console.WriteLine("Lista de emails vazia.");
                }

            }
            else
            {
                Console.WriteLine("Lista de itens vazia.");
            }

        }

        public static int ValorTotalItens()
        {
            int soma = 0;
            string numero;
            string quantidade;
            string valor;
            int nummeroDeItens;
            int quantidadeDoItem;
            int valorDoItem;

            Console.Write("Informe o número de itens da lista de compras: ");
            numero = Console.ReadLine();

            if (int.TryParse(numero, out nummeroDeItens) && numero != "0")
            {
                for (int i = 0; i < nummeroDeItens; i++)
                {
                    Console.Write("Informe a quantidade do {0}º produto: ", i + 1);
                    quantidade = Console.ReadLine();

                    if (int.TryParse(quantidade, out quantidadeDoItem))
                    {
                        Console.Write("Informe o valor unitário do {0}º produto: ", i + 1);
                        valor = Console.ReadLine();
                        if (int.TryParse(valor, out valorDoItem))
                        {
                            soma = soma + (quantidadeDoItem * valorDoItem);
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                            i--;

                        }

                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                        i--;
                    }
                }
                return soma;
            }
            else
            {
                return 0;
            }

        }

        public static void ListaEmail(string [] arr, int quantidade)
        {
            string email;

            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine("Informe o {0}º email: ", i+1);
                email = Console.ReadLine();
                if (email == "")
                {
                    Console.WriteLine("Email não informado");
                }
                else
                {
                    arr[i] = email;
                }
            }
        }

        public static void CalculaResultado(int soma, string[] arr)
        {
            int valorDividido = soma/arr.Length;
            int resto = (soma % arr.Length);
    

            for(int i = 0; i < arr.Length; i++)
            {
                if(i < arr.Length - resto)
                {
                    Console.WriteLine("email: {0} - valor: {1}.", arr[i], valorDividido);
                }
                else
                {
                    Console.WriteLine("email: {0} - valor: {1}.", arr[i], (valorDividido + 1));
                }
            }

        }


    }
}
