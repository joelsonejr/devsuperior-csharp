using Course.Entities;

namespace Course.Services
{
  class ContractService
  {
    // public int NumberOfInstallments { get; set; }
    private IPaymentService _paymentService;
    
    public ContractService(IPaymentService paymentService) 
    {
        // NumberOfInstallments = installments;
        _paymentService = paymentService;
    }

    public void ProcessContract(Contract contract, int months) 
    {
      double basicValue = contract.TotalValue /  months;

      contract.Installments = new List<Installment>();

      for (int i = 1; i <= months; i++)
      {
        double paymentFee = _paymentService.PaymentFee(basicValue);
        double interest = _paymentService.Interest(basicValue, i);

        double quotaValue = basicValue + interest + paymentFee;
        DateOnly quotaDate = contract.ContractDate.AddMonths(i);

        contract.Installments.Add(new Installment(quotaDate, quotaValue));
      }
    }
  }
}