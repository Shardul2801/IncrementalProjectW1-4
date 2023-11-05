using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Managers;
using dotnetapp.Models;

namespace dotnetapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of managers  
            PlayerManager p = new PlayerManager();
            while(true){
                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice){
                    case 1: p.DisplayAllPlayers();
                    break;
                    case 2:{
                        int id = Convert.ToInt32(Console.ReadLine());
                        string name = Console.ReadLine();
                        int age = Convert.ToInt32(Console.ReadLine());
                        string category = Console.ReadLine();
                        decimal price = Convert.ToDecimal(Console.ReadLine());
                        
                        
                        Player Pl = new Player();
                            Pl.Id = id;
                            Pl.Name = name;
                            Pl.Age = age;
                            Pl.Category = category;
                            Pl.BiddingPrice = price;

                        p.AddPlayerToDatabase(Pl);
                        break;
                    
                    }
                    case 3: {int id = Convert.ToInt32(Console.ReadLine());
                            string name = Console.ReadLine();
                            int age = Convert.ToInt32(Console.ReadLine());
                            string category = Console.ReadLine();
                            decimal biddingPrice = Convert.ToDecimal(Console.ReadLine());

                            Player P = new Player{Id = id,Name = name, Age = age,Category = category,BiddingPrice = biddingPrice};

                    
                        p.EditPlayer(P);
                        break;
                    }

                    case 4:{  
                                int id = Convert.ToInt32(Console.ReadLine());
                                p.DeletePlayer(id);
                                break;
                            }

                    case 5: {string name = Console.ReadLine();
                            p.FindPlayer(name);
                            break;
                        }

                    case 6:p.ListPlayers();
                    break;
                         
                    
                    
                    default : Environment.Exit(0);
                    break;
                }
            }          
        }
    }
}
