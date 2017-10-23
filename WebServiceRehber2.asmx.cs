using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceRehber2
{
    /// <summary>
    /// Summary description for WebServiceRehber2
    /// < /summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceRehber2 : System.Web.Services.WebService
    {

        
        private static string GetCs()
        {
            string cs = @"Data Source=DESKTOP-C5NGNKE\SB;Initial Catalog=TelefonRehberi;Integrated Security=SSPI;User ID = SA;Password=123456;";
            return cs;
        }

        [WebMethod]
        public DataSet IsimAra(string ad)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());
            string query = "select * from Dahili$ where AdSoyad like '%" + ad + "%'";



            // select* from Dahili$ where AdSoyad like 'ali%'

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        [WebMethod]
        public DataSet BolumAra(string BolumAdi)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());
            string query = "select * from Dahili$ where Bolumadi like '%" + BolumAdi + "%'";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }


        [WebMethod]
        public DataSet TrafoAra(string TrafoAdi)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());
            string query = "select * from Harici$ where Isim like '%" + TrafoAdi + "%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }

        [WebMethod]
        public DataSet VeriGoster() {



            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());

            string query = "select BolumAdi,AdSoyad,Dahili1,Dahili2,DahiliID from Dahili$";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }
        [WebMethod]
        public DataSet VeriGoster2()
        {



            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());

            string query = "select Isim,TelefonNo,KodNo,PaxNo,BirimAdi,TrafoID from Harici$";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }

        [WebMethod]
        public System.Data.DataSet KisiEkle(string AdSoyad, string Dahili1, string Dahili2, string BolumAdi) {
            System.Data.DataSet ds = new System.Data.DataSet();

            SqlConnection conn = new SqlConnection(GetCs());
            string query = "begin tran"
            + " INSERT INTO Dahili$(AdSoyad,Dahili1,Dahili2,BolumAdi) VALUES ('" + AdSoyad + "','" + Dahili1 + "','" + Dahili2 + "','" + BolumAdi + "')"
            + " DECLARE @DahiliId INT"
            + " SET @DahiliID = @@IDENTITY"
            + " commit tran";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }


        [WebMethod]

        public int KisiSil(int dahiliID) {

   
            
                
               
                System.Data.DataSet ds = new System.Data.DataSet();
                SqlConnection conn = new SqlConnection(GetCs());

               SqlCommand cmd = new SqlCommand("delete from Dahili$ where DahiliID='"+dahiliID+"'",conn);


            conn.Open();
            int roweffected = cmd.ExecuteNonQuery();
            return roweffected;

        }





        [WebMethod]

        public DataSet KisiGuncelle(string adSoyad, string dahili1, string dahili2, string bolumAdi,int dahiliID) {

            System.Data.DataSet ds = new System.Data.DataSet();

            SqlConnection conn = new SqlConnection(GetCs());
      
            SqlCommand cmd = new SqlCommand("UPDATE Dahili$ Set AdSoyad='"+adSoyad+"',Dahili1='"+dahili1+"',Dahili2='"+dahili2+"', BolumAdi='"+bolumAdi+"' where DahiliID='"+dahiliID+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }



       

        [WebMethod]
        public System.Data.DataSet TrafoEkle(string Isim,string TelefonNo, string KodNo,string PaxNo,string BirimAdi) {
            System.Data.DataSet ds = new System.Data.DataSet();

            SqlConnection conn = new SqlConnection(GetCs());

            string query = "INSERT INTO Harici$(Isim,TelefonNo,KodNo,PaxNo,BirimAdi) VALUES('" + Isim + "','" + TelefonNo + "','" + KodNo + "','" + PaxNo + "','" + BirimAdi + "')";  
               

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
                

        }

        [WebMethod]
        public int TrafoSil(int trafoID) {


            System.Data.DataSet ds = new System.Data.DataSet();
            SqlConnection conn = new SqlConnection(GetCs());

            SqlCommand cmd = new SqlCommand("delete from Harici$ where TrafoID='" +trafoID + "'", conn);


            conn.Open();
            int roweffected = cmd.ExecuteNonQuery();
            return roweffected;

        }


        [WebMethod]

        public DataSet TrafoGuncelle(string isim, string telefonNo, string kodNo, string paxNo, string birimAdi,int trafoID)
        {

            System.Data.DataSet ds = new System.Data.DataSet();

            SqlConnection conn = new SqlConnection(GetCs());

            SqlCommand cmd = new SqlCommand("UPDATE Harici$ Set Isim='" + isim + "',TelefonNo='" + telefonNo+ "',KodNo='" + kodNo + "', PaxNo='" + paxNo + "',BirimAdi='"+birimAdi+"' where TrafoID='" + trafoID + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;


        }





    }
}
