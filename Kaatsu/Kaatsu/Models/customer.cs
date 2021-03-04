using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaatsu.Models
{
    public class customer
    {
        string id;
        string email;
        string password;
        string firstName;
        string surName;
        string gender;
        string birthdate;
        string role;
        string photo;
        string registrationDate;
        int categoryType;
        int height;
        double weight;
        string sportType;
        bool activeLastYear;
        bool trainKaatsu;
        bool sportInj;
        bool accident;
        bool metadises;

        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SurName { get => surName; set => surName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Role { get => role; set => role = value; }
        public string Photo { get => photo; set => photo = value; }
        public string RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public int CategoryType { get => categoryType; set => categoryType = value; }
        public int Height { get => height; set => height = value; }
        public double Weight { get => weight; set => weight = value; }
        public string SportType { get => sportType; set => sportType = value; }
        public bool ActiveLastYear { get => activeLastYear; set => activeLastYear = value; }
        public bool TrainKaatsu { get => trainKaatsu; set => trainKaatsu = value; }
        public bool SportInj { get => sportInj; set => sportInj = value; }
        public bool Accident { get => accident; set => accident = value; }
        public bool Metadises { get => metadises; set => metadises = value; }

        public customer(string email, string password)
        {

            Email = email;
            Password = password;
        }

        public customer() { }

        public customer(string id, string email, string password, string firstName, string surName, string gender, string birthdate, string role, string photo, string registrationDate, int categoryType, int height, double weight, string sportType, bool activeLastYear, bool trainKaatsu, bool sportInj, bool accident, bool metadises)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            SurName = surName;
            Gender = gender;
            Birthdate = birthdate;
            Role = role;
            Photo = photo;
            RegistrationDate = registrationDate;
            CategoryType = categoryType;
            Height = height;
            Weight = weight;
            SportType = sportType;
            ActiveLastYear = activeLastYear;
            TrainKaatsu = trainKaatsu;
            SportInj = sportInj;
            Accident = accident;
            Metadises = metadises;
        }

        public customer(customer customer)
        {
            Email = customer.email;
            Password = customer.password;
            FirstName = customer.firstName;
            SurName = customer.surName;
            Gender = customer.gender;
            Birthdate = customer.birthdate;
            CategoryType = customer.categoryType;
            Height = customer.height;
            Weight = customer.weight;
            SportType = customer.sportType;
            ActiveLastYear = customer.activeLastYear;
            TrainKaatsu = customer.trainKaatsu;
            SportInj = customer.sportInj;
            Accident = customer.accident;
            Metadises = customer.metadises;
        }

        public customer Check()
        {
            DBServices dbs = new DBServices();
            return dbs.checkUser(this);
        }

        public customer Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.addNewCustomer(this);
        }

        public void updateCustomerDet()
        {

            DBServices dbs = new DBServices();
            dbs.updateCustomerDet(this);

        }
    }
}