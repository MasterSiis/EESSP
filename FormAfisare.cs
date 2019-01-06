using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace EESSP
{
    public partial class FormAfisare : Form
    {
        OracleConnection connection;
        OracleDataAdapter oracleDataAdapter;
        DataSet dataSet;
        public FormAfisare(OracleConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            dataGridView1.Rows.Clear();
        }

        private void FormAfisare_Load(object sender, EventArgs e)
        {
            label1.Font = new Font("Arial", 22, FontStyle.Bold);
            try
            {
                String sqlQuery = "SELECT * FROM FiseMedicale";
                oracleDataAdapter = new OracleDataAdapter(sqlQuery, connection);
                dataSet = new DataSet();
                oracleDataAdapter.Fill(dataSet, "FiseMedicale");
                dataGridView1.DataSource = dataSet.Tables["FiseMedicale"];
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
