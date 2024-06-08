namespace ExercicioTres
{
    class ConversorDeMoeda
    {
        static double Iof = 0.06;

        public static double ConverteDolarEmReal(double dolares, double cotacao)
        {   
            double dolarSemImposto = dolares * cotacao; 
            return dolarSemImposto + (dolarSemImposto * Iof);
        }

    }
}