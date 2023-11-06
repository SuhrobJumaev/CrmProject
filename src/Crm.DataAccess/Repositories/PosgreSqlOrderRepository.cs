
namespace Crm.DataAccess;

using Npgsql;
using System.Data;
using System.Data.SqlClient;

public class PosgreSqlOrderRepository : IOrderRepository
{
    private NpgsqlConnection _npgsqlConnection;

    public PosgreSqlOrderRepository(NpgsqlConnection npgsqlConnection)
    {
        _npgsqlConnection = npgsqlConnection;
    }

    public PosgreSqlOrderRepository()
    {
       _npgsqlConnection = new (SqlHelper.ConnectionString);
    }

    public async Task<Order> CreateAsync(Order entity, CancellationToken token = default)
    {
         _npgsqlConnection.Open();

        string query = @"INSERT INTO ""order"" (description, price, delivery_type, delivery_address, order_state)
	                                VALUES (@description, @price, @delivery_type, @delivery_address, @order_state) RETURNING id;";

        using  NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        cmd.Parameters.Add("@description", NpgsqlTypes.NpgsqlDbType.Text).Value = entity.Description;
        cmd.Parameters.Add("@price", NpgsqlTypes.NpgsqlDbType.Numeric).Value = entity.Price;
        cmd.Parameters.Add("@delivery_type", NpgsqlTypes.NpgsqlDbType.Smallint).Value = (short)entity.DeliveryType;
        cmd.Parameters.Add("@delivery_address", NpgsqlTypes.NpgsqlDbType.Varchar, 100).Value = entity.DeliveryAddress;
        cmd.Parameters.Add("@order_state", NpgsqlTypes.NpgsqlDbType.Smallint).Value = (short)(entity.OrderState ?? OrderState.Pending);

        entity.Id = (int)await cmd.ExecuteScalarAsync(token);

        _npgsqlConnection.Close();

        if (entity.Id > 0)
            return entity;

        return null;
    }

    public async ValueTask<bool> DeleteAsync(int id, CancellationToken token = default)
    {
        _npgsqlConnection.Open();

        string query = @"DELETE FROM ""order"" WHERE id = @Id";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        cmd.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

        int deleteRow = await cmd.ExecuteNonQueryAsync(token);

        _npgsqlConnection.Close();

        if (deleteRow > 0)
            return true;

        return false;
    }

    public async Task<List<Order>> GetAllAsync(CancellationToken token = default)
    {
        List<Order> orders = new ();

        _npgsqlConnection.Open();

        string query = @"SELECT id, description, price, order_date, delivery_type, delivery_address, order_state 
                         FROM ""order""";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        using NpgsqlDataReader npgsqlReader = await cmd.ExecuteReaderAsync(token);

        while (npgsqlReader.Read())
        {
            Order order = new()
            {
                Id = npgsqlReader.GetInt32("id"),
                Description = npgsqlReader.GetString("description"),
                Price  = npgsqlReader.GetDecimal("price"),
                OrderDate = npgsqlReader.GetDateTime("order_date"),
                DeliveryType = (DeliveryType)npgsqlReader.GetInt16("delivery_type"),
                DeliveryAddress = npgsqlReader.GetString("delivery_address"),
                OrderState = (OrderState)npgsqlReader.GetInt16("order_state"),
            };
            orders.Add(order);
        }
        _npgsqlConnection.Close();

        return orders;
    }

    public async Task<Order>? GetAsync(int id, CancellationToken token = default)
    {
        Order order = null;
        _npgsqlConnection.Open();

        string query = @"SELECT id, description, price, order_date, delivery_type, delivery_address, order_state 
                         FROM ""order"" WHERE id = @Id";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);
        
        cmd.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

        using NpgsqlDataReader npgsqlReader = await cmd.ExecuteReaderAsync(token);

        
        while (npgsqlReader.Read())
        {
            order = new()
            {
                Id = npgsqlReader.GetInt32("id"),
                Description = npgsqlReader.GetString("description"),
                Price = npgsqlReader.GetDecimal("price"),
                OrderDate = npgsqlReader.GetDateTime("order_date"),
                DeliveryType = (DeliveryType)npgsqlReader.GetInt16("delivery_type"),
                DeliveryAddress = npgsqlReader.GetString("delivery_address"),
                OrderState = (OrderState)npgsqlReader.GetInt16("order_state"),
            };
        }

        _npgsqlConnection.Close();

        return order;
    }

    public async Task<List<Order>> GetOrderByDescriptionAsync(string description, CancellationToken token = default)
    {
        List<Order> orders = new();

        _npgsqlConnection.Open();

        string query = $@"SELECT id, description, price, order_date, delivery_type, delivery_address, order_state 
                         FROM ""order"" 
                         WHERE description ILike '%{description}%'";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);


        using NpgsqlDataReader npgsqlReader = await cmd.ExecuteReaderAsync(token);

        while (npgsqlReader.Read())
        {
            Order order = new()
            {
                Id = npgsqlReader.GetInt32("id"),
                Description = npgsqlReader.GetString("description"),
                Price = npgsqlReader.GetDecimal("price"),
                OrderDate = npgsqlReader.GetDateTime("order_date"),
                DeliveryType = (DeliveryType)npgsqlReader.GetInt16("delivery_type"),
                DeliveryAddress = npgsqlReader.GetString("delivery_address"),
                OrderState = (OrderState)npgsqlReader.GetInt16("order_state"),
            };
            orders.Add(order);
        }
        _npgsqlConnection.Close();

        return orders;
    }

    public async ValueTask<long> GetOrderTotalCountAsync(CancellationToken token = default)
    {
        _npgsqlConnection.Open();

        string query = @"SELECT COUNT(id) FROM ""order"" ";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        long count = (long)await cmd.ExecuteScalarAsync(token);

        _npgsqlConnection.Close();

       
        return count;
    }

    public async ValueTask<long> GetOrderTotalCountByStateAnsync(OrderState state, CancellationToken token = default)
    {
        _npgsqlConnection.Open();

        string query = @"SELECT COUNT(id) FROM ""order"" WHERE order_state = @OrderState ";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        cmd.Parameters.Add("@OrderState", NpgsqlTypes.NpgsqlDbType.Smallint).Value = (short)state;

        long count = (long)await cmd.ExecuteScalarAsync(token);

        _npgsqlConnection.Close();

        return count;
    }

    public async ValueTask<bool> UpdateOrderByIdAsync(int id, string description, CancellationToken token = default)
    {
        _npgsqlConnection.Open();

        string query = @"UPDATE ""order"" SET description = @Description WHERE id = @Id";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        cmd.Parameters.Add("@Description", NpgsqlTypes.NpgsqlDbType.Varchar).Value = description;
        cmd.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;
        
        int updatedRow = await cmd.ExecuteNonQueryAsync(token);

        _npgsqlConnection.Close();

        if (updatedRow > 0)
            return true;

        return false;
    }

    public async ValueTask<bool> UpdateOrderStateByIdAsync(int id, OrderState state, CancellationToken token = default)
    {
        _npgsqlConnection.Open();

        string query = @"UPDATE ""order"" SET order_state = @State WHERE id = @Id";

        using NpgsqlCommand cmd = new NpgsqlCommand(query, _npgsqlConnection);

        cmd.Parameters.Add("@State", NpgsqlTypes.NpgsqlDbType.Smallint).Value = (short)state;
        cmd.Parameters.Add("@Id", NpgsqlTypes.NpgsqlDbType.Integer).Value = id;

        int updatedRow = await cmd.ExecuteNonQueryAsync(token);

        _npgsqlConnection.Close();

        if (updatedRow > 0)
            return true;

        return false;
    }

    public Order Create(Order entity) =>throw new NotImplementedException();
    public bool Delete(int id) => throw new NotImplementedException();
    public Order? Get(int id) => throw new NotImplementedException();
    public List<Order> GetAll() => throw new NotImplementedException();
    public List<Order> GetOrderByDescription(string description) => throw new NotImplementedException();
    public int GetOrderTotalCount() => throw new NotImplementedException();
    public int GetOrderTotalCountByState(OrderState state) => throw new NotImplementedException();
    public bool UpdateOrderById(int id, string description) => throw new NotImplementedException();
    public bool UpdateOrderStateById(int id, OrderState state) => throw new NotImplementedException();
    
}