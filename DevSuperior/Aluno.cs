namespace Course
{
    class Aluno
    {
        public string Nome;
        public double Nota1, Nota2, Nota3;
        public double NotaFinal;
        public string Status;

        public double CalculaNotaFinal()
        {   
            NotaFinal = Nota1 + Nota2 + Nota3;
            return NotaFinal;
        }

        public string StatusFinal()
        {
            if (NotaFinal >= 60.00) {
                Status = "APROVADO";
            }
            else 
            {
                Status = "REPROVADO";
            }

            return Status;

        }

        public double CalcularNotaFaltante()
        {   
            return 60.00 - NotaFinal;
        }
    }
}