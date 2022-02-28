using Cars.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cars.Data
{
    internal class CarsDAO
    {
        private string connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=CarsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
        // perform all operations on the database. create delete get etc

        public List<CarsModel> FetchAll()
        {
            List<CarsModel> returnList = new List<CarsModel>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Cars";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new car and add it to the list to return.
                        CarsModel cars = new CarsModel();
                        cars.ID = reader.GetInt32(0);
                        cars.Name = reader.GetString(1);
                        cars.Owner = reader.GetString(2);
                        cars.AppearsIn = reader.GetString(3);
                        cars.Description = reader.GetString(4);

                        returnList.Add(cars);
                    }
                }

                                 
            }
            return returnList;
        }

        // search details by ID
        public CarsModel FetchOne(int Id)
        {

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Cars WHERE Id = @id";

                // associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = Id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                CarsModel cars = new CarsModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //create a new car and add it to the list to return.

                        cars.ID = reader.GetInt32(0);
                        cars.Name = reader.GetString(1);
                        cars.Owner = reader.GetString(2);
                        cars.AppearsIn = reader.GetString(3);
                        cars.Description = reader.GetString(4);

                    }
                }

                return cars;
            }
            
        }

        // create new

        public int CreateOrUpdate (CarsModel carsModel)
        {
            //if carmodel.id <=0 then create
            // if carsmodel.id > 0 then update



            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                
                if(carsModel.ID <=0)
                {
                    sqlQuery = "INSERT INTO dbo.Cars Values(@Name, @Owner, @AppearsIn, @Description)";
                }
                else
                {
                    //update
                    sqlQuery = "UPDATE dbo.Cars SET Name = @Name, Owner = @Owner, AppearsIn = @AppearsIn, Description = @Description WHERE Id = @Id";
                }
                    

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = carsModel.ID;

                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 1000).Value = carsModel.Name;

                command.Parameters.Add("@Owner", System.Data.SqlDbType.VarChar, 1000).Value = carsModel.Owner;

                command.Parameters.Add("@AppearsIn", System.Data.SqlDbType.VarChar, 1000).Value = carsModel.AppearsIn;

                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = carsModel.Description;

                connection.Open();

                int newID = command.ExecuteNonQuery();
                
                return newID;
            }

        }



        // delete one

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE  FROM dbo.Cars WHERE Id = @Id";

                // associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;

                connection.Open();

                int deletedID = command.ExecuteNonQuery();

                return deletedID;
            }
        }

        // update one

        // search for a name

        // search for descrption
    }
}