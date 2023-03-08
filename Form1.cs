using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Prueba; integrated security = true");
            SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();
            conexion.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //incluir
            SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Prueba; integrated security = true");
            //SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();

            String cadena = "insert into Clientes (Código,Nombre,direccion,Provincia,Telefono,Correo_electronico)"
                + "values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','"
                + textBox4.Text + "','" + textBox5.Text + "')";

            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            MessageBox.Show("Los datos se guardaron correctamente");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";


            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //modificar
            SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Prueba; integrated security = true");
            //SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();

            String cadena = "update Cliente set Nombre= '" + textBox2.Text + "'" +
                ", Direccion = '" + textBox3.Text + "'" +
                ", Provincia = '" + comboBox1.Text + "'" +
                ",Telefono = '" + textBox4.Text + "'" +
                ",Correo_electronico ='" + textBox2.Text + "'" +
                "where Código = " + textBox1.Text;

            SqlCommand comando = new SqlCommand(cadena, conexion);

            int cantidad_modificados = comando.ExecuteNonQuery();

            if (cantidad_modificados == 1)
            {
                MessageBox.Show("Se a modificado los datos");
            }
            else
                MessageBox.Show("No exite una modificacion con el código ingresado");

            conexion.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //eliminar
            SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Prueba; integrated security = true");
            //SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();

            String cadena = "delete from Clientes where Código =" + textBox1.Text;

            SqlCommand comando = new SqlCommand(cadena, conexion);

            int cantidad_borrados = comando.ExecuteNonQuery();
            if (cantidad_borrados == 1)
            {
                MessageBox.Show("El registro fue borrado");
            }
            else
                MessageBox.Show("La identificación no existe");

            conexion.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //salir
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Llenar textbox
            //SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Ventas; integrated security = true");
            SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();
            string cadena = "select identificacion, nombre,telefono from Clientes";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            textBox6.Text = "";
            while (registro.Read())
            {
                textBox6.AppendText(registro["Código"].ToString());
                textBox6.AppendText(" - ");
                textBox6.AppendText(registro["nombre"].ToString());
                textBox6.AppendText(" - ");
                textBox6.AppendText(registro["telefono"].ToString());
                textBox6.AppendText(Environment.NewLine);
            }
            registro.Close();
            conexion.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Llenar datagridview
            //SqlConnection conexion = new SqlConnection("server= 403-12\\ULACIT; database=Ventas; integrated security = true");
            SqlConnection conexion = new SqlConnection("server= DESKTOP-KU604C6; database=Ventas; integrated security = true");
            conexion.Open();
            DataTable dt = new DataTable();

            SqlDataAdapter adaptador = new SqlDataAdapter("select * from Clientes", conexion);
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.Close();
        }
    }
}
