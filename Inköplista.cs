//Instruktioner: Skriv en konsolprogram: inköplista ska innehålla namn och pris för varje vara.
//Skapa två listor som kopplar datan med varandra. en list med string (namn) och en list med int (pris)
//(names [i] kostar prices [i])
//ex: 1.Mjölk - 15 kr.
//    2.Bröd - 32kr.   ...
//Input från användaren: Kunna skriva ett namn. Programmet frågar efter pris. (heltal) och lägger bara till listan. Dataverifiering.
//välja ett nummer så kommer varan plockas ur från lista(båda namn och pris)
//Om användaren skriver ett nummer som inte finns i lista ska programmet inte krashar.
//Extra(friviliig): Ordet dyrast skriver ut vilken vara som är dyrast. Sortera listan efter pris.

//Creating two list

using System.ComponentModel;
using System.IO.Pipelines;
using System.Net.Http.Headers;

List <string> products = [];
List <int> prices = [];

bool addingProducts =false;
int vInputPrice;

int totalPrice = 0;
Console.WriteLine("Shopping list:\n");

while (!addingProducts)
{
    for(int i = 0; i < products.Count; i++)
    {
    Console.WriteLine($"{i+1}. {products[i]} - {prices[i]} kr.");
    }
    foreach(int p in prices)
    {
        totalPrice = totalPrice + p;
    }
    Console.WriteLine($"Total: {totalPrice}.");
    Console.Write("Write the name of the product: ");
    
    string inputProduct = Console.ReadLine()!;

    while (string.IsNullOrWhiteSpace(inputProduct) || inputProduct.Any(char.IsDigit)) //If the product is not added as string without spaces or blank will loop
    {
        Console.WriteLine("Please, write name of the product:");
        inputProduct = Console.ReadLine()!;
    }
    if (!products.Contains(inputProduct.ToLower())) //check if the products have not been added before
    {
        Console.Write("What is the price?: ");
        string inputPrice = Console.ReadLine()!;
        while(!int.TryParse(inputPrice, out vInputPrice))
        {
            Console.WriteLine("Please, add a price with numbers!");
            inputPrice = Console.ReadLine()!;
            
        }
    Console.WriteLine($"{inputProduct} have been added with price {vInputPrice}");
    products.Add(inputProduct.ToLower()); //I am securing myself that the product is added in lowercase
    prices.Add(vInputPrice);
    }
    else
    {
        Console.WriteLine("Sorry, you have already added the product."); //if the products if already added then feedback about it
    }
}
