using System.Data.SqlClient;

namespace Order.Model
{
    public class DataContext
    {
        SqlConnection conn = new SqlConnection(@"Data Source=FGLAPNL207HFZT\SQLEXPRESS;Initial Catalog=WEBAPI_DB;Integrated Security=True;");
        List<OrderDetailsModel> listofobj = new List<OrderDetailsModel>();

        public IEnumerable<OrderDetailsModel> GetAllOrderDetailsModel()
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Orders", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                OrderDetailsModel sm = new OrderDetailsModel()
                {
                    OrderId = rdr.GetInt32(0),
                    OrderDate = rdr.GetDateTime(1),
                    Amount = rdr.GetDecimal(2),
                };
                listofobj.Add(sm);
            }



            conn.Close();



            return listofobj;
        }





        public void AddOrderDetailsModel(OrderDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO Orders (OrderId, OrderDate,Amount) VALUES ({sm.OrderId},'{sm.OrderDate}',{sm.Amount})", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public void UpdateOrderDetailsModel(int id, OrderDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update Orders set OrderDate='{sm.OrderDate}',Amount={sm.Amount} where OrderId={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }



        public void DeleteOrderDetailsModel(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from Orders where OrderId={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }
    }
}

    