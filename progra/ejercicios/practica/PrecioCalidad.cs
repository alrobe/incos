namespace PrecioCalidad
{
    class PrecioCalidad
    {
        static void Main(string[] args)
        {

            // Una empresa ha establecido diferentes precios a sus productos, según la calidad

            // Calidad 1 2 3
            // Producto
            // 1 5000 4500 4000
            // 2 4500 4000 3500
            // 3 4000 3500 3000

            // Cree un programa que devuelva el precio a pagar por un producto y una calidad dada.
            int idProducto, calidadProducto;

            Console.WriteLine("Ingrese el ID del producto: ");
            idProducto = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese la calidad del producto (1, 2 o 3): ");
            calidadProducto = Convert.ToInt32(Console.ReadLine());

            if (idProducto==1 && calidadProducto==1) {
                Console.WriteLine("El precio del producto es de 5000");
            } else if ((idProducto==1 && calidadProducto==2) || (idProducto==2 && calidadProducto==1)) {
                Console.WriteLine("El precio del producto es de 4500");
            } else if ((idProducto==1 && calidadProducto==3) || (idProducto==2 && calidadProducto==2) || (idProducto==3 && calidadProducto==1)) {
                Console.WriteLine("El precio del producto es de 4000");
            } else if ((idProducto==2 && calidadProducto==3) || (idProducto==3 && calidadProducto==2)) {
                Console.WriteLine("El precio del producto es de 3500");
            } else if (idProducto==3 && calidadProducto==3) {
                Console.WriteLine("El precio del producto es de 3000");
            } else {
                Console.WriteLine("El producto no existe");
            }
        }
    }
}