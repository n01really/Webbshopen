﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webbshopen
{
    internal class Inventarie
    {
        public static async Task inventarie()
        {
           await using (var db = new SQL.MyDbContext())
            {
                await foreach (var Products in db.Products)
                {
                    Console.WriteLine(Products.Id + "\t" + Products.Name + "\t" + Products.ProductId + "\t" + Products.Pris + "\t" + Products.Antal + "\t" +
                      Products.Levrantör);
                }
            }
        }
    }
}
