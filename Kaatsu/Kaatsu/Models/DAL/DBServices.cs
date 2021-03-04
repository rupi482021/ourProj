﻿using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaatsu.Models;
using System.Collections;

namespace Kaatsu.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public SqlConnection connect(String conString)
        {
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }


        public customer checkUser(customer customer)
        {
            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("checkUserLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        var result = returnParameter.Value;
                        if (result.Equals(1))
                        {
                            while (dr.Read())
                                if (dr["firstName"] != DBNull.Value)
                                {
                                    {
                                        customer.FirstName = (string)dr["firstName"];
                                        customer.SurName = (string)dr["lastName"];
                                        customer.Gender = (string)dr["gender"];
                                        //customer.Birthdate = (string)dr["dateOfBirth"];
                                        //customer.Birthdate = Convert.ToDateTime(dr["dateOfBirth"]);
                                        customer.Email = (string)dr["mail"];
                                        customer.Password = (string)dr["password"];
                                        customer.CategoryType = Convert.ToInt32(dr["CategorycategoryCode"]);
                                        //customer.RegistrationDate = (string)dr["registrationDate"];
                                        //customer.SportType = (string)dr["bodyType"];
                                        customer.Weight = Convert.ToDouble(dr["weight"]);
                                        customer.Height = Convert.ToInt32(dr["height"]);
                                    }
                                }
                        }
                        if (result.Equals(2))
                        {
                            while (dr.Read())
                                if (dr["firstName"] != DBNull.Value)
                                {
                                    {
                                        customer.FirstName = (string)dr["firstName"];
                                        customer.Password = (string)dr["password"];
                                    }
                                }
                        }

                        if (result.Equals(2))
                        {
                            while (dr.Read())

                            {
                                customer.FirstName = (string)dr["firstName"];
                                customer.Password = (string)dr["password"];
                            }

                        }

                        if (result.Equals(3))

                        {
                            customer.FirstName = "not exist";
                        }

                        return customer;

                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public customer addNewCustomer(customer newCustomer)
        {
            SqlConnection con = null;

            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("addCustomer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", newCustomer.Email);
                    cmd.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", newCustomer.SurName);
                    cmd.Parameters.AddWithValue("@gender", newCustomer.Gender);
                    cmd.Parameters.AddWithValue("@password", newCustomer.Password);
                    cmd.Parameters.AddWithValue("@birthdate", newCustomer.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", newCustomer.Weight);
                    cmd.Parameters.AddWithValue("@height", newCustomer.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", newCustomer.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", newCustomer.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", newCustomer.SportInj);
                    cmd.Parameters.AddWithValue("@accident", newCustomer.Accident);
                    cmd.Parameters.AddWithValue("@metadises", newCustomer.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", newCustomer.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", newCustomer.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", newCustomer.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }


                }

                return newCustomer;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

        public void updateCustomerDet(customer updateCustomerDet)
        {

            SqlConnection con = null;
            try
            {
                con = connect("DBConnectionString");

                using (SqlCommand cmd = new SqlCommand("updateCust", con))
                {
                    cmd.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                    cmd.Parameters.AddWithValue("@firstName", updateCustomerDet.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", updateCustomerDet.SurName);
                    cmd.Parameters.AddWithValue("@gender", updateCustomerDet.Gender);
                    cmd.Parameters.AddWithValue("@password", updateCustomerDet.Password);
                    cmd.Parameters.AddWithValue("@birthdate", updateCustomerDet.Birthdate);
                    cmd.Parameters.AddWithValue("@weight", updateCustomerDet.Weight);
                    cmd.Parameters.AddWithValue("@height", updateCustomerDet.Height);
                    cmd.Parameters.AddWithValue("@activeLastYear", updateCustomerDet.ActiveLastYear);
                    cmd.Parameters.AddWithValue("@trainKaatsu", updateCustomerDet.TrainKaatsu);
                    cmd.Parameters.AddWithValue("@sportInj", updateCustomerDet.SportInj);
                    cmd.Parameters.AddWithValue("@accident", updateCustomerDet.Accident);
                    cmd.Parameters.AddWithValue("@metadises", updateCustomerDet.Metadises);
                    cmd.Parameters.AddWithValue("@sportType", updateCustomerDet.SportType);

                    var returnParameter = cmd.Parameters.Add("@results", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;

                    if (result.Equals(1))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("categoryTypeCustomer", con))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@email", updateCustomerDet.Email);
                            cmd1.Parameters.AddWithValue("@categoryType", updateCustomerDet.CategoryType);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }
        }

    }
}