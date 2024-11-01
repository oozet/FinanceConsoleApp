public class BalanceCommand : Command
{
    public BalanceCommand(Program program)
        : base("Balance", "Shows your current balance.", program) { }

    public override void Execute(string[] commandArgs)
    {
        var transactionManager = program.TransactionManager;
        var transactions = transactionManager.GetAllTransactions();
        var balance = transactionManager.GetTotal();
        Console.WriteLine(
            $"Your current balance is ${balance}. You've made a total of {transactions.Count} transactions."
        );
    }
}
