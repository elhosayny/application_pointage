using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
namespace pointage.DAL
{
    class Functions
    {
        public bool login(string user, string password)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from utilisateur where username=@p1 and password=@p2", con.cnx);
            cmd.Parameters.AddWithValue("@p1", user);
            cmd.Parameters.AddWithValue("@p2", password);
            if ((Int32)cmd.ExecuteScalar() > 0)
            {
                con.closeConnection();
                return true;
            }
            else
            {
                con.closeConnection();
                return false;
            }
        
        }
        public void addWorker(string name, string cin)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("insert into ouvrier(nom_ouvrier,cin_ouvrier) values(@p1,@p2)", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", cin);
            cmd.ExecuteNonQuery();
        }
        public DataTable getAllWorkers()
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from ouvrier", con.cnx);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("Nom d'ouvrier");
            dt.Columns.Add("CIN d'ouvrier");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[1], dr[2]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public DataTable getWorkersBy(string keyword)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from ouvrier where nom_ouvrier+cin_ouvrier like '%'+@p1+'%'", con.cnx);
            cmd.Parameters.AddWithValue("@p1", keyword);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("Nom d'ouvrier");
            dt.Columns.Add("CIN d'ouvrier");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[1], dr[2]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public void updateWorker(string name,string cin)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("Update ouvrier set nom_ouvrier=@p1,cin_ouvrier=@p2 where cin_ouvrier=@p2", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", cin);
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }
        public void deleteWorker(string cin)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("delete from ouvrier where cin_ouvrier = @p1", con.cnx);
            cmd.Parameters.AddWithValue("@p1", cin);
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }
        public DataTable getWorkerByName(string name)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from ouvrier where nom_ouvrier = @p1", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("id");
            dt.Columns.Add("nom");
            dt.Columns.Add("cin");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0],dr[1], dr[2]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public int getWorkerByNameLen(string name)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from ouvrier where nom_ouvrier = @p1", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            int len = (Int32)cmd.ExecuteScalar();
            con.closeConnection();
            return len;
        }
        public DataTable getWorkerByCin(string cin)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from ouvrier where cin_ouvrier = @p1", con.cnx);
            cmd.Parameters.AddWithValue("@p1", cin);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("id");
            dt.Columns.Add("nom");
            dt.Columns.Add("cin");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0], dr[1], dr[2]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public int getWorkerByCinLen(string cin)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from ouvrier where cin_ouvrier = @p1", con.cnx);
            cmd.Parameters.AddWithValue("@p1", cin);
            int len = (Int32)cmd.ExecuteScalar();
            con.closeConnection();
            return len;
        }
        public DataTable getWorker(string name,string cin)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from ouvrier where nom_ouvrier = @p1 and cin_ouvrier=@p2", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", cin);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("id");
            dt.Columns.Add("nom");
            dt.Columns.Add("cin");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0], dr[1], dr[2]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public int getWorkerLen(string name, string cin)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from ouvrier where nom_ouvrier = @p1 and cin_ouvrier=@p2", con.cnx);
            cmd.Parameters.AddWithValue("@p1", name);
            cmd.Parameters.AddWithValue("@p2", cin);
            int len = (Int32)cmd.ExecuteScalar();
            con.closeConnection();
            return len;
        }
        public DataTable getDays(int idWorker, int month, int year)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from pointage where annee_pointage=@p1 and mois_pointage =@p2 and numero_ouvrier=@p3", con.cnx);
            cmd.Parameters.AddWithValue("@p1", year);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p2", idWorker);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("idpointage");
            dt.Columns.Add("day");
            dt.Columns.Add("month");
            dt.Columns.Add("year");
            dt.Columns.Add("idworker");
            dt.Columns.Add("status");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public int getDaysLen(int idWorker, int month, int year)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from pointage where annee_pointage=@p1 and mois_pointage=@p2 and numero_ouvrier=@p3", con.cnx);
            cmd.Parameters.AddWithValue("@p1", year);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p3", idWorker);
            int len = (Int32)cmd.ExecuteScalar();
            con.closeConnection();
            return len;
        }
        public void setDay(int idWorker,int day,int month,int year,string status)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("insert into pointage(jour_pointage,mois_pointage,annee_pointage,numero_ouvrier,etat_pointage) values(@p1,@p2,@p3,@p4,@p5)", con.cnx);
            cmd.Parameters.AddWithValue("@p1", day);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p3", year);
            cmd.Parameters.AddWithValue("@p4", idWorker);
            cmd.Parameters.AddWithValue("@p5", status);
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }
        public void updateDayStatus(int idWorker, int day, int month, int year, string status)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("Update pointage set etat_pointage=@p1 where jour_pointage=@p2 and mois_pointage=@p3 and annee_pointage=@p4 and numero_ouvrier=@p5", con.cnx);
            cmd.Parameters.AddWithValue("@p1", status);
            cmd.Parameters.AddWithValue("@p2", day);
            cmd.Parameters.AddWithValue("@p3", month);
            cmd.Parameters.AddWithValue("@p4", year);
            cmd.Parameters.AddWithValue("@p5", idWorker);
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }
        public DataTable getDay(int idWorker, int day, int month, int year, string status)
        {
            DataTable dt = new DataTable();
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select * from pointage where jour_pointage=@p1 and mois_pointage=@p2 and annee_pointage=@p3 and numero_ouvrier = @p4 and etat_pointage=@p5", con.cnx);
            cmd.Parameters.AddWithValue("@p1", day);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p3", year);
            cmd.Parameters.AddWithValue("@p4", idWorker);
            cmd.Parameters.AddWithValue("@p5", status);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Columns.Add("idPointer");
            dt.Columns.Add("day");
            dt.Columns.Add("month");
            dt.Columns.Add("year");
            dt.Columns.Add("idWorker");
            dt.Columns.Add("status");
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
            }
            con.closeConnection();
            return dt;
        }
        public int getDayLen(int idWorker, int day, int month, int year)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("select count(*) from pointage where jour_pointage=@p1 and mois_pointage=@p2 and annee_pointage=@p3 and numero_ouvrier= @p4", con.cnx);
            cmd.Parameters.AddWithValue("@p1", day);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p3", year);
            cmd.Parameters.AddWithValue("@p4", idWorker);
            int len = (int)cmd.ExecuteScalar();
            con.closeConnection();
            return len;
        }
        public void deleteDay(int idWorker, int day, int month, int year)
        {
            Connection con = new Connection();
            con.openConnection();
            OleDbCommand cmd = new OleDbCommand("delete from pointage where jour_pointage=@p1 and mois_pointage=@p2 and annee_pointage=@p3 and numero_ouvrier = @p4", con.cnx);
            cmd.Parameters.AddWithValue("@p1", day);
            cmd.Parameters.AddWithValue("@p2", month);
            cmd.Parameters.AddWithValue("@p3", year);
            cmd.Parameters.AddWithValue("@p4", idWorker);
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }
    }
}
