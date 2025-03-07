using GerenciarPedido.Models;
using System;

List<Client> clients = new List<Client>()
{
    new()
    {
        Id = 1,
        Name = "Chris",
    },

    new()
    {
        Id = 2,
        Name = "Thay",
    },

    new()
    {
        Id = 3,
        Name = "Dei",
    },
};


List<Order> orders = new List<Order>();

bool isExistClient(string id)
{
    IEnumerable<Client> clientQuery = from client in clients where (client.Id == int.Parse(id)) select client;

    return clientQuery.Any();

}

void validateOptionNull(string? option)
{
    if (string.IsNullOrEmpty(option))
    {
        Console.WriteLine("Opção escolhida inexistente");
        menu();
    }
}

void menu()
{
    Console.WriteLine("Escolha uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Buscar pedido do cliente");
    Console.WriteLine("4 - Calcular valor de pedido de um cliente");


    string? idAction = Console.ReadLine();

    validateOptionNull(idAction);

    switch (idAction)
    {
        case ("1"):
            Console.WriteLine("Chama a função de cadastrar");
            break;
        case ("2"):
            Console.WriteLine("Chama a função de Listar");
            break;
        case ("3"):
            Console.WriteLine("Chama a função de Buscar");
            break;
        case ("4"):
            Console.WriteLine("Chama a função de calcular");
            break;
        default:
            Console.WriteLine("Função inexistente!");
            menu();
            break;

    }

}

void register()
{
    Console.WriteLine("Escolha o id do cliente para atribuir o pedido:");
    foreach (var client in clients)
    {
        Console.WriteLine($"{client.Id} - {client.Name}");
    }

    string? idClient = Console.ReadLine();

    validateOptionNull(idClient);

    bool isExist = isExistClient(idClient);

    if (!isExist)
    {
        register();
    }

}

menu();
