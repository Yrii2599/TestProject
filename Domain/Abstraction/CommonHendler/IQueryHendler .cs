namespace Domain.Abstraction.CommonHendler
{
    public interface IQuerydHendler<TCommand, ToutModel> where TCommand : IRetrieveRepositoryQuery
    {
        Task<ToutModel> Execute( TCommand command );
    }
}
