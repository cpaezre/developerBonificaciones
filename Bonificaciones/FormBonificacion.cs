using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bonificaciones
{
    public partial class FormBonificacion : Form
    {
        public int puntajeExtraordinario;
        public int puntajeEstandar;
        public int puntajeCritico;

        public FormBonificacion()
        {
            InitializeComponent();
            IniciarConfiguracion();

        }

        private void IniciarConfiguracion()
        {
            this.puntajeExtraordinario = Convert.ToInt32(ConfigurationManager.AppSettings["PuntajeExtraordinario"]);
            this.puntajeEstandar = Convert.ToInt32(ConfigurationManager.AppSettings["PuntajeEstandar"]);
            this.puntajeCritico = Convert.ToInt32(ConfigurationManager.AppSettings["PuntajeCritico"]);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (txtAnio.Text == "" || txtMes.Text == "")
            {
                MessageBox.Show("Debe ingresar mes y año", "Complete los datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var empleados = new List<string[]>();
                OpenFileDialog ofd = new OpenFileDialog() { Filter = "Archivo CSV|*.csv" };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string[] lineas = File.ReadAllLines(ofd.FileName);

                    string[] encabezado = lineas[0].Split(';');
                    dgvEmpleados.Columns.Clear();
                    foreach (string c in encabezado)
                    {
                        dgvEmpleados.Columns.Add(c, c);
                    }

                    for (int i = 1; i < lineas.Length; i++)
                    {
                        string[] celdas = lineas[i].Split(';');
                        if (!celdas[0].Equals(""))
                        {
                            dgvEmpleados.Rows.Add(celdas);
                            ListarEmpleados(celdas);
                        }
                        empleados.Add(celdas);
                    }
                }
            }
            
            //btnCargar.Enabled = false;
        }

        private void ListarEmpleados(string[] celdas)
        {
            var cedula = int.Parse(celdas[0]);
            var empleado = celdas[1];
            var cargo = celdas[2];
            var guardar = 0;

            using (indicadoresEntities db = new indicadoresEntities())
            {

                Empleados oEmpleados = new Empleados();
                var lst = db.Cargos;
                var lst2 = db.Empleados;
                foreach (var oCargos in lst)
                {
                    if (oCargos.descripcion_cargo.ToLower().Equals(cargo.ToLower()))
                    {
                        guardar = oCargos.id_cargo;
                    }
                }

                oEmpleados.documento_empleado = cedula;
                oEmpleados.nombre_empleado = empleado;
                oEmpleados.cargo_id = guardar;
                oEmpleados.Mes = txtMes.Text;
                oEmpleados.Anio = txtAnio.Text;

                db.Empleados.Add(oEmpleados);
                db.SaveChanges();

                //Console.WriteLine(oEmpleados.documento_empleado + " " + oEmpleados.nombre_empleado + " " + oEmpleados.cargo_id);
            }

            Console.WriteLine(cedula + " " + empleado + " " + cargo);

        }
    }
}
