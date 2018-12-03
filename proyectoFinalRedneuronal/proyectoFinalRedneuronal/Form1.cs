using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoFinalRedneuronal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        iniNeurona _iniNeurona = new iniNeurona();

        private void btnAnd_Click(object sender, EventArgs e)
        {
            _iniNeurona.salidas = new float[4] { 1, 0, 0, 0 };
            iniciarNeurona();
        }

        private void btnOr_Click(object sender, EventArgs e)
        {
            _iniNeurona.salidas = new float[4] { 1, 1, 1, 0 };
            iniciarNeurona();
        }

        private void iniciarNeurona()
        {
            listBox1.Items.Clear();
            _iniNeurona.config(listBox1);
        }
    }
}
