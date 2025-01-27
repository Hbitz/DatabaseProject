using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using DatabaseProject.Models;


namespace DatabaseProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowMainMenu();
        }
    }
}
