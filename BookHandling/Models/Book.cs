using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookHandling.Models
{
    public class Book
    {
        [Key]
        [Required(ErrorMessage ="Enter BookId")]
        [DisplayName("Book ID")]
        public int BookId {  get; set; }

        [Required(ErrorMessage = "Enter Book Name")]
        [DisplayName("Book Name")]
        public string? BookName {  get; set; }

        [Required(ErrorMessage = "Enter BookAuthor")]
        [DisplayName("Book Author")]
        public string? BookAuthor { get; set; }

        [Required(ErrorMessage = "Enter BookPrice")]
        [DisplayName("Book Price")]
        [Range(100,10000,ErrorMessage ="Book Price Should Be inside 100 to 10000")]
        public decimal BookPrice {  get; set; }



        public static List<Book> GetAllBooks()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            List<Book> books = new List<Book>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Books;";
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        books.Add(new Book()
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            BookPrice = Convert.ToDecimal(dr["BookPrice"])
                        });
                    }
                }
                return books;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static Book GetBookById(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            List<Book> books = new List<Book>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"select * from Books where BookId=@id;";
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if(dr.HasRows && dr.Read())
                    {
                        return new Book()
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            BookPrice = Convert.ToDecimal(dr["BookPrice"])
                        };
                    }
                    else
                    {
                        throw new Exception("Not Found");
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static Book GetByName(string name)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            List<Book> books = new List<Book>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"select * from Books where BookName=@name;";
                cmd.Parameters.AddWithValue("@name", name);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.HasRows && dr.Read())
                    {
                        return new Book()
                        {
                            BookId = Convert.ToInt32(dr["BookId"]),
                            BookName = Convert.ToString(dr["BookName"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            BookPrice = Convert.ToDecimal(dr["BookPrice"])
                        };
                    }
                    else
                    {
                        throw new Exception("Not Found");
                    }
                }


            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Create(Book book)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertBook";
                cmd.Parameters.AddWithValue("@name", book.BookName);
                cmd.Parameters.AddWithValue("@author", book.BookAuthor);
                cmd.Parameters.AddWithValue("@price", book.BookPrice);
                cmd.Parameters.AddWithValue("@id", book.BookId);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Update(Book book)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"update Books set BookName=@name, BookAuthor=@author, BookPrice=@price where BookId=@id;";
                cmd.Parameters.AddWithValue("@name", book.BookName);
                cmd.Parameters.AddWithValue("@author", book.BookAuthor);
                cmd.Parameters.AddWithValue("@price", book.BookPrice);
                cmd.Parameters.AddWithValue("@id", book.BookId);

                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void Delete(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ActsJune25;Integrated Security=True;";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteBook";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
