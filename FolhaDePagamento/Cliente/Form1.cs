using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
                                    
            if ((txtCpf.Text.Length != 11) || (txtSalario.Text.Length == 0))
            {
                txtHollerit.Text = "Informações inválidas!";
                txtCpf.Text = "";
                txtDependente.Text = "";
                txtSalario.Text = "";
            }
            else
            {
                string cpf = txtCpf.Text;
                double salario = Convert.ToDouble(txtSalario.Text);
                int dependente = Convert.ToInt16(txtDependente.Text);

                double inss = 0,
                        ir = 0,
                        fgts = 0,
                        liquido = 0;

                localhost.Service hollerit = new localhost.Service();

                if ((txtCpf.Text == "") || (txtDependente.Text == "") || (txtSalario.Text == ""))
                    txtHollerit.Text = "Preencha todos os campos!!! \t ";
                else
                {
                    if (hollerit.ValidaCpf(txtCpf.Text) == false)
                    {
                        txtHollerit.Text = "CPF Inválido !!!";
                        txtCpf.Text = "";
                    }
                    else
                    {
                        inss = hollerit.ValidaInss(salario);
                        ir = hollerit.ValidaIr(salario, dependente);
                        fgts = salario * 0.08;
                        liquido = salario - inss;
                        liquido -= ir;

                        txtHollerit.Text = "Salário Bruto: R$" + salario + " \t" +
                                       "INSS: R$" + inss + " \t" +
                                       "IR: R$" + ir + " \t" +
                                       "FGTS: R$" + fgts + " \t" +
                                       "Liquído: R$" + liquido;

                        txtDependente.Text = "";
                        txtSalario.Text = "";
                    }
                }


            }
        }

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
