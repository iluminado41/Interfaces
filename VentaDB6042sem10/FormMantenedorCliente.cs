using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;
using Capa_Logica;

namespace VentaDB6042sem10
{
    public partial class FormMantenedorCliente : Form
    {
        public FormMantenedorCliente()
        {
            InitializeComponent();
            listarCliente();
        }

        public void listarCliente()
        {
            dgvCliente.DataSource = DatCliente.Instancia.ListarCliente();
        }
    }
}
