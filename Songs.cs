using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{

 
        /*public static void Demo2()
        {
            Dictionary<string, string> playlist = new Dictionary<string, string>();
            while (true)
            {
                Console.WriteLine("\n=== Playlist Menu ====");
                Console.WriteLine("1. Add Song");
                Console.WriteLine("2. Display Playlist");
                Console.WriteLine("3. Search song by ID");
                Console.WriteLine("4. Delete song by ID");
                Console.WriteLine("5. Exit");

                Console.Write("Enter choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Song ID : ");
                        string id = Console.ReadLine();
                        Console.Write("Enter Song Title : ");
                        string title = Console.ReadLine();

                        if (!playlist.ContainsKey(id))
                        {
                            playlist.Add(id, title);
                            Console.WriteLine("Song added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Song ID already exists. Please use a unique ID.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n=== Playlist ====");
                        foreach (var kvp in playlist)
                        {
                            Console.WriteLine($"ID: {kvp.Key}, Title: {kvp.Value}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter Song ID to search : ");
                        int searchId = int.Parse(Console.ReadLine());
                        if (playlist.TryGetValue(searchId.ToString(), out string songTitle))
                        {
                            Console.WriteLine($"Song found : ID: {searchId}, Title: {songTitle}");
                        }
                        else
                        {
                            Console.WriteLine("Song not found with the given ID.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter Song ID to delete : ");
                        int deleteId = int.Parse(Console.ReadLine());
                        if (playlist.Remove(deleteId.ToString()))
                        {
                            Console.WriteLine("Song deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Song not found with the given ID.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Exiting the playlist menu. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }*/
    }
