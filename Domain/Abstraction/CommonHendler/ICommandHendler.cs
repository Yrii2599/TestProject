namespace Domain.Abstraction.CommonHendler
{
    public interface ICommandHendler<TCommand, ToutModel> where TCommand : ICreateRepositoryCommand
    {
        Task<ToutModel> Execute( TCommand command );
    }
}
