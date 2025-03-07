using GerenciarPedido.Models;
using System;
using System.Net.Sockets;

Random random = new Random();

List<Client> clients =
[
    new()
    {
        Id = new Guid("9d0e7a50-6e04-4dc1-aec5-441e19efda96"),
        Name = "Chris",
    },

    new()
    {
        Id = new Guid("9d0e7a50-6e04-4dc1-aec5-441e19efda97"),
        Name = "Thay",
    },

    new()
    {
        Id = new Guid("9d0e7a50-6e04-4dc1-aec5-441e19efda98"),
        Name = "Dei",
    },
];

List<Order> orders = [];

void listOrders(IEnumerable<Order> ordersParam)
{
    foreach (var item in ordersParam)
    {
        Console.WriteLine($"{item.Id} - {item.ClientID} - {item.Value} - {item.Date}");
    }
}

void validateOptionNull(string? option)
{
    if (string.IsNullOrEmpty(option))
    {
        Console.WriteLine("Nenhuma opção escolhida!");
        menu();
    }
}

Client getClient(Action action)
{
    Console.WriteLine("Escolha o id do cliente:");

    foreach (var client in clients)
    {
        Console.WriteLine($"{client.Id} - {client.Name}");
    }

    string? idClient = Console.ReadLine();

    validateOptionNull(idClient);

    if (!Guid.TryParse(idClient, out Guid id))
    {
        Console.WriteLine("ID inválido! Tente novamente.");
        menu();
    }

    IEnumerable<Client> clientQuery = from client in clients where (client.Id == id) select client;


    if (!clientQuery.Any())
    {
        Console.WriteLine($"{idClient} não existe!");
        action();
    }

    return clientQuery.First();
}

menu();


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
            register();
            break;
        case ("2"):
            listAll();
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
    Client client = getClient(register);


    orders.Add(new Order()
    {
        ClientID = client.Id,
        Date = DateTime.Now,
        Value = 2.6,
        Id = random.Next()
    });

    menu();

}

void listAll()
{
    listOrders(orders);
   
    menu();
}

void searchProduct()
{
    Client client = getClient(searchProduct);

    IEnumerable<Order> ordersQuery = from order in orders where (order.ClientID == client.Id) select order;

    listOrders(ordersQuery);

    menu();

}
