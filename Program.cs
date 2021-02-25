using System;

namespace DeteccionErrores
{
    public class Fecha
    {
        private int dia;
        private int mes;
        private int año;

        public Fecha(int d, int m, int a) //se añaden parametros al constructor de clase
        {
            dia = d;
            mes = m;
            año = a;
        }

        public Boolean fechaCorrecta() //Boolean en lugar de boolean
        {
            bool diaCorrecto, mesCorrecto, añoCorrecto;
            añoCorrecto = año > 0;
            mesCorrecto = mes >= 1 & mes <= 12;
            switch (mes)
            {
                case 2:
                    if (esBisiesto())
                    {
                        diaCorrecto = dia >= 1 & dia <= 29;
                    }
                    else
                    {
                        diaCorrecto = dia >= 1 & dia <= 28;
                    }
                    break;
                case 11:
                    diaCorrecto = dia >= 1 & dia <= 30;
                    break;
                default:
                    diaCorrecto = dia >= 1 & dia <= 31;
                    break; // adición de break
            }
            return diaCorrecto & mesCorrecto & añoCorrecto;
        }

        public Boolean esBisiesto() // Boolean en lugar de boolean
        {
            return (año % 4 == 0 & año % 100 != 0 || año % 400 == 0);
        }

        public void diaSiguiente()
        {
            dia++;
            if (!fechaCorrecta())
            {
                dia = 1;
                mes++;
                if (!fechaCorrecta())
                {
                    mes = 1;
                    año++;
                }
            }
        }
        
        public String toString()
        {
            string sb = ""; // se declara la variable como un string vacio
            if (dia < 10)
            {
                sb = "0";
            }
            sb = sb + dia + "-";
            if (mes < 10)
            {
                sb = sb + "0";
            }
            sb = sb + mes + "-" + año;
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int d, m, a;

            Console.WriteLine("Introduce fecha: ");
            Console.Write("dia: ");
            d = Int16.Parse(Console.ReadLine());
            Console.Write("mes: ");
            m = Int16.Parse(Console.ReadLine());
            Console.Write("año: ");
            a = Int16.Parse(Console.ReadLine());

            Fecha fecha = new Fecha(d, m, a);

            if (fecha.fechaCorrecta())
            {
                Console.WriteLine("Fecha introducida: " + fecha.toString()); // se utiliza el método de clase fecha en minúsculas
                fecha.diaSiguiente();
                Console.WriteLine("El día siguiente es: " + fecha.toString());
            }
            else
            {
                Console.WriteLine("Fecha no válida");
            }
            Console.ReadLine();
        }
    }
}
