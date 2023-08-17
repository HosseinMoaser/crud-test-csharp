using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands;

public record DeleteCustomerCommand(Guid id) : ICommand;
