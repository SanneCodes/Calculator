using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        //variabler
        float num;
        double num1;//første nummer
        double num2;//andre nummer
        double svar;//svaret på de to første addert, subrahert, divitert eller ganget

        string regneart; //lagrer regneart (+, -, /, *)
        string comma;//lagrer komma (,)

        void clear()
        {
            //gjør alle variabler empty
            txtMain.Text = string.Empty;
            num = 0;
            lblNum1.Text = string.Empty;
            lblRegneart.Text = string.Empty;
        }

        void message()
        {
            string message = "ERROR: Type in a number first"; //lager messege box for når bruker vil avslutte
            string title = "ERROR";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                //gjør ingenting
            }
        }

        public Form1()
        {
            InitializeComponent();
        }


        private void button19_Click(object sender, EventArgs e)
        {
            string message = "Ønsker du å avslutte?"; //lager messege box for når bruker vil avslutte
            string title = "Avslutt";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //alle knapper
        private void btn1_Click(object sender, EventArgs e)
        {
            num = 1;
            txtMain.Text += num.ToString();

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            num = 2;
            txtMain.Text += num.ToString();

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            num = 3;
            txtMain.Text += num.ToString();

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            num = 4;
            txtMain.Text += num.ToString();

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            num = 5;
            txtMain.Text += num.ToString();

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            num = 6;
            txtMain.Text += num.ToString();

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            num = 7;
            txtMain.Text += num.ToString();

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            num = 8;
            txtMain.Text += num.ToString();

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            num = 9;
            txtMain.Text += num.ToString();

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            num = 0;
            txtMain.Text += num.ToString();

        }

        private void btnPercent_Click(object sender, EventArgs e)
        { //regne ut prosent
            if(lblRegneart.Text == string.Empty)
            {
                string message = "ERROR: Skriv inn en regnemåte"; //lager messege box for når bruker vil avslutte
                string title = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    //gjør ingenting
                }
            }
            else if(txtMain.Text == string.Empty)
            {
                string message = "ERROR: Skriv inn det andre tallet først"; //lager messege box for når bruker vil avslutte
                string title = "ERROR";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    //gjør ingenting
                }
            }
            else
            {
                regneart = "%";
                lblRegneart.Text += regneart;

                num1 = double.Parse(lblNum1.Text);
                num2 = double.Parse(txtMain.Text);

                txtMain.Text = string.Empty;
                lblNum1.Text = string.Empty;
                lblRegneart.Text = string.Empty;

                svar = (num1 / 100) * num2;

                txtMain.Text = svar.ToString();
                txtMain.Text += regneart;
                //skriv in prosentandel regnemåte også 100 prosent
                                                //eksempel prosentandel
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //tar vekk 1 element fra txtMain
            txtMain.Text = txtMain.Text.Remove(txtMain.Text.Trim().Length - 1);
            
        }
        //alle regnearter
        private void btnDivide_Click(object sender, EventArgs e)
        {
            regneart = "/";
            lblRegneart.Text += regneart;
            lblNum1.Text = txtMain.Text;
            txtMain.Text = string.Empty;
            if (txtMain.Text == string.Empty && lblRegneart.Text == "/" && lblNum1.Text == string.Empty)
            {
                Debug.Write("ERROR: Type in a number first");
                clear();
                message();
            }
        }

        private void btnTimes_Click(object sender, EventArgs e)
        {
            regneart = "*";
            lblRegneart.Text += regneart;
            lblNum1.Text = txtMain.Text;
            txtMain.Text = string.Empty;
            if (txtMain.Text == string.Empty && lblRegneart.Text == "*" && lblNum1.Text == string.Empty)
            {
                Debug.Write("ERROR: Type in a number first");
                clear();
                message();
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            regneart = "-";
            lblRegneart.Text = regneart;
            lblNum1.Text = txtMain.Text;
            txtMain.Text = string.Empty;

            if(txtMain.Text == string.Empty && lblRegneart.Text == "-" && lblNum1.Text == string.Empty)
            {
                lblRegneart.Text = string.Empty;
                txtMain.Text = regneart;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            regneart = "+";
            lblRegneart.Text += regneart;
            lblNum1.Text = txtMain.Text;
            txtMain.Text = string.Empty;
            if (txtMain.Text == string.Empty && lblRegneart.Text == "+" && lblNum1.Text == string.Empty)
            {
                Debug.Write("ERROR: Type in a number first");
                clear();
                message();
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //konverter fra string til double
            num1 = double.Parse(lblNum1.Text);
            num2 = double.Parse(txtMain.Text);
            
            //bruker switch istedenfor if statements
            switch (regneart)
            { // lager en for hver regneart
                case "/":
                    svar = num1 / num2;
                    txtMain.Text = string.Empty;
                    lblNum1.Text = string.Empty;
                    lblRegneart.Text = string.Empty;
                    txtMain.Text = svar.ToString();
                    break;
                case "*":
                    svar = num1 * num2;
                    txtMain.Text = string.Empty;
                    lblNum1.Text = string.Empty;
                    lblRegneart.Text = string.Empty;
                    txtMain.Text = svar.ToString();
                    break;
                case "-":
                    svar = num1 - num2;
                    txtMain.Text = string.Empty;
                    lblNum1.Text = string.Empty;
                    lblRegneart.Text = string.Empty;
                    txtMain.Text = svar.ToString();
                    break;
                case"+":
                    svar = num1 + num2;
                    txtMain.Text = string.Empty;
                    lblNum1.Text = string.Empty;
                    lblRegneart.Text = string.Empty;
                    txtMain.Text = svar.ToString();
                    break;
            }
        }


        private void btnComma_Click(object sender, EventArgs e)
        { //legger til komma
            comma = ",";
            txtMain.Text += comma;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
