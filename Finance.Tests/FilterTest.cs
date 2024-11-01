using Xunit;

namespace Finance.Tests;

public class FilterTest
{
    [Fact]
    public void FilterTransactions_ShouldReturnFilteredTransactions()
    {
        // Arrange
        Program program = new Program();
        TransactionManager transactionManager = new TransactionManager();
        program.TransactionManager = new TransactionManager();
        FilterTransactionsService filterTransactionsService = new FilterTransactionsService(
            program
        );

        var transaction1 = new TransactionEntry
        {
            Date = new DateTime(2022, 1, 1),
            Amount = 100,
            Uid = program.TransactionManager.UidCounter,
            Type = TransactionType.Deposit,
        };
        var transaction2 = new TransactionEntry
        {
            Date = DateTime.Now,
            Amount = 50,
            Uid = program.TransactionManager.UidCounter,
            Type = TransactionType.Withdrawal,
        };

        program.TransactionManager.AddTransaction(transaction1);
        program.TransactionManager.AddTransaction(transaction2);

        // Act
        var filteredTransactions = filterTransactionsService.FilterTransactions(["year", "2022"]);

        // Assert
        Assert.Single(filteredTransactions);
        Assert.Contains(transaction1, filteredTransactions);
    }
}
