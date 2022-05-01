using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo
{
    public class Data
    {
        public IEnumerable<Producto> Products { get; private set; }

        public Data()
        {
            Products = new List<Producto>
            {
                new Producto()
                {
                    Name = "P40",
                    Brand = "Huawei",
                    Type = "Cel",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = "$500",
                    Img = "cel.jpg"
                },
                new Producto()
                {
                    Name = "Tab 3",
                    Brand = "Samsung",
                    Type = "Tab",
                    Description = "8GB RAM, 250GB Almacenamiento",
                    Price = "$800",
                    Img = "tablet.jpg"
                },
                new Producto()
                {
                    Name = "Speaker",
                    Brand = "Marley",
                    Type = "Audio",
                    Description = "Contra agua",
                    Price = "$700",
                    Img = "speaker.jpg"
                }
            };
        }
    }
}