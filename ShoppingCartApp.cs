using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

namespace ShoppingCartApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart();
        }

        static void ShoppingCart()
        {
            string conStr = @"Server=YOUR_SERVER_NAME;Database=ShoppingDB;Trusted_Connection=True;TrustServerCertificate=True";

            List<(string Name, decimal Price)> cart = new List<(string, decimal)>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT ProductName, Price FROM Products", con);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cart.Add((
                        dr["ProductName"].ToString(),
                        Convert.ToDecimal(dr["Price"])
                    ));
                }

                dr.Close();
            }

            // Total Price
            decimal total = cart.Sum(x => x.Price);
            Console.WriteLine("Total Price = " + total);

            // Apply 10% Discount
            Console.WriteLine("\nDiscounted Prices:");
            cart.Select(x => new
            {
                x.Name,
                DiscountPrice = x.Price * 0.9m
            })
            .ToList()
            .ForEach(x =>
                Console.WriteLine($"{x.Name} - {x.DiscountPrice}")
            );

            // Filter Items Above 2000
            Console.WriteLine("\nItems Price > 2000:");
            cart.Where(x => x.Price > 2000)
                .ToList()
                .ForEach(x =>
                    Console.WriteLine($"{x.Name} - {x.Price}")
                );
        }
        
        
    }
}