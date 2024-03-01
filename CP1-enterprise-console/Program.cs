// Referenciando o ClassLibrary
using ClassLibrary.Models;
using static System.Net.Mime.MediaTypeNames;

// Inicialização
Console.WriteLine();
Console.WriteLine("---------- **** CP1 - Enterprise Applicattion Development **** ----------");
Console.WriteLine("RM97092 - Vitor Rubim Passos");
Console.WriteLine("RM97324 - Natan Cruz");

// Declaração de listas
var clientes = new List<Cliente>();

// Declaração de váriaveis
var controleDeExecucao = true;
int idCliente = 1;

void exibirErro(string error)
{
    Console.WriteLine();
    Console.WriteLine("======================================");
    Console.WriteLine($"{error}");
    Console.WriteLine("======================================");
}

void menuInicial()
{
    Console.WriteLine();
    Console.WriteLine("---------- **** Sistema de cadastro de Clientes e Conta Bancária **** ----------");
    Console.WriteLine();
    Console.WriteLine("1 - Cadastrar cliente e conta");
    Console.WriteLine("2 - Excluir cliente");
    Console.WriteLine("3 - Exibir cliente");
    Console.WriteLine("4 - Depositar");
    Console.WriteLine("5 - Sacar");
    Console.WriteLine("6 - Sair");
    Console.WriteLine();
    Console.WriteLine("Digite a opção desejada: ");
}

void cadastrarCliente()
{
    Cliente cliente = new Cliente();

    Console.WriteLine("Informe o nome do cliente: ");
    cliente.Nome = Console.ReadLine();

    Console.WriteLine("Informe a idade do cliente: ");
    cliente.Idade = int.Parse(Console.ReadLine());

    Console.WriteLine("Informe o email do cliente: ");
    cliente.Email = Console.ReadLine();

    cliente.Id = idCliente;

    // Auto incrementando o id
    idCliente++;

    clientes.Add(cliente);

    var conta = cadastrarConta();
    
    // Vínculando a conta ao usuário
    cliente.Conta = (Conta)conta;
}

void excluirCliente()
{
    exibirClientes();

    if (clientes.Count == 0)
    {
        return;
    }

    Console.WriteLine("Digite o ID do cliente que deseja excluir: ");
    int idCliente = int.Parse(Console.ReadLine());

    bool clienteEncontrado = false;

    foreach (var cliente in clientes)
    {
        if (cliente.Id == idCliente)
        {
            clientes.Remove(cliente);
            clienteEncontrado = true;

            Console.WriteLine();
            Console.WriteLine($"Cliente com ID {idCliente} foi excluído com sucesso.");
            break;
        }
    }

    if (!clienteEncontrado)
    {
        Console.WriteLine();
        Console.WriteLine($"Cliente com ID {idCliente} não encontrado.");
    }
}

void exibirClientes()
{
    if (clientes.Count >= 1)
    {
        Console.WriteLine("---------- **** Clientes cadastrados: **** ----------");
        Console.WriteLine();

        foreach (Cliente cliente in clientes)
        {
            Console.WriteLine($"{cliente.MostrarDados()}.");
            Console.WriteLine();
        }
    }
    else
    {
        exibirErro("Nenhum cliente cadastrado.");
        return;
    }
}

void depositar()
{
    exibirClientes();

    if (clientes.Count == 0)
    {
        return;
    }

    Console.WriteLine("Digite o ID do cliente para o qual deseja depositar: ");
    int idDepositar = int.Parse(Console.ReadLine());

    Cliente clienteDepositar = clientes.Find(cliente => cliente.Id == idDepositar);

    if (clienteDepositar != null)
    {
        Console.WriteLine($"Digite o valor a ser depositado para {clienteDepositar.Nome}: ");
        double valorDeposito = double.Parse(Console.ReadLine());

        clienteDepositar.Conta.Saldo += valorDeposito;

        Console.WriteLine();
        Console.WriteLine($"Depósito de {valorDeposito:C} realizado com sucesso na conta de {clienteDepositar.Nome}.");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Cliente com ID {idDepositar} não encontrado.");
    }
}

void sacar() {
    exibirClientes();

    if (clientes.Count == 0)
    {
        return;
    }

    Console.WriteLine("Digite o ID do cliente para o qual deseja sacar: ");
    int idSacar = int.Parse(Console.ReadLine());

    Cliente clienteSacar = clientes.Find(cliente => cliente.Id == idSacar);

    if (clienteSacar != null)
    {
        Console.WriteLine();
        Console.WriteLine($"Saldo atual: {clienteSacar.Conta.Saldo:C}");
        Console.WriteLine();
        Console.WriteLine($"Digite o valor a ser sacado da conta do(a) {clienteSacar.Nome}: ");
        double valorSaque = double.Parse(Console.ReadLine());

        if (valorSaque <= clienteSacar.Conta.Saldo)
        {
            clienteSacar.Conta.Saldo -= valorSaque;
            
            Console.WriteLine();
            Console.WriteLine($"Saque de {valorSaque:C} realizado com sucesso na conta de {clienteSacar.Nome}.");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine($"Cliente com ID {idSacar} não encontrado.");
    }
}

object cadastrarConta()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("---------- **** Agora vamos cadastrar uma conta, de qual tipo deseja cadastrar? **** ----------");
        Console.WriteLine("1 - Conta corrente");
        Console.WriteLine("2 - Conta poupança");
        Console.WriteLine("3 - Conta salário");
        Console.WriteLine();
        Console.WriteLine("Digite o número correspondente a opção: ");

        if (int.TryParse(Console.ReadLine(), out int opcaoContaEscolhida))
        {
            switch (opcaoContaEscolhida)
            {
                case 1:
                    ContaCorrente contaCorrente = new();

                    Console.WriteLine("Digite a agência: ");
                    contaCorrente.Agencia = Console.ReadLine();
                    
                    Console.WriteLine("Digite o número: ");
                    contaCorrente.Numero = Console.ReadLine();
                    
                    contaCorrente.Saldo = 0;
                    contaCorrente.ChequeEspecial = 0;
                    
                    return contaCorrente;

                case 2:
                    ContaPoupanca contaPoupanca = new();
                    
                    Console.WriteLine("Digite a agência: ");
                    contaPoupanca.Agencia = Console.ReadLine();
                    
                    Console.WriteLine("Digite o número: ");
                    contaPoupanca.Numero = Console.ReadLine();
                    
                    Console.WriteLine("Qual a rentabilidade da conta: ");
                    contaPoupanca.Rentabilidade = double.Parse(Console.ReadLine());

                    contaPoupanca.Saldo = 0;
                    
                    return contaPoupanca;

                case 3:
                    ContaSalario contaSalario = new();

                    Console.WriteLine("Digite a agência: ");
                    contaSalario.Agencia = Console.ReadLine();

                    Console.WriteLine("Digite o número: ");
                    contaSalario.Numero = Console.ReadLine();

                    Console.WriteLine("Qual o salário mensal: ");
                    contaSalario.SalarioMensal = double.Parse(Console.ReadLine());

                    contaSalario.Saldo = 0;

                    Console.WriteLine();
                    contaSalario.ExibirLogs();

                    return contaSalario;

                default:
                    exibirErro("Opção inválida. Escolha novamente.");
                    break;
            }
        }
        else
        {
            exibirErro("Opção inválida. Escolha novamente.");
        }
    }
}

// Início
while (controleDeExecucao)
{
    menuInicial();
    var opcaoEscolhida = int.Parse(Console.ReadLine());

    switch (opcaoEscolhida)
    {
        case 1:
            cadastrarCliente();
            break;

        case 2:
            excluirCliente();
            break;

        case 3:
            exibirClientes();
            break;

        case 4:
            depositar();
            break;

        case 5:
            sacar();
            break;

        case 6:
            Console.WriteLine("Fim do programa! ");
            controleDeExecucao = false;
            break;

        default:
            exibirErro("Opção inválida. Escolha novamente.");
            break;
    }
}