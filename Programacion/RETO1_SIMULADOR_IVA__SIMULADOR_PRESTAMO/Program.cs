using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("=== SIMULADOR FINANCIERO DAM ===");
        // validacion de usuario
        Console.WriteLine("Indique Usuario y Contrasena para continuar");
        /* 
        User: cliente
        Password: RETO1
        */
        string usuario;
        string contrasena;
        int intentos = 0;
        // Bloque de login
        do
        {
            Console.Write("User: ");
            usuario = (Console.ReadLine() ?? "").Trim().ToLower();

            Console.Write("Password: ");
            contrasena = Console.ReadLine() ?? "";

            if (usuario != "cliente" || contrasena != "RETO1")
            {
                Console.WriteLine("Credenciales incorrectas.");
                intentos++;
                Console.WriteLine($"Intento Fallido: {intentos}/3.");
            } 
        } while ((usuario != "cliente" || contrasena != "RETO1") && intentos < 3);

        if (intentos == 3)
            {
                Console.Clear();
                Console.WriteLine("Has superado el numero de intentos maximo.");
                Console.WriteLine("Presiona una tecla para salir");
                Console.ReadKey(true);
                Console.WriteLine("Finalizando sesion.");
                Thread.Sleep(2000);
                return;
            }
        else
        {
            Console.WriteLine("Acceso Permitido");    
        }
        
        // Menu
        int opcion;

        do
        {
            Console.WriteLine("======MENU PRINCIPAL======");
            Console.WriteLine("1. Calculadora de IVA");
            Console.WriteLine("2. Simulador de Prestamos");
            Console.WriteLine("3. Salir");
            Console.WriteLine("===========================");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out opcion) && opcion >=1 && opcion <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Selecciona una opcion entre 1-3");
                }
            }

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    CalculadoraIVA();
                    break;
                case 2:
                    Console.Clear();
                    SimuladorPrestamo();
                    break;
                case 3:
                    string respuesta;
                    
                    do 
                    {  
                        Console.Clear();
                        Console.Write("Esta seguro que desea salir? (S/N): ");
                        respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

                        if (respuesta == "S")
                        {
                            Console.WriteLine("Finalizando sesion");
                            Thread.Sleep(2000);
                            return;
                        }
                        else if (respuesta == "N")
                        {
                            Console.WriteLine("Volviendo al menu.");
                            opcion = 0;
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: Valores aceptados (S/N)");
                            Thread.Sleep(1000);
                        }
                    } while (respuesta != "S" && respuesta != "N");

                    break;
            }
        } while (opcion != 3);
        
    }

    // Calculadora de IVA
    static void CalculadoraIVA()
    {
        // Definicion de constantes de IVA   
        const decimal IVA_GENERAL = 0.21m; // 21% de IVA constante
        const decimal IVA_REDUCIDO = 0.10m; // 10% de IVA constante
        const decimal IVA_SUPERREDUCIDO = 0.04m; // 4% de IVA constante
        decimal ivaSeleccionado = 0m;

        // Delay de cambio de pantalla
        Console.WriteLine("Cargando Calculadora de IVA");
        for (int a = 0; a < 3; a++)
        {
            Thread.Sleep(1200);
            Console.Write(".");
        }

        Thread.Sleep(900);
        Console.Clear();

        Console.WriteLine("===================");
        Console.WriteLine("Calculadora de IVA");
        Console.WriteLine("===================");

        // Solicitar al usuario el precio del producto
        decimal precioProducto;
        while (true)
        {
            Console.Write("Introduce el precio del producto: ");
            if (decimal.TryParse(Console.ReadLine(), out precioProducto) && precioProducto > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Error: Introduce un valor valido");
            }
        }
        // Solicitar al usuario el tipo de IVA
        Console.WriteLine("Seleccione el tipo de IVA");
        Console.WriteLine("1. IVA General (21%)");
        Console.WriteLine("2. IVA Reducido (10%)");
        Console.WriteLine("3. IVA Superreducido (4%)");
        int opcion = 0;
        while (opcion < 1 || opcion > 3)
        {
            try
            {
                Console.Write("Introduce una opcion (1-3): ");
                opcion = int.Parse(Console.ReadLine()!);

                if (opcion < 1 || opcion > 3)
                {
                    Console.WriteLine("Error: Introduce una opcion valida entre 1 y 3");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Debes introducir un numero");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: El numero introducido es demasiado grande");
            }
        }
        // Asignar el IVA seleccionado
        switch (opcion)
        {
            case 1:
                ivaSeleccionado = IVA_GENERAL;
                Console.WriteLine("IVA General seleccionado");
                break;
            case 2:
                ivaSeleccionado = IVA_REDUCIDO;
                Console.WriteLine("IVA Reducido seleccionado");
                break;
            case 3:
                ivaSeleccionado = IVA_SUPERREDUCIDO;
                Console.WriteLine("IVA Superreducido seleccionado");
                break;
        }

        // Calcular el precio con IVA y el valor del IVA
        decimal precioConIVA = precioProducto * (1 + ivaSeleccionado);
        decimal valorIVA = precioProducto * ivaSeleccionado;

        // Mostrar resultados
        Console.WriteLine("======================== RESULTADOS =========================");
        Console.WriteLine($"Precio del producto sin IVA: {precioProducto:F2} euros");
        Console.WriteLine($"IVA aplicado: ({ivaSeleccionado * 100}%) {valorIVA:F2} euros");
        Console.WriteLine($"Precio del producto con IVA: {precioConIVA:F2} euros");
        Console.WriteLine("=============================================================");
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para volver al menu.");
        Console.ReadKey(true);
        Console.Clear();
    }

    // Simulador de prestamo
    static void SimuladorPrestamo()
    {
        // Simulador de prestamos

        // Delay de cambio de pantalla
        Console.WriteLine("Cargando simulador de prestamos...");
        for (int a = 0; a < 3; a++)
        {
            Thread.Sleep(1200);
            Console.Write(".");
        }

        Thread.Sleep(900);
        Console.Clear();

        // Solicitud de datos
        Console.WriteLine("=== SIMULADOR DE PRESTAMOS ===");
        // Solicitar al usuario el monto del prestamo
        decimal prestamo;
        while (true)
        {
            Console.Write("Introduce el monto del prestamo: ");
            if (decimal.TryParse(Console.ReadLine(), out prestamo) && prestamo > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Error: Introduce un valor valido");
            }
        }
        const decimal INTERES_MENSUAL = 0.01m; // 1% de interes mensual

        // Solicitar al usuario el numero de meses para pagar el prestamo
        int mes;
        while (true)
        {
            Console.Write("Introduce el numero de meses para pagar el prestamo: ");
            if (int.TryParse(Console.ReadLine(), out mes) && mes >= 1 && mes <= 12)
            {
                break;
            }
            else
            {
                Console.WriteLine("Error: Introduce un valor entre 1 y 12");
            }
        }
        // Conversion explicita de int a decimal para demostrar el uso de casting solicitado en el Reto 1
        // En este caso C# podria realizar la conversion de forma implicita
        decimal cuotaMensual = Math.Round(prestamo / (decimal)mes, 2);

        Console.Clear();
        Console.WriteLine($"Prestamo: {prestamo} euros | Tiempo para pagar: {mes} meses | Capital mensual {cuotaMensual:F2} euros | Interes {INTERES_MENSUAL * 100}% sobre el saldo pendiente.");
        string respuesta;
        do 
        {
            Console.Write("Acepta el prestamo? (S/N): ");
            respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();
            if (respuesta == "S")
            {
                Console.WriteLine("Prestamo aceptado");
            }
            else if (respuesta == "N")
            {
                Console.WriteLine("Prestamo rechazado.");
                Console.WriteLine("Presiona una tecla para regresar al menu.");
                Console.ReadKey(true);
                Console.WriteLine("Regresando al menu.");
                for (int e = 0; e < 3; e++)
                {
                    Console.Write(".");
                    Thread.Sleep(900);
                }
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Error: Respuesta no soportada");
                Console.WriteLine();
                Console.WriteLine($"Prestamo: {prestamo} euros | Tiempo para pagar: {mes} meses | Capital mensual {cuotaMensual:F2} euros | Interes {INTERES_MENSUAL * 100}% sobre el saldo pendiente.");
            }
        } while (respuesta != "S" && respuesta != "N");

        decimal saldoPendiente = prestamo;
        Console.WriteLine("=== Resultado de la simulacion ===");

        // Sistema de amortizacion de capital constante.
        // Cada mes se devuelve una parte fija del capital solicitado.
        // El interes mensual se calcula sobre el saldo pendiente.
        // La cuota total es la suma del capital amortizado y el interes.
        // En el ultimo mes se ajusta el capital para corregir redondeos.

        decimal totalInteres = 0m;
        decimal totalPagado = 0m;
        for (int i = 1; i <= mes; i++)
        {
            decimal interesMes = Math.Round(saldoPendiente * INTERES_MENSUAL, 2); // Cantidad del interes por mes
            if (i == mes)
            {
                cuotaMensual = saldoPendiente;
            }
            decimal cuotaInteres = Math.Round(cuotaMensual + interesMes, 2); // Cuota mensual con interes
            saldoPendiente -= cuotaMensual; // Cantidad pendiente
            totalInteres += interesMes; // Total del interes pagado
            totalPagado += cuotaInteres; // Total pagado sumando el interes
            Console.WriteLine($"Mes {i} | Interes: {interesMes:F2} euros | Cuota: {cuotaInteres:F2} euros | Saldo pendiente: {saldoPendiente:F2} euros");
        }

        Console.WriteLine($"Capital solicitado : {prestamo:F2} euros");
        Console.WriteLine($"Total de interes pagado: {totalInteres:F2} euros");
        Console.WriteLine($"Total pagado: {totalPagado:F2} euros");
        Console.WriteLine();
        Console.WriteLine("Presiona cualquier tecla para volver al menu.");
        Console.ReadKey(true);
        Console.Clear();
    }
}
