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
using Microsoft.VisualBasic;

List <string> products = [];
List <int> prices = [];

bool addingProducts =false;
int vInputPrice;
int choiceToRemove;

int totalPrice = 0;


while (!addingProducts)
{
    //Check shopping list
    Console.WriteLine("\n-----SHOPPING LIST-----"); //I make the list show after removing or adding products.
    for(int i = 0; i < products.Count; i++)
    {
        string currentProduct = products[i];
        string prodToCapital = char.ToUpper(currentProduct[0]) + currentProduct.Substring(1).ToLower();
        Console.WriteLine($"{i+1}. {prodToCapital} - {prices[i]} kr.");
    }
    foreach(int p in prices)
    {
        totalPrice = totalPrice + p; //Total of all products.
    }
    Console.WriteLine($"\n          Total: {totalPrice} kr.");
    Console.WriteLine("-----------------------");
    totalPrice = 0; //Reseting totalprice because otherwise will add the last value to the new one
    //Adding choices here
    Console.WriteLine("What do you want to do?(write 1 or 2)\n   1. Add a product. \n   2. Remove a product.");
    string choice = Console.ReadLine()!;
    while (choice != "1" && choice != "2")  //validating choices
    {
        Console.WriteLine("Please, give a valid choice following the instructions");
        choice= Console.ReadLine()!;
    }
    if (choice == "1")
    {
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
            
            while(!int.TryParse(inputPrice, out vInputPrice) || vInputPrice < 0) //Validate a number. I thought about 0 number but it can be 2 for 1 or something like that so i will give 0 as a posible price
            {
                Console.WriteLine("Please, add a price with positiv numbers, 0 is ok if you get an REA-offer!");
                inputPrice = Console.ReadLine()!;
                
            }
        
        Console.WriteLine($"{inputProduct} have been added with price {vInputPrice}kr.");
        products.Add(inputProduct.ToLower()); //I am securing myself that the product is added in lowercase
        prices.Add(vInputPrice);
        }
        
        else
        {
            Console.WriteLine("Sorry, you have already added the product."); //if the products if already added then feedback about it
        }
    }
    else
    {
        Console.WriteLine("Choose the number of the product from the shopping list.");
        Console.WriteLine("Shopping list:");
        for(int i = 0; i < products.Count; i++) //showing the list again without total price just so is easier for user to remove product
        {
            string currentProduct = products[i];
            string prodToCapital = char.ToUpper(currentProduct[0]) + currentProduct.Substring(1).ToLower();
            Console.WriteLine($"{i+1}. {prodToCapital} - {prices[i]} kr.");
        }
        
        choiceToRemove = int.Parse(Console.ReadLine()!);
        if (choiceToRemove - 1 < products.Count && choiceToRemove -1 >= 0) //because index always start in 0 so i need to remove 1 from choice.
        {
            products.RemoveAt(choiceToRemove -1);
            prices.RemoveAt(choiceToRemove -1);
        }
        else
        {
            Console.WriteLine("The product is not in the list!");
        }
    }
}
