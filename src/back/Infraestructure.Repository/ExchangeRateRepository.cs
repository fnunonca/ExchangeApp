using Dapper;
using Infraestructure.Interface;
using Transversal.Common;
using System.Data;
using Domain.Entity;

namespace Infraestructure.Repository;

public class ExchangeRateRepository: IExchangeRateRepository
{
    private readonly IConnectionFactory _connectionFactory;
    public ExchangeRateRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<List<ExchangeRate>> GetAll()
    {
        using (var connection = _connectionFactory.GetConnection)
        {
            var query = "dbo.SP_Get_ExchangeRate";
            var parameters = new DynamicParameters();
            var binBrand = await connection.QueryAsync<ExchangeRate>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return binBrand.ToList();
        }
    }
}
