using System.Data.SqlClient;

namespace Product.Model
{
    public class DataContext
    {
        SqlConnection conn = new SqlConnection(@"Data Source=FGLAPNL207HFZT\SQLEXPRESS;Initial Catalog=WEBAPI_DB;Integrated Security=True;");
        List<ProductDetailsModel> listofobj = new List<ProductDetailsModel>();

        public IEnumerable<ProductDetailsModel> GetAllProductDetailsModel()
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Product", conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ProductDetailsModel sm = new ProductDetailsModel()
                {
                    ProductId = rdr.GetInt32(0),
                    ProductName = rdr.GetString(1),
                    Price = rdr.GetDecimal(2),
                    
                };
                listofobj.Add(sm);
            }



            conn.Close();



            return listofobj;
        }





        public void AddProductDetailsModel(ProductDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO Product (ProductId, ProductName,Price) VALUES ({sm.ProductId},'{sm.ProductName}',{sm.Price})", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }




        public void UpdateProductDetailsModel(int id, ProductDetailsModel sm)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"Update Product set ProductName='{sm.ProductName}',Price={sm.Price} where ProductId={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }



        public void DeleteProductDetailsModel(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"delete from Product where ProductId={id}", conn);
            cmd.ExecuteNonQuery();



            conn.Close();
        }
    }
}

    
