using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Taschenrechner : Form
    {
        private string currentCalculation = "";

        private void ButtonClick(object sender, EventArgs e)
        {
            // Zahl oder Operator zu String hinzufügen
            currentCalculation += (sender as Button).Text;

            // Rechnung anzeigen
            textBoxOutput.Text = currentCalculation;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("X", "*").ToString().Replace("÷", "/");

            try
            {
                textBoxOutput.Text = new DataTable().Compute(formattedCalculation, null).ToString();
                currentCalculation = textBoxOutput.Text;
            }
            catch (Exception ex)
            {
                textBoxOutput.Text = "0";
                currentCalculation = "";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = "0";
            currentCalculation = "";
        }

        private void button_ClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            textBoxOutput.Text = currentCalculation;
        }


        public Taschenrechner()
        {
            InitializeComponent();
        }
    }
}
