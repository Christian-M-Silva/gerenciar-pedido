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
    Console.WriteLine("");
    foreach (var item in ordersParam)
    {
        Console.WriteLine($"{item.Id} - {item.ClientID} - {item.Value} - {item.Date}");
    }
}

void validateOptionNull(string? option)
{
    if (string.IsNullOrEmpty(option))
    {
        Console.WriteLine("");
        Console.WriteLine("Nenhuma opção escolhida!");
        Console.WriteLine("");
        menu();
    }
}

Client getClient(Action action)
{
    Console.WriteLine("");

    Console.WriteLine("Escolha o id do cliente:");
    Console.WriteLine("");

    foreach (var client in clients)
    {
        Console.WriteLine($"{client.Id} - {client.Name}");
    }

    string? idClient = Console.ReadLine();

    validateOptionNull(idClient);

    if (!Guid.TryParse(idClient, out Guid id))
    {
        Console.WriteLine("");

        Console.WriteLine("ID inválido! Tente novamente.");
        Console.WriteLine("");

        menu();
    }

    IEnumerable<Client> clientQuery = from client in clients where (client.Id == id) select client;


    if (!clientQuery.Any())
    {

        Console.WriteLine("");

        Console.WriteLine($"{idClient} não existe!");
        Console.WriteLine("");

        action();
    }

    return clientQuery.First();
}

menu();


void menu()
{
    Console.WriteLine("");

    Console.WriteLine("Escolha uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Buscar pedido do cliente");
    Console.WriteLine("4 - Calcular valor de pedido de um cliente");
    Console.WriteLine("");


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
            searchProduct();
            break;
        case ("4"):
            calcTotal();
            break;
        default:
            Console.WriteLine("");

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
        Value = 2.0,
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

void calcTotal()
{
    Client client = getClient(calcTotal);

    IEnumerable<Order> ordersQuery = from order in orders where (order.ClientID == client.Id) select order;

    double total = 0;

    foreach (var item in ordersQuery)
    {
        total += item.Value;
    }

    Console.WriteLine("");

    Console.WriteLine($"O cliente {client.Name} tem acumulado de produtos no valor de R${total}");

    menu();

}
