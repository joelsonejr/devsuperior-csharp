namespace Course.Entities
{
    sealed class SavingsAccount : Account02
    {
        public double InteresRate { get; set; }

        public SavingsAccount()
        {

        }

        public SavingsAccount(int number, string holder, double balance, double interestRate) 
            : base(number, holder, balance)
        {
            InteresRate = interestRate;
        }

        public void UpdateBalance() 
        {
            Balance += Balance * InteresRate;
        }

        //override: utilizando o método da superclasse, e realizando alterações
        //no mesmo.
        // public override void Withdraw(double amount)
        // {
        //     Balance -= amount;
        // }

        //base: utilizando o método da SuperClasse,  como ele é, e posteriormente
        // realizando alterações no output do mesmo.
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);

            Balance -= 2.0;
        }
    }
}