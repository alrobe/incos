namespace AprendidendoAritmetica
{
    public partial class Form1 : Form
    {
        Random n = new Random();
        int n1, n2, n3, n4, n5, n6, n7, n8, n9, n10;
        int res1, res2, res3, res4, res5;
        int rUser1, rUser2, rUser3, rUser4, rUser5;
        int correctos, incorrectos, nota;
        String mensaje;

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            n1 = n.Next(1, 10);
            n2 = n.Next(1, 10);
            n3 = n.Next(1, 10);
            n4 = n.Next(1, 10);
            n5 = n.Next(1, 10);
            n6 = n.Next(1, 10);
            n7 = n.Next(1, 10);
            n8 = n.Next(1, 10);
            n9 = n.Next(1, 10);
            n10 = n.Next(1, 10);
            label1.Text = n1.ToString();
            label2.Text = n2.ToString();
            label3.Text = n3.ToString();
            label4.Text = n4.ToString();
            label5.Text = n5.ToString();
            label6.Text = n6.ToString();
            label7.Text = n7.ToString();
            label8.Text = n8.ToString();
            label16.Text = n9.ToString();
            label17.Text = n10.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                res1 = n1 + n2;
                res2 = n3 + n4;
                res3 = n5 + n6;
                res4 = n7 + n8;
                res5 = n9 + n10;
            }
            else if (radioButton2.Checked)
            {
                res1 = n1 - n2;
                res2 = n3 - n4;
                res3 = n5 - n6;
                res4 = n7 - n8;
                res5 = n9 - n10;
            }
            else if (radioButton3.Checked)
            {
                res1 = n1 * n2;
                res2 = n3 * n4;
                res3 = n5 * n6;
                res4 = n7 * n8;
                res5 = n9 * n10;
            }
            else if (radioButton4.Checked)
            {
                res1 = n1 / n2;
                res2 = n3 / n4;
                res3 = n5 / n6;
                res4 = n7 / n8;
                res5 = n9 / n10;
            }
            else
            {
                label15.Text = "Debe seleccionar una operacion";
                label15.BackColor = Color.Red;
                return;
            }

            rUser1 = int.Parse(textBox1.Text);
            rUser2 = int.Parse(textBox2.Text);
            rUser3 = int.Parse(textBox3.Text);
            rUser4 = int.Parse(textBox4.Text);
            rUser5 = int.Parse(textBox5.Text);
            correctos = 0;
            incorrectos = 0;

            if (rUser1 == res1)
            {
                correctos = correctos + 1;
            }
            else
            {
                incorrectos = incorrectos + 1;
            }

            if (rUser2 == res2)
            {
                correctos = correctos + 1;
            }
            else
            {
                incorrectos = incorrectos + 1;
            }

            if (rUser3 == res3)
            {
                correctos = correctos + 1;
            }
            else
            {
                incorrectos = incorrectos + 1;
            }

            if (rUser4 == res4)
            {
                correctos = correctos + 1;
            }
            else
            {
                incorrectos = incorrectos + 1;
            }

            if (rUser5 == res5)
            {
                correctos = correctos + 1;
            }
            else
            {
                incorrectos = incorrectos + 1;
            }

            nota = correctos * 20;
            label12.Text = correctos.ToString();
            label13.Text = incorrectos.ToString();
            label14.Text = nota.ToString();

            if (nota > 51)
            {
                label15.Text = "Aprobado";
                label15.BackColor = Color.Green;
            }
            else
            {
                label15.Text = "Reprobado";
                label15.BackColor = Color.Red;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Num1";
            label2.Text = "Num2";
            label3.Text = "Num3";
            label4.Text = "Num4";
            label5.Text = "Num5";
            label6.Text = "Num6";
            label7.Text = "Num7";
            label8.Text = "Num8";
            label16.Text = "Num9";
            label17.Text = "Num10";

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            label12.Text = "0";
            label13.Text = "0";
            label14.Text = "0";
            label15.Text = "";

        }
    }
}
