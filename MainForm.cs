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
    public partial class MainForm : Form
    {
        OracleConnection connection;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setLabels();
            connectToDatabase();
        }

        private void connectToDatabase()
        {
            try
            {
                connection = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=STUDENT;PERSIST SECURITY INFO=True;USER ID=STUDENT");
                connection.Open();
                connection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void setLabels()
        {
            this.ActiveControl = textBox1;
            label1.Font = new Font("Arial", 22, FontStyle.Bold);
            label2.Font = new Font("Arial", 16, FontStyle.Bold);
            label1.Text = "FIȘĂ DE CONSULTAȚII MEDICALE";
            label2.Text = "- ADULTI -";
            label8.Text = DateTime.Now.ToString("dd-MMM-yy");
            label5.Text = "Unitatea \n sanitara";
            label12.Text = "Data \nnasterii";
            label13.Text = "Starea \ncivila";
            label20.Text = "    Locul \nconsultatiei";
            label24.Text = "  Zile con-\ncediu medical";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleParameter p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, 
                            p11, p12, p13, p14, p15, p16, p17, p18, 
                            p19, p20, p21;
            OracleCommand cmd;
            String sexul = String.Empty;
            if (radioButton1.Checked)
                sexul = "Masculin";
            if(radioButton2.Checked)
                sexul = "Feminin";           
            try
            {
                connection.Open();
                p1 = new OracleParameter();p2 = new OracleParameter();p3 = new OracleParameter();p4 = new OracleParameter();
                p5 = new OracleParameter();p6 = new OracleParameter();p7 = new OracleParameter();p8 = new OracleParameter();
                p9 = new OracleParameter();p10 = new OracleParameter();p11 = new OracleParameter();p12 = new OracleParameter();
                p13 = new OracleParameter();p14 = new OracleParameter();p15 = new OracleParameter();p16 = new OracleParameter();
                p17 = new OracleParameter();p18 = new OracleParameter();p19 = new OracleParameter();p20 = new OracleParameter();
                p21 = new OracleParameter();
                p1.Value = textBox1.Text;p2.Value = textBox2.Text;p3.Value = textBox3.Text;
                p4.Value = textBox4.Text;p5.Value = label8.Text;p6.Value = textBox6.Text;
                p7.Value = textBox7.Text;p8.Value = textBox5.Text;p9.Value = sexul;
                p10.Value = comboBox1.Text; p11.Value = dateTimePicker1.Value.ToString("dd-MMM-yy").ToString();
                p12.Value = textBox8.Text; p13.Value = textBox9.Text; p14.Value = textBox10.Text;
                p15.Value = textBox11.Text; p16.Value = textBox12.Text; p17.Value = textBox13.Text;
                p18.Value = textBox14.Text; p19.Value = textBox15.Text; p20.Value = textBox16.Text;
                p21.Value = textBox17.Text;
                String sqlInsertCommand="Insert into FiseMedicale(judetul,localitatea,unitatea_sanitara,nr_fisei,data_completarii," +
                                        "numele,prenumele,CNP,sexul,starea_civila,data_nasterii,domiciliu_judet," +
                                        "domiciliu_localitate,domiciliu_strada,domiciliu_numar,ocupatia,locul_consultatiei,simptome," +
                                        "diagnostic,prescriptii,nr_zile_medical) " +
                                        "values (:1,:2,:3,:4,:5,:6,:7,:8,:9,:10,:11,:12,:13,:14,:15,:16,:17,:18,:19,:20,:21)"; 
                cmd = new OracleCommand(sqlInsertCommand, connection);
                cmd.Parameters.Add(p1);cmd.Parameters.Add(p2);cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);cmd.Parameters.Add(p5);cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);cmd.Parameters.Add(p8);cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);cmd.Parameters.Add(p11);cmd.Parameters.Add(p12);
                cmd.Parameters.Add(p13);cmd.Parameters.Add(p14);cmd.Parameters.Add(p15);
                cmd.Parameters.Add(p16);cmd.Parameters.Add(p17);cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p19);cmd.Parameters.Add(p20);cmd.Parameters.Add(p21);
                cmd.ExecuteNonQuery();
                connection.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
                textBox7.Clear(); textBox8.Clear(); textBox9.Clear(); textBox10.Clear(); textBox11.Clear(); textBox12.Clear();
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear(); textBox17.Clear();
                dateTimePicker1.ResetText();radioButton1.ResetText();radioButton2.ResetText(); comboBox1.ResetText();
                FormAfisare formAfisare = new FormAfisare(connection);
                formAfisare.Show();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
