/* Programa simulador da prova de Linguagem de Programação de GTI
 * Prof. José Carlos Bortot
 * Habilitar os comandos de testes se for desejado
 */
//#define TESTE 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadastroClientePrimSem2017
{
    class Program
    {
        /// <summary>
        /// Template ou formato de uma struc para conter os dados de um cliente
        /// </summary>
        public struct stCLIENTE
        {
            public bool flgAtivo;           // true - ativo e falso - Inativo ou
            // excluido
            public int nCodigo;             // codigo do cliente 1, 2, 3, ....
            public string szNome;           // nome do cliente
            public double dSaldo;           // saldo do cliente
        }
        /// <summary>
        /// Vetor de clientes e uma struct para conter os dados de
        /// um cliente
        /// </summary>
        private static stCLIENTE[] stVetCliente,   // vetor de clientes na memória
            stCliente;                      // struct para um cliente
        /// <summary>
        /// Definições do programa
        /// </summary>
        private const int QTDE_MINIMA = 500, // quantidade mínima
            QTDE_MAXIMA = 2000;             // quantidade máxima
        /// <summary>
        /// Opções do menu
        /// </summary>
        private const string CADASTRAR_CLIENTE = "C",
            EXCLUIR_CLIENTE = "E",
            MOSTRAR_CLIENTE = "M",
            SAIR_DO_PROGRAMA = "S";
        /// <summary>
        /// Entry point e esse método terá o exit do programa
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int i,                      // indexador e contador genérico
                nQtdeClientes = 0,      // quantidade de clientes na memória
                nCodigoCliente = 0;     // para receber o código do cliente
            string szOpcao;             // opção de escolha do operador
            DateTime dtHoje;            // para receber a data e hora do sistema
            bool retorno = false;




            do
            {
                try
                {
                    Console.WriteLine("Digite a quantidade de clientes que sera cadastrada entre " + QTDE_MINIMA + " e " + QTDE_MAXIMA + ":");
                    nQtdeClientes = Convert.ToInt32(Console.ReadLine());
                    if (nQtdeClientes == 0)
                        return;
                }
                catch (Exception)
                {

                    Console.WriteLine("Digite um valor valido!");
                }

            } while (nQtdeClientes < QTDE_MINIMA || nQtdeClientes > QTDE_MAXIMA);
            int[] stVetCliente = new int[nQtdeClientes];

            for (i = 0; i < stVetCliente.Length; i++)
            {
                nCodigoCliente = 0;
            }



            // pedir e dimensionar o vetor de clientes com
            //  uma quantidade válida e dar a opção de sair do programa

            stCliente = new stCLIENTE[nQtdeClientes];       //  Inicializar o vetor indicando que não tem nenhum ativo e 
                                                            //      código do cliente 1, 2, 3, ....... nQtdeClientes

            // Loop infinito do programa
            while (true)                 // for(; ;)
            {
                // Exibi o menu de opções do operador
                Console.Clear();         // limpar a tela
                dtHoje = DateTime.Now;   // que horas são?
                Console.WriteLine("\n\tCadastro de clientes FATEC-Itaquá " +
                    dtHoje.Day + "/" + dtHoje.Month + "/" + dtHoje.Year +
                    " às " + dtHoje.Hour + ":" + dtHoje.Minute +
                    ":" + dtHoje.Second);
                Console.WriteLine(CADASTRAR_CLIENTE + " - " +
                    "Cadastrar um novo cliente");
                Console.WriteLine(EXCLUIR_CLIENTE + " - " +
                    "Excluir um cliente existente");
                Console.WriteLine(MOSTRAR_CLIENTE + " - " +
                    "Mostrar os dados de um cliente");
                Console.WriteLine(SAIR_DO_PROGRAMA + " - " +
                    "Sair do programa");
                Console.Write("\tSelecione: ");
                szOpcao = Console.ReadLine().ToUpper(); // recebe em maiúscula
                switch (szOpcao)                 // avaliar a opção escolhida
                {
                    case CADASTRAR_CLIENTE:
                        // ...
                        // pedir um código válido com caracteres válidos
                        retorno = PedirUmCodigoValido(ref nCodigoCliente, nQtdeClientes, "Cadastrar cliente");
                        if (retorno == false)
                            break;
                        // e dar a opção para zero (para cancelar)
                        // Isso tudo será um função ou método
                        //  e Verificar se cancelou e sair do switch
                        Console.WriteLine("Digite o nome do cliente: ");
                        stCliente[nCodigoCliente - 1].szNome = Console.ReadLine();
                        Console.WriteLine("Digite o saldo da conta");
                        stCliente[nCodigoCliente - 1].dSaldo = Convert.ToDouble(Console.ReadLine());


                        stCliente[nCodigoCliente - 1].flgAtivo = true;
                        Console.WriteLine("Usuário cadastrado!");
                        Console.ReadKey();
#if TESTE
                        nQtdeClientes = 500;

                        if (!PedirUmCodigoValido(ref nCodigoCliente,
                            nQtdeClientes, "Cadastrar cliente"))
                            break;                  // volta ao menu
#if TESTE
                        Console.WriteLine("Foi informado código: " +
                            nCodigoCliente + Environment.NewLine +
                            "Digite qq tecla para continuar....");
                        Console.ReadKey();
#endif
#endif


                        // verificar se o cliente já existe
                        //   Se ele já existe exibir os seus dados para
                        //      avisar ao operador e voltar ao menu
                        //   Se não existir pedir os seus dados e os inserir
                        //      no vetor de clientes no código correspondente
                        //   Voltar ao menu
                        break;                  // volta ao menu
                    case EXCLUIR_CLIENTE:
                        // Idem acessar um método para pedir um código
                        // válido ou cancelar a transação errada
                        retorno = PedirUmCodigoValido(ref nCodigoCliente, nQtdeClientes, "Excluir Cliente");
                        if (stCliente[nCodigoCliente - 1].flgAtivo == false)
                        {
                            Console.WriteLine("Cliente não existe");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Código: " + stCliente[nCodigoCliente - 1].nCodigo + "Nome: " + stCliente[nCodigoCliente - 1].szNome + "Saldo: " + stCliente[nCodigoCliente - 1].dSaldo);
                        Console.WriteLine("Cliente excluido com sucesso!");
                        Console.ReadKey();
                        stCliente[nCodigoCliente - 1].flgAtivo = false;

                        // Verificar se o cliente existe (Ativo)
                        // Se não estiver ativo avisar ao operador e
                        //      voltar ao menu
                        // Se o cliente existir, exibir os seus dados e
                        //      pedir a confirmação do operador

                        // Se disser não vai voltar ao menu
                        //  Se disser sim informar, no vetor, que o cliente
                        //      está inativo
                        // voltar ao menu

                        break;                  // volta ao menu
                    case MOSTRAR_CLIENTE:
                        retorno = PedirUmCodigoValido(ref nCodigoCliente, nQtdeClientes, "Mostrar clientes");
                        if (stCliente[nCodigoCliente - 1].flgAtivo == false)
                        {
                            Console.WriteLine("Cliente não cadastrado");
                        }
                        Console.WriteLine("Código: " + stCliente[nCodigoCliente - 1].nCodigo + "\nNome: " + stCliente[nCodigoCliente - 1].szNome + "\nSaldo: " + stCliente[nCodigoCliente - 1].dSaldo);
                        Console.ReadKey();
                        // Pedir o código, cancelar a transação se assim foi
                        // informado, verificar se existe e se não existe
                        //  avisar ao operador
                        // Se existir exibir todos os seus dados e
                        // voltar ao menu
                        break;                  // sai do switch e volta ao menu
                    case SAIR_DO_PROGRAMA:
                        Console.Write("\n\tDeseja sair realmente? (S ou N): ");
                        szOpcao = Console.ReadLine();
                        if (szOpcao == "s" || szOpcao == "S") // só testo s ou S
                            return;              // volta ao Sistema Operacional
                        break;                   // volta ao menu
                    default:                     // nenhuma opção válida
                        Console.WriteLine("Informe uma opção válida!");
                        Console.WriteLine("Digite qq tecla para continuar....");
                        Console.ReadKey();
                        break;                   // volta ao menu
                } // switch
            } // while(true)
        } // main
        /// <summary>
        /// Método que pede e recebe o código válido do cliente
        /// Se informado zero como código isso indica que o operador
        /// não quer executar essa transação
        /// </summary>
        /// <param name="nCodigo">endereço que o invocador do método
        /// passou para receber o código válido desejado</param>
        /// <param name="nQtde">A quantidade de clientes informado pelo operador</param>
        /// <param name="szAcao">Ação que está sendo executada</param>
        /// <returns>true indica que foi digitado um código válido
        /// e false indica que o operador digitou zero para cancelar
        /// a ação ou transação que ele escolheu erroneamente</returns>
        public static bool PedirUmCodigoValido(ref int nCodigo, int nQtde, string szAcao)
        {
            nCodigo = -1;                       // para a exceção
            Console.WriteLine("\n\t" + szAcao); // exibe a ação a ser executada
            do
            {
                try
                {
                    Console.Write("\nInforme um código de cliente válido entre 1 " +
                        nQtde + Environment.NewLine +
                        "Ou zero para cancelar a transação: ");
                    // o código digitado vai estar no invocador do método
                    nCodigo = Convert.ToInt32(Console.ReadLine());
                    if (nCodigo == 0)                    // cancelou?
                        return false;                   // avisa que cancelou
                }
                catch (Exception)
                {
                    Console.WriteLine("\tDigite algarismos válidos!");
                }
            } while (nCodigo < 0 || nCodigo > nQtde); // loop porque foi algo inválido
            return true;                        // tudo bem algo válido
        }
    }
}
