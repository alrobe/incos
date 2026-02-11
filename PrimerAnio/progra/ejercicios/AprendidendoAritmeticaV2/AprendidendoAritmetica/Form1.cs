namespace AprendidendoAritmetica
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int num1, num2, num3, num4, num5, num6, num7, num8, num9, num10;
        int res1, res2, res3, res4, res5;
        int correctos, incorrectos, nota;

        public Form1()
        {
            InitializeComponent();
            set_valores_por_defecto();
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            generar_aleatorios();
            buttonCalcular.Enabled = true;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            realizar_operaciones();
            comparar_res();
            calcular_nota();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            set_valores_por_defecto();
        }


        private void radioButtonOper_CheckedChanged(object sender, EventArgs e)
        {
            actualizar_operadores();
        }

        private void generar_aleatorios()
        {
            num1 = random.Next(1, 10);
            num2 = random.Next(1, 10);
            num3 = random.Next(1, 10);
            num4 = random.Next(1, 10);
            num5 = random.Next(1, 10);
            num6 = random.Next(1, 10);
            num7 = random.Next(1, 10);
            num8 = random.Next(1, 10);
            num9 = random.Next(1, 10);
            num10 = random.Next(1, 10);
            labelNum1.Text = num1.ToString();
            labelNum2.Text = num2.ToString();
            labelNum3.Text = num3.ToString();
            labelNum4.Text = num4.ToString();
            labelNum5.Text = num5.ToString();
            labelNum6.Text = num6.ToString();
            labelNum7.Text = num7.ToString();
            labelNum8.Text = num8.ToString();
            labelNum9.Text = num9.ToString();
            labelNum10.Text = num10.ToString();
        }

        

        private void actualizar_operadores()
        {
            if (radioButtonSum.Checked)
            {
                actualizar_operadores("+");
            }
            else if (radioButtonRes.Checked)
            {
                actualizar_operadores("-");
            }
            else if (radioButtonProd.Checked)
            {
                actualizar_operadores("x");
            }
            else if (radioButtonDiv.Checked)
            {
                actualizar_operadores("/");
            }

        }

        private void actualizar_operadores(string operador)
        {
            labelOperacion1.Text = operador;
            labelOperacion2.Text = operador;
            labelOperacion3.Text = operador;
            labelOperacion4.Text = operador;
            labelOperacion5.Text = operador;
        }

        private void realizar_operaciones()
        {
            if (radioButtonSum.Checked)
            {
                res1 = num1 + num2;
                res2 = num3 + num4;
                res3 = num5 + num6;
                res4 = num7 + num8;
                res5 = num9 + num10;
            }
            else if (radioButtonRes.Checked)
            {
                res1 = num1 - num2;
                res2 = num3 - num4;
                res3 = num5 - num6;
                res4 = num7 - num8;
                res5 = num9 - num10;
            }
            else if (radioButtonProd.Checked)
            {
                res1 = num1 * num2;
                res2 = num3 * num4;
                res3 = num5 * num6;
                res4 = num7 * num8;
                res5 = num9 * num10;
            }
            else if (radioButtonDiv.Checked)
            {
                res1 = num1 / num2;
                res2 = num3 / num4;
                res3 = num5 / num6;
                res4 = num7 / num8;
                res5 = num9 / num10;
            }
            else
            {
                labelMensaje.Text = "Debe seleccionar una operacion";
                labelMensaje.BackColor = Color.Red;
            }
        }

        private void comparar_res()
        {
            correctos = 0;
            incorrectos = 0;
            comparar_res(textBoxRes1, res1);
            comparar_res(textBoxRes2, res2);
            comparar_res(textBoxRes3, res3);
            comparar_res(textBoxRes4, res4);
            comparar_res(textBoxRes5, res5);
        }

        private void comparar_res(TextBox textBoxResUser, int res)
        {
            int res_user;
            bool res_user_valid = int.TryParse(textBoxResUser.Text, out res_user);

            if (res_user_valid && res == res_user)
            {
                correctos = correctos + 1;
                textBoxResUser.BackColor = Color.Green;
            }
            else
            {
                incorrectos = incorrectos + 1;
                textBoxResUser.BackColor = Color.Red;
            }
        }

        private void calcular_nota()
        {
            nota = correctos * 20;

            labelCorrectos.Text = correctos.ToString();
            labelIncorrectos.Text = incorrectos.ToString();
            labelNota.Text = nota.ToString();

            if (nota > 51)
            {
                labelMensaje.Text = "Aprobado";
                labelMensaje.BackColor = Color.Green;
            }
            else
            {
                labelMensaje.Text = "Reprobado";
                labelMensaje.BackColor = Color.Red;

            }
        }

        private void set_valores_por_defecto()
        {
            labelNum1.Text = "0";
            labelNum2.Text = "0";
            labelNum3.Text = "0";
            labelNum4.Text = "0";
            labelNum5.Text = "0";
            labelNum6.Text = "0";
            labelNum7.Text = "0";
            labelNum8.Text = "0";
            labelNum9.Text = "0";
            labelNum10.Text = "0";

            textBoxRes1.Text = "0";
            textBoxRes2.Text = "0";
            textBoxRes3.Text = "0";
            textBoxRes4.Text = "0";
            textBoxRes5.Text = "0";
            textBoxRes1.BackColor = Color.White;
            textBoxRes2.BackColor = Color.White;
            textBoxRes3.BackColor = Color.White;
            textBoxRes4.BackColor = Color.White;
            textBoxRes5.BackColor = Color.White;

            radioButtonSum.Checked = true;
            radioButtonRes.Checked = false;
            radioButtonProd.Checked = false;
            radioButtonDiv.Checked = false;

            labelCorrectos.Text = "0";
            labelIncorrectos.Text = "0";
            labelNota.Text = "0";
            labelMensaje.Text = "";

            buttonCalcular.Enabled = false;

            actualizar_operadores();
        }
    }
}
